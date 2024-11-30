using System.Net;

namespace SyntaxErrorist.Core.APIResponse
{
    public class ApiResponse<T> where T : class
    {
        // HTTP status code of the response
        public HttpStatusCode StatusCode { get; set; }
        // Indicates whether the request was successful
        public bool Succeeded { get; set; }
        // List of errors encountered during the request
        public List<string> Errors { get; set; } = new List<string>();

        // Data payload of the response
        public T? Data { get; set; }

        // Static factory methods to create responses

        // Success response
        public static ApiResponse<T> Success(T data) => new ApiResponse<T>
        {
            Data = data,
            Succeeded = true,
            StatusCode = HttpStatusCode.OK,
        };

        // Created response
        public static ApiResponse<T> Created(T data) => new ApiResponse<T>
        {
            Data = data,
            Succeeded = true,
            StatusCode = HttpStatusCode.Created,
        };

        // Error response
        public static ApiResponse<T> Error(HttpStatusCode statusCode, List<string>? errors = null) => new ApiResponse<T>
        {
            Succeeded = false,
            StatusCode = statusCode,
            Errors = errors ?? new List<string>()
        };

        // Deleted response
        public static ApiResponse<T> Deleted() => new ApiResponse<T>
        {
            Succeeded = true,
            StatusCode = HttpStatusCode.OK,
        };
    }
}
