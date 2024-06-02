using Application.Common.Abstract;
using Application.DTO.Common;
using Domain.Entities;
using MediatR;

namespace Application.Customers.CommandHandlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterCommand, ResponseDTO<bool>>
    {
        private readonly ApplicationDbHelper _con;

        public RegisterUserHandler(ApplicationDbHelper con)
        {
            _con = con;
        }
        public async Task<ResponseDTO<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            User entity = new User();
            entity.Id = Guid.NewGuid();
            entity.Name = request.Name;
            entity.Phone = request.Phone;
            entity.Email = request.Email;
            entity.CreatedBy = Guid.NewGuid();
            entity.CreatedOn = DateTime.Now;
            entity.Password = request.Password;
            entity.Address = request.Address;

            var res = _con.User.Add(entity);
            var re = _con.SaveChangesAsync();
            if (re > 0)
            {
                return new ResponseDTO<bool>() { Status = true, Message = "Signed up successfully.", Data = true };
            }
            return new ResponseDTO<bool>() { Status = false, Message = "Someting went wrogn.", Data = false };

        }
    }
}
