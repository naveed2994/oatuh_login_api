using Application.DTO.Common;
using MediatR;

namespace Application.Customers.CommandHandlers
{
    public class RegisterCommand : IRequest<ResponseDTO<bool>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}