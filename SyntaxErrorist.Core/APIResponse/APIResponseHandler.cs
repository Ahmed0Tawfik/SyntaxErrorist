using System.Net;

namespace SyntaxErrorist.Core.APIResponse
{
    public class ApiResponseHandler
    {
        // Constructor kept protected for inheritance
        public ApiResponseHandler() { }

        // Reusable private method for error responses
        private ApiResponse<T> CreateErrorResponse<T>(HttpStatusCode statusCode, List<string>? errors = null) where T : class
        {
            return ApiResponse<T>.Error(statusCode, errors);
        }

        // Error responses
        public ApiResponse<T> BadRequest<T>(List<string>? errors = null) where T : class
        {
            return CreateErrorResponse<T>(HttpStatusCode.BadRequest,errors);
        }

        public ApiResponse<T> Unauthorized<T>(List<string>? errors = null) where T : class
        {
            return CreateErrorResponse<T>(HttpStatusCode.Unauthorized, errors);
        }

        public ApiResponse<T> NotFound<T>(List<string>? errors = null) where T : class
        {
            return CreateErrorResponse<T>(HttpStatusCode.NotFound, errors);
        }

        public ApiResponse<T> UnprocessableEntity<T>(List<string>? errors = null) where T : class
        {
            return CreateErrorResponse<T>(HttpStatusCode.UnprocessableEntity, errors);
        }

        // Success responses
        public ApiResponse<T> Success<T>(T entity) where T : class
        {
            return ApiResponse<T>.Success(entity);
        }

        public ApiResponse<T> Created<T>(T entity) where T : class
        {
            return ApiResponse<T>.Created(entity);
        }

        public ApiResponse<T> Deleted<T>() where T : class
        {
            return ApiResponse<T>.Deleted();
        }
    }
}
