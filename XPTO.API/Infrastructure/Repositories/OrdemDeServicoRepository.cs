using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using XPTO.API.Entities;
using XPTO.API.Infrastructure.Context;
using XPTO.API.Infrastructure.Interfaces;
using XPTO.API.Services.Dtos;

namespace XPTO.API.Infrastructure.Repositories
{
  public class OrdemDeServicoRepository : IOrdemDeServicoRepository
  {
    private readonly OrdemDeServicoContext _context;

    public OrdemDeServicoRepository(OrdemDeServicoContext context)
    {
      _context = context;
    }

    public virtual async Task<List<OrdemDeServico>> Index(string searchString)
    {
      var ordens = from m in _context.OrdemDeServico orderby m.DataExecucaoServico descending select m;

      if (!string.IsNullOrEmpty(searchString))
      {
        ordens = ordens.Where(s => s.TituloServico.Contains(searchString)) as IOrderedQueryable<OrdemDeServico>;
      }

      return await ordens.ToListAsync();
    }

    public virtual async Task<OrdemDeServico> Details(long? id)
    {
      return await _context.OrdemDeServico.FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task<OrdemDeServico> Create(OrdemDeServico ordemDeServico)
    {
      _context.Add(ordemDeServico);
      await _context.SaveChangesAsync();

      return ordemDeServico;
    }

    public virtual async Task<OrdemDeServico> Edit(long? id)
    {
      return await _context.OrdemDeServico.FindAsync(id);
    }

    public virtual async Task<OrdemDeServico> Update(OrdemDeServico ordemDeServico)
    {
      _context.Update(ordemDeServico);
      await _context.SaveChangesAsync();

      return ordemDeServico;
    }

    public virtual async Task<OrdemDeServico> Delete(long? id)
    {
      return await _context.OrdemDeServico.FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual async Task DeleteConfirmed(long id)
    {
      var ordemDeServico = await _context.OrdemDeServico.FindAsync(id);

      _context.OrdemDeServico.Remove(ordemDeServico);
      await _context.SaveChangesAsync();
    }

    public bool OrdemDeServicoExists(long id)
    {
      return _context.OrdemDeServico.Any(e => e.Id == id);
    }
  }
}