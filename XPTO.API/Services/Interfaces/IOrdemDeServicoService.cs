using System.Collections.Generic;
using System.Threading.Tasks;
using XPTO.API.Entities;
using XPTO.API.Services.Dtos;

namespace XPTO.API.Services.Interfaces
{
  public interface IOrdemDeServicoService
  {
    Task<List<OrdemDeServicoDto>> Index(string searchString);
    Task<OrdemDeServicoDto> Details(long? id);
    Task<OrdemDeServicoDto> Create(OrdemDeServicoDto ordemDeServicoDto);
    Task<OrdemDeServicoDto> Edit(long? id);
    Task<OrdemDeServicoDto> Update(OrdemDeServicoDto ordemDeServicoDto);
    Task<OrdemDeServicoDto> Delete(long? id);
    Task DeleteConfirmed(long id);
    bool OrdemDeServicoExists(long id);
  }
}