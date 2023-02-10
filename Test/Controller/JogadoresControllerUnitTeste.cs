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
using SocialNetwork.Domain.Shared;
using SocialNetwork.MotorAI;
using Xunit;
using Assert = Xunit.Assert;


namespace Test.Controller
{
    public class JogadoresControllerTest
    {
        public const string NOME = "Hugo";
        public const string EMAIL = "hv@gmail.com";
        public const string AVATAR = "eu.png";
        public const string DATANASCIMENTO = "10/08/2001";
        public const string NUMEROTELEFONE = "934567899";
        public const string URLLINKEDIN = "linkedin.com";
        public const string URLFACEBOOK = "fb.com";
        public const string DESCRICAOBREVE = "eu sou amigo";
        public const string CIDADE = "Chaves";
        public const string PAIS = "Portugal";
         public const string PASS = "Portugal";

         public  List<Tag> ListaTags = new List<Tag>();

       [Fact]
        public async Task GetAllAsyncTest()
        {
            var jrepository = new Mock<IJogadorRepository>();
            jrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Jogador>()));

            var tagrepository = new Mock<ITagRepository>();
            tagrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Tag>()));

            var relacaorepository = new Mock<IRelacaoRepository>();
            relacaorepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Relacao>()));

            var pirepository = new Mock<IPedidoIntroducaoRepository>();
            pirepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<PedidoIntroducao>()));

            var plrepository = new Mock<IPedidoLigacaoRepository>();
            plrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<PedidoLigacao>()));

            var unitOfWork = new Mock<IUnitOfWork>();

            JogadorService jservice = new JogadorService(unitOfWork.Object, jrepository.Object,tagrepository.Object,relacaorepository.Object,pirepository.Object,plrepository.Object);
            RelacaoService rService = new RelacaoService(unitOfWork.Object,relacaorepository.Object,tagrepository.Object,jrepository.Object);
            TagService tagService = new TagService(unitOfWork.Object,tagrepository.Object);
             MotorAi ai = new MotorAi(tagService);
            JogadoresController controller = new  JogadoresController(jservice,rService, ai);
            
            var result = await controller.GetAll();
            jrepository.Verify(repo => repo.GetAllAsync(), Times.AtLeastOnce);
        }
         
        [Fact]
        public async Task GetGetGetByIdTest()
        {
            Guid id = new Guid();
            
            var repo = new Mock<IJogadorRepository>();
            repo.Setup(repository => repository.GetByIdAsync(It.IsAny<JogadorId>()));
            
             var tagrepository = new Mock<ITagRepository>();
            tagrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Tag>()));

            var relacaorepository = new Mock<IRelacaoRepository>();
            relacaorepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Relacao>()));

            var pirepository = new Mock<IPedidoIntroducaoRepository>();
            pirepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<PedidoIntroducao>()));

            var plrepository = new Mock<IPedidoLigacaoRepository>();
            plrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<PedidoLigacao>()));

            var unitOfWork = new Mock<IUnitOfWork>();

            JogadorService jservice = new JogadorService(unitOfWork.Object, repo.Object,tagrepository.Object,relacaorepository.Object,pirepository.Object,plrepository.Object);
            RelacaoService rService = new RelacaoService(unitOfWork.Object,relacaorepository.Object,tagrepository.Object,repo.Object);
            TagService tagService = new TagService(unitOfWork.Object,tagrepository.Object);
             MotorAi ai = new MotorAi(tagService);
            JogadoresController controller = new  JogadoresController(jservice,rService, ai);

            var result = await controller.GetGetById(id.ToString());

            repo.Verify(repository => repository.GetByIdAsync(It.IsAny<JogadorId>()), Times.AtLeastOnce());
        }
        
        [Fact]
        public async Task CreateTest()
        {
            var j = new Jogador(NOME,EMAIL,AVATAR,DATANASCIMENTO,NUMEROTELEFONE,URLLINKEDIN,URLFACEBOOK,DESCRICAOBREVE,CIDADE,PAIS,ListaTags,SocialNetwork.Domain.EstadosEmocionais.EstadosHumor.Angry,PASS);

            JogadorDto jogadorDto = JogadorMapper.toDto(j);
            var repo = new Mock<IJogadorRepository>();
            repo.Setup(repository => repository.AddAsync(It.IsAny<Jogador>())).Returns(Task.FromResult(j));
            
            var unitOfWork = new Mock<IUnitOfWork>();
            
             var tagrepository = new Mock<ITagRepository>();
            tagrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Tag>()));

            var relacaorepository = new Mock<IRelacaoRepository>();
            relacaorepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<Relacao>()));

            var pirepository = new Mock<IPedidoIntroducaoRepository>();
            pirepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<PedidoIntroducao>()));

            var plrepository = new Mock<IPedidoLigacaoRepository>();
            plrepository.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(new List<PedidoLigacao>()));

            JogadorService jservice = new JogadorService(unitOfWork.Object, repo.Object,tagrepository.Object,relacaorepository.Object,pirepository.Object,plrepository.Object);
            RelacaoService rService = new RelacaoService(unitOfWork.Object,relacaorepository.Object,tagrepository.Object,repo.Object);
            TagService tagService = new TagService(unitOfWork.Object,tagrepository.Object);
             MotorAi ai = new MotorAi(tagService);
            JogadoresController controller = new  JogadoresController(jservice,rService, ai);

            var result = await controller.Create(jogadorDto);

            repo.Verify(repository => repository.AddAsync(It.IsAny<Jogador>()), Times.AtLeastOnce());
            unitOfWork.Verify(unit => unit.CommitAsync(), Times.AtLeastOnce);
        }
        
    }
}