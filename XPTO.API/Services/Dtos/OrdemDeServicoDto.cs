using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XPTO.API.Services.Dtos
{
  public class OrdemDeServicoDto
  {
    public long Id { get; set; }
    [Required]
    public long NumeroOrdemDeServico { get; set; }
    [Required]
    public string TituloServico { get; set; }
    [Required]
    public string CnpjCliente { get; set; }
    [Required]
    public string NomeCliente { get; set; }
    [Required]
    public string CpfPrestadorServico { get; set; }
    [Required]
    public string NomePrestadorServico { get; set; }
    [Required]
    public decimal ValorServico { get; set; }
    [Required]
    public DateTime DataExecucaoServico { get; set; }
    [Required]
    public string SearchString { get; set; }
    public List<OrdemDeServicoDto> Ordens { get; set; }

    public OrdemDeServicoDto()
    {
    }
  }
}