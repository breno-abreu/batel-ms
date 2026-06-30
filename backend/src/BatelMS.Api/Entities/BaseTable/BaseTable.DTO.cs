namespace BatelMS.Api.Entities;

public partial class BaseTable
{
    public sealed record CreateDto(string Name, string? Description);

    public sealed record UpdateDto(string Name, string? Description);

    public sealed record ResponseDto(int Id, string Name, string? Description);

    public ResponseDto ToResponseDto()
    {
        return new ResponseDto(Id, Name, Description);
    }
}
