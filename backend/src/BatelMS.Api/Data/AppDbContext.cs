using Microsoft.EntityFrameworkCore;

namespace BatelMS.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
}
