using Xunit;
using SocialNetwork.Domain.EstadosEmocionais;
using System.Collections.Generic;
using SocialNetwork.Domain.Shared;
using Moq;
using System;
namespace Test.Domain.EstadosEmocionais
{

    public class EstadoEmocionalServiceUnitTest
    {
        [Fact]
        public async void GetAllAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoEstadoEmocional = new Mock<IEstadoEmocionalRepository>();


            List<EstadoEmocional> l = new List<EstadoEmocional>();
            var e1 = new EstadoEmocional(EstadosHumor.Angry);
            var e2 = new EstadoEmocional(EstadosHumor.Disappointed);
            l.Add(e1);
            l.Add(e2);

            List<EstadoEmocionalDto> exp = new List<EstadoEmocionalDto>();
            exp.Add(EstadoEmocionalMapper.toDto(e1));
            exp.Add(EstadoEmocionalMapper.toDto(e2));

            mockRepoEstadoEmocional.Setup(repo => repo.GetAllAsync()).ReturnsAsync(l);

            var service = new EstadoEmocionalService(mockUnitOfWork.Object, mockRepoEstadoEmocional.Object);

            List<EstadoEmocionalDto> act = await service.GetAllAsync();

           // Assert.Equal(exp, act);
        }

        [Fact]
        public async void GetByIdAsyncTest()
        {
            var mockRepoEstadosEmocionais = new Mock<IEstadoEmocionalRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var estadoEmocional = new EstadoEmocional(EstadosHumor.Hopeful);
            var exp = EstadoEmocionalMapper.toDto(estadoEmocional);

            mockRepoEstadosEmocionais.Setup(repo => repo.GetByIdAsync(It.IsAny<EstadoEmocionalId>())).ReturnsAsync(estadoEmocional);

            var service = new EstadoEmocionalService(mockUnitOfWork.Object, mockRepoEstadosEmocionais.Object);
            var act = await service.GetByIdAsync(estadoEmocional.Id);
            Assert.Equal(exp.Id, act.Id);
        }

        [Fact]
        public async void AddAsyncTest()
        {
            var mockRepoEstadosEmocionais = new Mock<IEstadoEmocionalRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var estadoEmocional = new EstadoEmocional(EstadosHumor.Hopeful);
            var exp = EstadoEmocionalMapper.toDto(estadoEmocional);

            mockRepoEstadosEmocionais.Setup(repo => repo.AddAsync(estadoEmocional)).ReturnsAsync(estadoEmocional);

            var service = new EstadoEmocionalService(mockUnitOfWork.Object, mockRepoEstadosEmocionais.Object);
            var act = await service.AddAsync(exp);

            Assert.IsType<String>(act.Id);
        }
        [Fact]
        public async void UpdateAsyncTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoEstadoEmocional = new Mock<IEstadoEmocionalRepository>();

            var e = new EstadoEmocional(EstadosHumor.Grateful);
            e.ChangeEstadoHumor(EstadosHumor.Fearful);

            EstadoEmocionalDto exp = EstadoEmocionalMapper.toDto(e);

            mockRepoEstadoEmocional.Setup(repo => repo.GetByIdAsync(It.IsAny<EstadoEmocionalId>())).ReturnsAsync(e);

            var service = new EstadoEmocionalService(mockUnitOfWork.Object, mockRepoEstadoEmocional.Object);

            var dto = new EstadoEmocionalDto { Id = e.Id.AsString(), EstadoHumor = EstadosHumor.Fearful, Data = e.Data.DH.ToString() };
            var act = await service.UpdateAsync(dto);

            Assert.Equal(exp.Id, act.Id);
        }
    }
}