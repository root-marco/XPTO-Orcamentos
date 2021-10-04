using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XPTO.API.ViewModels;
using XPTO.API.Services.Dtos;
using XPTO.API.Services.Interfaces;

namespace XPTO.API.Controllers
{
  [Controller]
  public class OrdemDeServicoController : Controller
  {
    private readonly IOrdemDeServicoService _service;
    private readonly IMapper _mapper;

    public OrdemDeServicoController(IOrdemDeServicoService service, IMapper mapper)
    {
      _mapper = mapper;
      _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string searchString)
    {
      var ordensDeServicosDtos = await _service.Index(searchString);

      var ordemDeServicoDto = new OrdemDeServicoDto
      {
        Ordens = ordensDeServicosDtos
      };

      return View(ordemDeServicoDto);
    }

    [HttpGet]
    public async Task<IActionResult> Details(long? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var ordemDeServicoDto = await _service.Details(id);

      if (ordemDeServicoDto == null)
      {
        return NotFound();
      }

      return View(ordemDeServicoDto);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind] OrdemDeServicoViewModel ordemDeServicoViewModel)
    {

      if (ModelState.IsValid)
      {
        var ordemDeServicoDto = _mapper.Map<OrdemDeServicoDto>(ordemDeServicoViewModel);

        await _service.Create(ordemDeServicoDto);

        return RedirectToAction(nameof(Index));
      }

      return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var ordemDeServicoDto = await _service.Edit(id);

      if (ordemDeServicoDto == null)
      {
        return NotFound();
      }

      return View(ordemDeServicoDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind] OrdemDeServicoViewModel ordemDeServicoViewModel)
    {
      if (id != ordemDeServicoViewModel.Id)
      {
        return NotFound();
      }

      var ordemDeServicoDto = _mapper.Map<OrdemDeServicoDto>(ordemDeServicoViewModel);

      if (ModelState.IsValid)
      {
        try
        {
          await _service.Update(ordemDeServicoDto);
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!OrdemDeServicoExists(ordemDeServicoViewModel.Id))
          {
            return NotFound();
          }

          throw;
        }

        return RedirectToAction(nameof(Index));
      }

      return View();
    }

    public async Task<IActionResult> Delete(long? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var ordemDeServicoDto = await _service.Delete(id);

      if (ordemDeServicoDto == null)
      {
        return NotFound();
      }

      return View(ordemDeServicoDto);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
      await _service.DeleteConfirmed(id);

      return RedirectToAction(nameof(Index));
    }

    private bool OrdemDeServicoExists(long id)
    {
      return _service.OrdemDeServicoExists(id);
    }
  }
}