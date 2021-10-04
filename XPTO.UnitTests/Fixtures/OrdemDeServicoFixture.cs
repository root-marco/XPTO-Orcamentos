using System;
using System.Collections.Generic;
using Bogus;
using Bogus.DataSets;
using XPTO.API.Entities;
using XPTO.API.Services.Dtos;

namespace XPTO.UnitTests.Fixtures
{
  public class OrdemDeServicoFixture
  {
    public static OrdemDeServico CreateValidOrdemDeServico()
    {
      return new OrdemDeServico
      {
        NumeroOrdemDeServico = 10,
        TituloServico = "Servico 1",
        CnpjCliente = "30.367.648/0001-61",
        NomeCliente = "Gabriel Enrico Fogaça",
        CpfPrestadorServico = "006.337.027-14",
        NomePrestadorServico = "Filipe Vicente Fogaça",
        ValorServico = "R$ 1200",
        DataExecucaoServico = new DateTime(2021, 10, 10)
      };
    }

    public static List<OrdemDeServico> CreateListValidOrdemDeServico(int limit = 5)
    {
      var list = new List<OrdemDeServico>();

      for (int i = 0; i < limit; i++)
      {
        list.Add(CreateValidOrdemDeServico());
      }

      return list;
    }

    public static OrdemDeServicoDto CreateValidOrdemDeServicoDto(bool newId = false)
    {
      return new OrdemDeServicoDto
      {
        NumeroOrdemDeServico = 15,
        TituloServico = "Servico 2",
        CnpjCliente = "68.221.352/0001-00",
        NomeCliente = "Marina Nina de Paula",
        CpfPrestadorServico = "829.203.834-50",
        NomePrestadorServico = "Giovanni Gustavo de Paula",
        ValorServico = "R$ 600",
        DataExecucaoServico = new DateTime(2021, 10, 09)
      };
    }

    public static OrdemDeServicoDto CreateInvalidOrdemDeServicoDto()
    {
      return new OrdemDeServicoDto
      {
        NumeroOrdemDeServico = 1,
        TituloServico = "",
        CnpjCliente = "",
        NomeCliente = "",
        CpfPrestadorServico = "",
        NomePrestadorServico = "",
        ValorServico = "0",
        DataExecucaoServico = new DateTime(2015, 10, 10)
      };
    }
  }
}