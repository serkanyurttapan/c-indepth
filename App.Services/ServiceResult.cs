using System.Net;

namespace Services
{
    //DP: Result Pattern
    public class ServiceResult<T> where T : class
    {
        public T? Data { get; set; }

        public bool IsSuccess()
        {
            return Errors == null || Errors.Count == 0 || !string.IsNullOrEmpty(Message);
        }

        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public HttpStatusCode StatusCode { get; set; }


        public bool IsFailure()
        {
            return !IsSuccess();
        }

        //DP: Static Factory Method
        public static ServiceResult<T> Success(T data, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            return new ServiceResult<T> { Data = data, StatusCode = httpStatusCode };
        }

        public static ServiceResult<T> Success(HttpStatusCode httpStatusCode = HttpStatusCode.NoContent)
        {
            return new ServiceResult<T> { StatusCode = httpStatusCode };
        }

        public static ServiceResult<T> Fail(List<string> errors,
            HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T> { Errors = errors, StatusCode = httpStatusCode };
        }

        public static ServiceResult<T> Fail(string error, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T> { Message = error, StatusCode = httpStatusCode };
        }
    }

    public class ServiceResult
    {
        public bool IsSuccess()
        {
            return Errors == null || Errors.Count == 0 || !string.IsNullOrEmpty(Message);
        }

        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public HttpStatusCode StatusCode { get; set; }


        public bool IsFailure()
        {
            return !IsSuccess();
        }

        //DP: Static Factory Method
        public static ServiceResult SuccessNoContent(HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            return new ServiceResult { StatusCode = httpStatusCode };
        }

        public static ServiceResult FailNoContent(List<string> errors,
            HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            return new ServiceResult { Errors = errors, StatusCode = httpStatusCode };
        }

        public static ServiceResult FailNoContent(string error,
            HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            return new ServiceResult { Message = error, StatusCode = httpStatusCode };
        }

        public static ServiceResult Fail(string error, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            return new ServiceResult { Errors = errors, Message = error, StatusCode = httpStatusCode };
        }
    }
}