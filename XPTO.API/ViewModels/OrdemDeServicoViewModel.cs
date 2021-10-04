using System;
using System.ComponentModel.DataAnnotations;

namespace XPTO.API.ViewModels
{
  public class OrdemDeServicoViewModel
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
  }
}