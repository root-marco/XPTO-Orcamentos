using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using FluentAssertions;
using Moq;
using XPTO.API.Entities;
using XPTO.API.Infrastructure.Interfaces;
using XPTO.API.Services.Dtos;
using XPTO.API.Services.Interfaces;
using XPTO.API.Services.Services;
using XPTO.UnitTests.Configurations;
using XPTO.UnitTests.Fixtures;
using Xunit;

namespace XPTO.UnitTests.Projects.Services
{
  public class OrdemDeServicoServiceTest
  {
    private readonly IOrdemDeServicoService _sut;
    private readonly IMapper _mapper;
    private readonly Mock<IOrdemDeServicoRepository> _ordemDeServicoRepositoryMock;

    public OrdemDeServicoServiceTest()
    {
      _mapper = AutoMapperConfig.GetConfiguration();
      _ordemDeServicoRepositoryMock = new Mock<IOrdemDeServicoRepository>();

      _sut = new OrdemDeServicoService(
        repository: _ordemDeServicoRepositoryMock.Object,
        mapper: _mapper
      );
    }

    # region INDEX

    [Fact]
    public async Task Index_ReturnsDtoList()
    {
      // Arrange
      var ordensDeServicos = OrdemDeServicoFixture.CreateListValidOrdemDeServico();

      _ordemDeServicoRepositoryMock.Setup(x => x.Index(""))
        .ReturnsAsync(() => ordensDeServicos);

      // Act
      var result = await _sut.Index("");

      // Assert
      result.Should().BeEquivalentTo(_mapper.Map<List<OrdemDeServicoDto>>(ordensDeServicos));
    }

    [Fact]
    public async Task Index_ReturnsEmptyList()
    {
      // Arrange
      _ordemDeServicoRepositoryMock.Setup(x => x.Index(""))
        .ReturnsAsync(() => null);

      // Act
      var result = await _sut.Index("");

      // Assert
      result.Should().BeEmpty();
    }

    #endregion

    # region CREATE

    [Fact]
    public async Task Create_ReturnsDtoList()
    {
      // Arrange
      var ordemDeServicoToCreate = OrdemDeServicoFixture.CreateValidOrdemDeServicoDto();
      var ordemDeServicoCreated = _mapper.Map<OrdemDeServico>(ordemDeServicoToCreate);

      _ordemDeServicoRepositoryMock.Setup(x => x.Create(It.IsAny<OrdemDeServico>()))
        .ReturnsAsync(() => ordemDeServicoCreated);

      // Act
      var result = await _sut.Create(ordemDeServicoToCreate);

      // Assert
      result.Should().BeEquivalentTo(_mapper.Map<OrdemDeServicoDto>(ordemDeServicoCreated));
    }

    [Fact]
    public void Create_ReturnsException()
    {
      // Arrange
      var ordemDeServicoToCreate = OrdemDeServicoFixture.CreateValidOrdemDeServicoDto();
      var ordemDeServicoCreated = _mapper.Map<OrdemDeServico>(ordemDeServicoToCreate);

      _ordemDeServicoRepositoryMock.Setup(x => x.Create(It.IsAny<OrdemDeServico>()))
        .ReturnsAsync(() => ordemDeServicoCreated);

      // Act
      Func<Task<OrdemDeServicoDto>> act = async () =>
      {
        return await _sut.Create(ordemDeServicoToCreate);
      };
    
      // Assert
      act.Should().ThrowAsync<Exception>();
    }

    #endregion

    # region DETAILS

    [Fact]
    public async Task Details_RetunsDto()
    {
      // Arrange
      var id = new Randomizer().Long(0, 2000);
      var ordemDeServico = OrdemDeServicoFixture.CreateValidOrdemDeServico();

      _ordemDeServicoRepositoryMock.Setup(x => x.Details(id))
        .ReturnsAsync(() => ordemDeServico);

      // Act
      var result = await _sut.Details(id);

      // Assert
      result.Should().BeEquivalentTo(_mapper.Map<OrdemDeServicoDto>(ordemDeServico));
    }

    # endregion

  }
}