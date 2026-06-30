using BatelMS.Api.Common;
using BatelMS.Api.Data;
using BatelMS.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BatelMS.Api.Controllers;

[ApiController]
[Route("api/base-table")]
public class BaseTableController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IReadOnlyList<BaseTable.ResponseDto>>>> GetAll(
        CancellationToken cancellationToken)
    {
        try
        {
            var payload = await BaseTable.GetAllAsync(dbContext, cancellationToken);

            return Ok(ApiResponse<IReadOnlyList<BaseTable.ResponseDto>>.Ok(payload));
        }
        catch (ApiException exception)
        {
            return HandleApiException(exception);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<BaseTable.ResponseDto>>> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        try
        {
            var payload = await BaseTable.GetByIdAsync(dbContext, id, cancellationToken);

            return Ok(ApiResponse<BaseTable.ResponseDto>.Ok(payload));
        }
        catch (ApiException exception)
        {
            return HandleApiException(exception);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<BaseTable.ResponseDto>>> Create(
        [FromBody] BaseTable.CreateDto dto,
        CancellationToken cancellationToken)
    {
        try
        {
            var payload = await BaseTable.CreateAsync(dbContext, dto, cancellationToken);
            var response = ApiResponse<BaseTable.ResponseDto>.Created(payload);

            return CreatedAtAction(nameof(GetById), new { id = payload.Id }, response);
        }
        catch (ApiException exception)
        {
            return HandleApiException(exception);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ApiResponse<BaseTable.ResponseDto>>> Update(
        int id,
        [FromBody] BaseTable.UpdateDto dto,
        CancellationToken cancellationToken)
    {
        try
        {
            var payload = await BaseTable.UpdateAsync(dbContext, id, dto, cancellationToken);

            return Ok(ApiResponse<BaseTable.ResponseDto>.Ok(payload, "Registro atualizado com sucesso."));
        }
        catch (ApiException exception)
        {
            return HandleApiException(exception);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse<object?>>> Delete(
        int id,
        CancellationToken cancellationToken)
    {
        try
        {
            await BaseTable.DeleteAsync(dbContext, id, cancellationToken);

            return Ok(ApiResponse<object?>.Ok(null, "Registro excluído com sucesso."));
        }
        catch (ApiException exception)
        {
            return HandleApiException(exception);
        }
    }

    [HttpPost("rebuild-search")]
    public async Task<ActionResult<ApiResponse<object>>> RebuildSearch(
        CancellationToken cancellationToken)
    {
        try
        {
            var affectedRows = await BaseTable.RebuildSearchAsync(dbContext, cancellationToken);
            var payload = new { affectedRows };

            return Ok(ApiResponse<object>.Ok(payload, "Procedure executada com sucesso."));
        }
        catch (ApiException exception)
        {
            return HandleApiException(exception);
        }
    }

    private ObjectResult HandleApiException(ApiException exception)
    {
        return StatusCode(exception.StatusCode, exception.ToResponse());
    }
}
