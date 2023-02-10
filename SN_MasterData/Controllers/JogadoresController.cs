using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Jogadores;
using SocialNetwork.Domain.Relacoes;
using SocialNetwork.Domain.EstadosEmocionais;
using SocialNetwork.Domain.PedidosIntroducao;
using SocialNetwork.MotorAI;
using Microsoft.AspNetCore.Cors;
using System.Linq;
namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private readonly JogadorService _service;
         private readonly RelacaoService _rservice;
         private readonly MotorAi _ai;

        public JogadoresController(JogadorService service, RelacaoService rservice, MotorAi ai )
        {
            _service = service;
            _rservice = rservice;
            _ai = ai;
        }

        // GET: api/Jogadores
        [HttpGet]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<IEnumerable<MostrarJogadorDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Jogadores/(id)
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<MostrarJogadorDto>> GetGetById(String id)
        {
            var j = await _service.GetByIdAsync(new JogadorId(id));

            if (j == null)
            {
                return NotFound();
            }

            return j;
        }

        // GET: api/Jogadores/email/(email)
        [HttpGet("email/{email}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<MostrarJogadorDto>> GetByEmail(String email)
        {
            var j = await _service.GetByEmail(email);

            if (j == null)
            {
                return NotFound();
            }

            return j;
        }


         // GET: api/Jogadores/motorAi
        [HttpGet("motorAi")]
        [EnableCors("AllowAll")]
        public async Task<string> GetMotorAi()
        {
            List<MostrarJogadorDto> jogadores = await _service.GetAllAsync();
            
            List<RelacaoDto> relacoes = await _rservice.GetAllAsync();

            return await _ai.boot(jogadores, relacoes);
        }

         // GET: api/Jogadores/tamhanhorede
        [HttpGet("tamanhorede/{id}/{n}")]
        [EnableCors("AllowAll")]
        public async Task<string> GetTamanhoredeMotorAi(String id, int n)
        {
            MostrarJogadorDto jogador = await _service.GetByIdAsync(new JogadorId(id));
            String s =  await _ai.tamanhoRede(jogador, n);
            return  s;
        }

        // GET: api/Jogadores/tamhanhorede
        [HttpGet("caminhoCurto/{orig}/{dest}")]
        [EnableCors("AllowAll")]
        public async Task<string> GetCaminhoCurtoMotorAi(String orig, String dest)
        {
            String s =  await _ai.caminhoMaisCurto(orig,dest);
            return  s;
        }

        // GET: api/Jogadores/caminhoSeguro
        [HttpGet("caminhoSeguro/{orig}/{dest}/{limite}")]
        [EnableCors("AllowAll")]
        public async Task<string> GetCaminhoSeguroMotorAi(String orig, String dest,int limite)
        {
            String s =  await _ai.caminhoMaisSeguro(orig,dest,limite);
            return  s;
        }

        // POST: api/Jogadores
        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<JogadorDto>> Create(JogadorDto dto)
        {
            var j = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = j.Id }, j);
        }
        
        // DELETE: api/Jogadores/(id)
        [HttpDelete("{id}/hard")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<JogadorDto>> HardDelete(String id)
        {
            try
            {
                var j = await _service.DeleteAsync(new JogadorId(id));

                if (j == null)
                {
                    return NotFound();
                }

                return Ok(j);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }

        // PUT: api/Jogadores/id
        [HttpPut("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<JogadorDto>> Update(Guid id, JogadorDto dto)
        {
            if (!(id.ToString().CompareTo(dto.Id) == 0))
            {
                return BadRequest();
            }
            try
            {
                var j = await _service.UpdateAsync(dto);
                
                if (j == null)
                {
                    return NotFound();
                }
                return Ok(j);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        // GET: api/Jogadores/(id)/relacoes
        [HttpGet("{id}/relacoes")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<RelacaoDto>> GetAllRelacoesJogador(String id)
        {
            var j = await _service.GetAllRelacoesJogador(new JogadorId(id));

            if (j == null)
            {
                return NotFound();
            }

            return Ok(j);
        }

         // GET: api/Jogadores/(id)/relacoesAmigo
        [HttpGet("{id}/relacoesAmigo")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<RelacaoDto>> GetAllRelacoesJogadorAmigo(String id)
        {
            var j = await _service.GetAllRelacoesJogadorAmigo(new JogadorId(id));

            if (j == null)
            {
                return NotFound();
            }

            return Ok(j);
        }

        // GET: api/Jogadores/(id)/estadosEmocionais
        [HttpGet("{id}/estadosEmocionais")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<MostrarEstadoDto>>  GetEstadoHumorByJogadorId(String id)
        {
            var j = await _service. GetEstadoHumorByJogadorId(new JogadorId(id));

            if (j == null)
            {
                return NotFound();
            }

            return Ok(j);
        }

         // GET: api/Jogadores/login/email/password
        [HttpGet("login/{email}/{password}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<Jogador>> ValidarLogin(String email, String password)
        {
            var j = await _service.ValidarLogin(new Email(email), new Texto(password));

            if (j == null)
            {
                return NotFound();
            }

            return Ok(j);
        }

        //UC7 PROVISORIOOOOOO
        // GET: api/Jogadores/(id)/relacoes/(n)
        [HttpGet("{id}/relacoes/{n}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<List<KeyValuePair<int,RelacaoDto>>>> GetAllRelacoesPorNivelJogador(String id, int n)
        {
            var list = await _service.GetAllRelacoesPorNivelJogador(new JogadorId(id), n);

            if (list == null)
            {
                return NotFound();
            }

            return list;
        }

        // GET: api/Jogadores/(id)/jogadoresPorTagComuns
        [HttpGet("{id}/jogadoresPorTagComuns")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<List<JogadorDto>>> GetGetAllJogadoresByCommonTags(String id)
        {
            var p = await _service.GetAllJogadoresByCommonTags(new JogadorId(id));

            if (p == null)
            {
                return NotFound();
            }

            return p;
        }

        // GET: api/Jogadores/(id)/pedidosintroducao
        [HttpGet("{id}/pedidosintroducao")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<List<PedidoIntroducao>>> GetAllPedidosIntroducao(String id)
        {
            var j = await _service.GetAllPedidosIntroducao(new JogadorId(id));

            if (j == null)
            {
                return NotFound();
            }

            return Ok(j);
        }

        // GET: api/Jogadores/(id)/pedidosligacao
        [HttpGet("{id}/pedidosligacao")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<List<PedidoIntroducao>>> GetAllPedidosLigacao(String id)
        {
            var j = await _service.GetAllPedidosLigacao(new JogadorId(id));

            if (j == null)
            {
                return NotFound();
            }

            return Ok(j);
        }

         [HttpGet("{id}/Pesquisar/{pesquisa}")]
         [EnableCors("AllowAll")]
        public async Task<ActionResult<List<JogadorDto>>> PesquisarJogadores(String id, String pesquisa)
        {
            var jogadores = await _service.PesquisarJogadores(id,pesquisa);

            if (jogadores == null)
            {
                return NotFound();
            }

            return jogadores;
        }


        // GET: api/Jogadores/(id)
        [HttpGet("leaderboard/dimensao")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<List<LeaderboardDimensaoDto>>> GetLeaderboardDimensao()
        {
            var p = await _service.GetAllDimensao();

            if (p == null)
            {
                return NotFound();
            }

            return new ObjectResult(p);
        }
        
    }
}