namespace BatelMS.Api.Common;

public class ApiException : Exception
{
    public int StatusCode { get; }

    public DateTimeOffset Timestamp { get; } = DateTimeOffset.UtcNow;

    public ApiException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public ApiResponse<object> ToResponse()
    {
        return ApiResponse<object>.Fail(StatusCode, Message);
    }
}
