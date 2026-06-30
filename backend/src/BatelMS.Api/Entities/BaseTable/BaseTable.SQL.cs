using BatelMS.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace BatelMS.Api.Entities;

public partial class BaseTable
{
    public static class Sql
    {
        public const string RebuildSearchProcedure = "call sp_rebuild_base_table_search()";
    }

    public static async Task<int> RebuildSearchAsync(
        AppDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Database.ExecuteSqlRawAsync(Sql.RebuildSearchProcedure, cancellationToken);
    }
}
