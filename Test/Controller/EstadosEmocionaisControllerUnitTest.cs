using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using SocialNetwork.Controllers;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.Shared;
using Xunit;
using Assert = Xunit.Assert;


namespace Test.Controller
{
    public class EstadosEmocionaisControllerTest
    {
        

       [Fact]
        public async Task GetAllAsyncTest()
        {
            var repository = new Mock<IEstadoEmocionalRepository>();
            repository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<EstadoEmocional>()));
            
            var unitOfWork = new Mock<IUnitOfWork>();

            EstadoEmocionalService service = new EstadoEmocionalService(unitOfWork.Object, repository.Object);
            EstadosEmocionaisController controller = new  EstadosEmocionaisController(service);

            var result = await controller.GetAll();
            repository.Verify(repo => repo.GetAllAsync(), Times.AtLeastOnce);
        }
         
        [Fact]
        public async Task GetGetGetByIdTest()
        {
            Guid id = new Guid();
            
            var repo = new Mock<IEstadoEmocionalRepository>();
            repo.Setup(repository => repository.GetByIdAsync(It.IsAny<EstadoEmocionalId>()));
            
            var unitOfWork = new Mock<IUnitOfWork>();
            
            EstadoEmocionalService service = new EstadoEmocionalService(unitOfWork.Object, repo.Object);
            EstadosEmocionaisController controller = new EstadosEmocionaisController(service);

            var result = await controller.GetGetById(id.ToString());

            repo.Verify(repository => repository.GetByIdAsync(It.IsAny<EstadoEmocionalId>()), Times.AtLeastOnce());
        }
        
        [Fact]
        public async Task CreateTest()
        {
            EstadoEmocional es = new EstadoEmocional(EstadosHumor.Angry);

            EstadoEmocionalDto estadoEmocionalDto = EstadoEmocionalMapper.toDto(es);
            var repo = new Mock<IEstadoEmocionalRepository>();
            repo.Setup(repository => repository.AddAsync(It.IsAny<EstadoEmocional>())).Returns(Task.FromResult(es));
            
            var unitOfWork = new Mock<IUnitOfWork>();
            
            EstadoEmocionalService service = new EstadoEmocionalService(unitOfWork.Object, repo.Object);
            EstadosEmocionaisController controller = new EstadosEmocionaisController(service);

            var result = await controller.Create(estadoEmocionalDto);

            repo.Verify(repository => repository.AddAsync(It.IsAny<EstadoEmocional>()), Times.AtLeastOnce());
            unitOfWork.Verify(unit => unit.CommitAsync(), Times.AtLeastOnce);
        }
        
    }
}