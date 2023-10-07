namespace Zuri_Portfolio_Explore.Domains.DTOs.Response
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public int StatusCode { set; get; }

        public ApiResponse(T data, string message, bool isSuccessful, int reponseCode)
        {
            Data = data;
            Message = message;
            IsSuccessful = isSuccessful;
            StatusCode = reponseCode;
        }

        public ApiResponse()
        {

        }

        public static ApiResponse<T> Fail(string errorMessage, int statusCode)
        {
            return new ApiResponse<T> { Message = errorMessage, StatusCode = statusCode, IsSuccessful = false };
        }

        public static ApiResponse<T> Success(string successMessage, T data, int statusCode = 200)
        {
            return new ApiResponse<T> { Message = successMessage, StatusCode = statusCode, IsSuccessful = true, Data = data };
        }
    }
}