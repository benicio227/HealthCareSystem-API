namespace HealthCareSystem.Application.Models
{
    public class ApplicationResponse<T>
    {
        public bool Success {  get; set; }
        public string Message {  get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ApplicationResponse<T> Ok(T data, string message = "Operação realizada com sucesso")
        {
            return new ApplicationResponse<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static ApplicationResponse<T> Fail(string message)
        {
            return new ApplicationResponse<T>
            {
                Success = false,
                Data = default,
                Message = message
            };
        }
    }
}
