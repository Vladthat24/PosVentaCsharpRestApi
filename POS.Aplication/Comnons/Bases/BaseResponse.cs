using FluentValidation.Results;

namespace POS.Aplication.Comnons.Bases
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationFailure>? Errores { get; set; }
    }
}
