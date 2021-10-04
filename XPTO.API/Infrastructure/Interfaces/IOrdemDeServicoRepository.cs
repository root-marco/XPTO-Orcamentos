using System.Collections.Generic;
using System.Threading.Tasks;
using XPTO.API.Entities;

namespace XPTO.API.Infrastructure.Interfaces
{
  public interface IOrdemDeServicoRepository
  {
    Task<List<OrdemDeServico>> Index(string searchString);
    Task<OrdemDeServico> Details(long? id);
    Task<OrdemDeServico> Create(OrdemDeServico ordemDeServico);
    Task<OrdemDeServico> Edit(long? id);
    Task<OrdemDeServico> Update(OrdemDeServico ordemDeServico);
    Task<OrdemDeServico> Delete(long? id);
    Task DeleteConfirmed(long id);
    bool OrdemDeServicoExists(long id);
  }
}