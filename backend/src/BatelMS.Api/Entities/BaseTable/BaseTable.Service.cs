using BatelMS.Api.Common;
using BatelMS.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace BatelMS.Api.Entities;

public partial class BaseTable
{
    public static async Task<IReadOnlyList<ResponseDto>> GetAllAsync(
        AppDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.BaseTables
            .AsNoTracking()
            .OrderBy(baseTable => baseTable.Id)
            .Select(baseTable => baseTable.ToResponseDto())
            .ToListAsync(cancellationToken);
    }

    public static async Task<ResponseDto> GetByIdAsync(
        AppDbContext dbContext,
        int id,
        CancellationToken cancellationToken)
    {
        var baseTable = await dbContext.BaseTables
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        if (baseTable is null)
        {
            throw new ApiException(StatusCodes.Status404NotFound, "Registro não encontrado.");
        }

        return baseTable.ToResponseDto();
    }

    public static async Task<ResponseDto> CreateAsync(
        AppDbContext dbContext,
        CreateDto dto,
        CancellationToken cancellationToken)
    {
        var baseTable = Create(dto.Name, dto.Description);

        dbContext.BaseTables.Add(baseTable);
        await dbContext.SaveChangesAsync(cancellationToken);

        return baseTable.ToResponseDto();
    }

    public static async Task<ResponseDto> UpdateAsync(
        AppDbContext dbContext,
        int id,
        UpdateDto dto,
        CancellationToken cancellationToken)
    {
        var baseTable = await dbContext.BaseTables
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        if (baseTable is null)
        {
            throw new ApiException(StatusCodes.Status404NotFound, "Registro não encontrado.");
        }

        baseTable.Update(dto.Name, dto.Description);
        await dbContext.SaveChangesAsync(cancellationToken);

        return baseTable.ToResponseDto();
    }

    public static async Task DeleteAsync(
        AppDbContext dbContext,
        int id,
        CancellationToken cancellationToken)
    {
        var baseTable = await dbContext.BaseTables
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        if (baseTable is null)
        {
            throw new ApiException(StatusCodes.Status404NotFound, "Registro não encontrado.");
        }

        dbContext.BaseTables.Remove(baseTable);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public static BaseTable Create(string name, string? description)
    {
        var baseTable = new BaseTable();
        baseTable.Update(name, description);

        return baseTable;
    }

    public void Update(string name, string? description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ApiException(StatusCodes.Status400BadRequest, "O nome é obrigatório.");
        }

        Name = name.Trim();
        Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
