//using Autofac;
//using Autofac.Extensions.DependencyInjection;
//using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
//using Presistance;
using Test_Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("OAuth")
                .AddJwtBearer("OAuth", config =>
                {
                    var secretBytes = Encoding.UTF8.GetBytes("123");
                    var key = new SymmetricSecurityKey(secretBytes);

                    config.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = context =>
                        {
                            if (context.Request.Query.ContainsKey("access_token"))
                            {
                                context.Token = context.Request.Query["access_token"];
                            }

                            return Task.CompletedTask;
                        }
                    };

                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = "https://localhost:7000",
                        ValidAudience = "*",
                        IssuerSigningKey = key,
                    };
                });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin",
         policy => policy.RequireRole("admin"));
    options.AddPolicy("player", policy => { policy.RequireRole("player"); });
});

//builder.Services.AddPresistanceService(builder.Configuration);
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//builder.Host.ConfigureContainer<ContainerBuilder>(options => options.RegisterModule(new IocModule()));
//builder.Services.AddMediatR(typeof(Program).Assembly);
//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Test API",
        Description = "A simple example for swagger api information",
        //TermsOfService = new Uri("https://example.com/terms"),
        //Contact = new OpenApiContact
        //{
        //    Name = "Your Name XYZ",
        //    Email = "xyz@gmail.com",
        //    Url = new Uri("https://example.com"),
        //},
        //License = new OpenApiLicense
        //{
        //    Name = "Use under OpenApiLicense",
        //    Url = new Uri("https://example.com/license"),
        //}
    });
});
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");

});
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyOrigin());
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints => { endpoints.MapControllerRoute("default", "{controller=Customer}/{action=GetAll}/:Id"); });

app.Run();