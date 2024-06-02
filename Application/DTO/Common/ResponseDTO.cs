
namespace Application.DTO.Common
{
    public class ResponseDTO<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
