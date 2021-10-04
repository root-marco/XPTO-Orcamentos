using AutoMapper;
using XPTO.API.Entities;
using XPTO.API.Services.Dtos;
using XPTO.API.ViewModels;

namespace XPTO.UnitTests.Configurations
{
  public class AutoMapperConfig
  {
    public static IMapper GetConfiguration()
    {
      var autoMapperConfig = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<OrdemDeServico, OrdemDeServicoDto>().ReverseMap();
        cfg.CreateMap<OrdemDeServicoViewModel, OrdemDeServicoDto>().ReverseMap();
      });

      return autoMapperConfig.CreateMapper();
    }
  }
}