namespace FinancasPessoais.Domain.UseCases.Lancamentos.Results
{
    public class Result<T> where T : class
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }
        public bool Success { get; set; }

        public static Result<T> Failed(int statusCode, string message, T value = null)
        {
            return new Result<T>
            {
                StatusCode = statusCode,
                Message = message, 
                Value = value,
                Success = false
            };
        }
        public static Result<T> Succeeded(int statusCode, string message, T value = null)
        {
            return new Result<T>
            {
                StatusCode = statusCode,
                Message = message, 
                Value = value,
                Success= true
            };
        }
    }
}