using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using SocialNetwork.Controllers;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.Tags;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.PedidosIntroducao;
using SocialNetwork.Domain.PedidosLigacao;
using SocialNetwork.MotorAI;
using SocialNetwork.Domain.Shared;
using Xunit;
using Assert = Xunit.Assert;


namespace Test.Controller
{
    public class PedidosIntroducaoControllerTest
    {
/*        

       [Fact]
        public async Task GetAllAsyncTest()
        {
            var repository = new Mock<IPedidoIntroducaoRepository>();
            repository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<PedidoIntroducao>()));
            
           var tagrepository = new Mock<ITagRepository>();
            tagrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Tag>()));

            var relacaorepository = new Mock<IRelacaoRepository>();
            relacaorepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Relacao>()));

           var jrepository = new Mock<IJogadorRepository>();
            jrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Jogador>()));

            var plrepository = new Mock<IPedidoLigacaoRepository>();
            plrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<PedidoLigacao>()));

            var unitOfWork = new Mock<IUnitOfWork>();

            JogadorService jservice = new JogadorService(unitOfWork.Object, jrepository.Object,tagrepository.Object,relacaorepository.Object,repository.Object,plrepository.Object);
            RelacaoService rService = new RelacaoService(unitOfWork.Object,relacaorepository.Object,tagrepository.Object,jrepository.Object);
            TagService tagService = new TagService(unitOfWork.Object,tagrepository.Object);
             PedidoLigacaoService pedidoLigacaoService = new PedidoLigacaoService(unitOfWork.Object,plrepository.Object,jrepository.Object,relacaorepository.Object,rService);
             MotorAi ai = new MotorAi(tagService);
            JogadoresController controller = new  JogadoresController(jservice,rService, ai);

            PedidoIntroducaoService service = new PedidoIntroducaoService(unitOfWork.Object, repository.Object,jrepository.Object,pedidoLigacaoService);
            PedidosIntroducaoController pcontroller = new  PedidosIntroducaoController(service);

            var result = await controller.GetAll();
            repository.Verify(repo => repo.GetAllAsync(), Times.AtLeastOnce);
        }
         
        [Fact]
        public async Task GetGetGetByIdTest()
        {
            Guid id = new Guid();
            
            var repository = new Mock<IPedidoIntroducaoRepository>();
            repository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<PedidoIntroducao>()));
            
           var tagrepository = new Mock<ITagRepository>();
            tagrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Tag>()));

            var relacaorepository = new Mock<IRelacaoRepository>();
            relacaorepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Relacao>()));

           var jrepository = new Mock<IJogadorRepository>();
            jrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Jogador>()));

            var plrepository = new Mock<IPedidoLigacaoRepository>();
            plrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<PedidoLigacao>()));

            var unitOfWork = new Mock<IUnitOfWork>();

            JogadorService jservice = new JogadorService(unitOfWork.Object, jrepository.Object,tagrepository.Object,relacaorepository.Object,repository.Object,plrepository.Object);
            RelacaoService rService = new RelacaoService(unitOfWork.Object,relacaorepository.Object,tagrepository.Object,jrepository.Object);
            TagService tagService = new TagService(unitOfWork.Object,tagrepository.Object);
             PedidoLigacaoService pedidoLigacaoService = new PedidoLigacaoService(unitOfWork.Object,plrepository.Object,jrepository.Object,relacaorepository.Object,rService);
             MotorAi ai = new MotorAi(tagService);
            JogadoresController controller = new  JogadoresController(jservice,rService, ai);

            PedidoIntroducaoService service = new PedidoIntroducaoService(unitOfWork.Object, repository.Object,jrepository.Object,pedidoLigacaoService);
            PedidosIntroducaoController pcontroller = new  PedidosIntroducaoController(service);

            var result = await pcontroller.GetGetById(id.ToString());

            repository.Verify(repository => repository.GetByIdAsync(It.IsAny<PedidoIntroducaoId>()), Times.AtLeastOnce());
        }
        
        [Fact]
        public async Task CreateTest()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRepoPedidoIntroducao = new Mock<IPedidoIntroducaoRepository>();
            var mockRepoJogador  = new Mock<IJogadorRepository>();

            List<Tag> listTag = new List<Tag>();
            listTag.Add(new Tag("Tag1"));
            listTag.Add(new Tag("Tag2"));
            var jA = new Jogador("Goncalo","g@gmail.com","eu.png","2001-09-10","934997950","glinkedIn","gFacebook","sou lindo","Porto","Portugal",listTag,EstadosHumor.Angry,"oi");
            var jB = new Jogador("Hugo","h@gmail.com","euh.png","2001-09-11","934997951","hlinkedIn","hFacebook","sou lindo","Chaves","Portugal",listTag,EstadosHumor.Disappointed,"oi");
            var jC = new Jogador("Pedro","p@gmail.com","eup.png","2001-09-12","934997953","plinkedIn","pFacebook","sou lindo","Vila de Conde","Portugal",listTag,EstadosHumor.Fearful,"oi");
            PedidoIntroducao p = new PedidoIntroducao(jA,jB,jC,"oi","ola");

            PedidoIntroducaoDto pedidoIntroducaoDto = PedidoIntroducaoMapper.toDto(p);
            var repo = new Mock<IPedidoIntroducaoRepository>();
            repo.Setup(repository => repository.AddAsync(It.IsAny<PedidoIntroducao>())).Returns(Task.FromResult(p));
            
            var tagrepository = new Mock<ITagRepository>();
            tagrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Tag>()));

            var relacaorepository = new Mock<IRelacaoRepository>();
            relacaorepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Relacao>()));

           var jrepository = new Mock<IJogadorRepository>();
            jrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Jogador>()));

            var plrepository = new Mock<IPedidoLigacaoRepository>();
            plrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<PedidoLigacao>()));

            var unitOfWork = new Mock<IUnitOfWork>();

            JogadorService jservice = new JogadorService(unitOfWork.Object, jrepository.Object,tagrepository.Object,relacaorepository.Object,repo.Object,plrepository.Object);
            RelacaoService rService = new RelacaoService(unitOfWork.Object,relacaorepository.Object,tagrepository.Object,jrepository.Object);
            TagService tagService = new TagService(unitOfWork.Object,tagrepository.Object);
             PedidoLigacaoService pedidoLigacaoService = new PedidoLigacaoService(unitOfWork.Object,plrepository.Object,jrepository.Object,relacaorepository.Object,rService);
             MotorAi ai = new MotorAi(tagService);
            JogadoresController controller = new  JogadoresController(jservice,rService, ai);

            PedidoIntroducaoService service = new PedidoIntroducaoService(unitOfWork.Object, repo.Object,jrepository.Object,pedidoLigacaoService);
            PedidosIntroducaoController pcontroller = new  PedidosIntroducaoController(service);

            var result = await pcontroller.Create(pedidoIntroducaoDto);

            repo.Verify(repository => repository.AddAsync(It.IsAny<PedidoIntroducao>()), Times.AtLeastOnce());
            unitOfWork.Verify(unit => unit.CommitAsync(), Times.AtLeastOnce);
        }
        */
    }
}