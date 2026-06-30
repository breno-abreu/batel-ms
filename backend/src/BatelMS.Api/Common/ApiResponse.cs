namespace BatelMS.Api.Common;

public class ApiResponse<TPayload>
{
    public int StatusCode { get; init; }

    public bool Success { get; init; }

    public string Message { get; init; } = string.Empty;

    public TPayload? Payload { get; init; }

    public DateTimeOffset Timestamp { get; init; } = DateTimeOffset.UtcNow;

    public static ApiResponse<TPayload> Ok(TPayload payload, string message = "Operação realizada com sucesso.")
    {
        return new ApiResponse<TPayload>
        {
            StatusCode = StatusCodes.Status200OK,
            Success = true,
            Message = message,
            Payload = payload
        };
    }

    public static ApiResponse<TPayload> Created(TPayload payload, string message = "Registro criado com sucesso.")
    {
        return new ApiResponse<TPayload>
        {
            StatusCode = StatusCodes.Status201Created,
            Success = true,
            Message = message,
            Payload = payload
        };
    }

    public static ApiResponse<TPayload> Fail(int statusCode, string message)
    {
        return new ApiResponse<TPayload>
        {
            StatusCode = statusCode,
            Success = false,
            Message = message
        };
    }
}
