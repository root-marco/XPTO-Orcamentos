using Microsoft.EntityFrameworkCore;
using XPTO.API.Entities;

namespace XPTO.API.Infrastructure.Context
{
  public class OrdemDeServicoContext : DbContext
  {
    public OrdemDeServicoContext(DbContextOptions<OrdemDeServicoContext> options)
      : base(options)
    {
    }

    public DbSet<OrdemDeServico> OrdemDeServico { get; set; }
  }
}