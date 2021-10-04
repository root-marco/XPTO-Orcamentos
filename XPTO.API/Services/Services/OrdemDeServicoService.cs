using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using XPTO.API.Entities;
using XPTO.API.Infrastructure.Interfaces;
using XPTO.API.Services.Dtos;
using XPTO.API.Services.Interfaces;

namespace XPTO.API.Services.Services
{
  public class OrdemDeServicoService : IOrdemDeServicoService
  {
    private readonly IMapper _mapper;
    private readonly IOrdemDeServicoRepository _repository;

    public OrdemDeServicoService(IOrdemDeServicoRepository repository, IMapper mapper)
    {
      _mapper = mapper;
      _repository = repository;
    }

    public async Task<List<OrdemDeServicoDto>> Index(string searchString)
    {
      var ordensDeServicos = await _repository.Index(searchString);
      
      return _mapper.Map<List<OrdemDeServicoDto>>(ordensDeServicos);
    }

    public async Task<OrdemDeServicoDto> Details(long? id)
    {
      var ordemDeServico = await _repository.Details(id);

      return _mapper.Map<OrdemDeServicoDto>(ordemDeServico);
    }

    public async Task<OrdemDeServicoDto> Create(OrdemDeServicoDto ordemDeServicoDto)
    {
      var ordemDeServico = _mapper.Map<OrdemDeServico>(ordemDeServicoDto);
      
      var ordemDeServicoCriado = await _repository.Create(ordemDeServico);

      return _mapper.Map<OrdemDeServicoDto>(ordemDeServicoCriado);
    }

    public async Task<OrdemDeServicoDto> Edit(long? id)
    {
      var ordemDeServicoEditado = await _repository.Edit(id);

      return _mapper.Map<OrdemDeServicoDto>(ordemDeServicoEditado);
    }

    public async Task<OrdemDeServicoDto> Update(OrdemDeServicoDto ordemDeServicoDto)
    {
      var ordemDeServico = _mapper.Map<OrdemDeServico>(ordemDeServicoDto);
      
      var ordemDeServicoEditado = await _repository.Update(ordemDeServico);

      return _mapper.Map<OrdemDeServicoDto>(ordemDeServicoEditado);
    }

    public async Task<OrdemDeServicoDto> Delete(long? id)
    {
      var ordemDeServico = await _repository.Delete(id);

      var ordemDeServicoDto = _mapper.Map<OrdemDeServicoDto>(ordemDeServico);
      
      return ordemDeServicoDto;
    }

    public async Task DeleteConfirmed(long id)
    {
      await _repository.DeleteConfirmed(id);
    }

    public bool OrdemDeServicoExists(long id)
    {
      return _repository.OrdemDeServicoExists(id);
    }
  }
}