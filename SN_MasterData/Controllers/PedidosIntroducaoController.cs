using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.PedidosIntroducao;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SocialNetwork.Domain.Shared;
using Microsoft.AspNetCore.Cors;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class PedidosIntroducaoController : ControllerBase
    {
        private readonly PedidoIntroducaoService _service;

        public PedidosIntroducaoController(PedidoIntroducaoService service)
        {
            _service = service;
        }

         // GET: api/PedidosIntroducao
        [HttpGet]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<IEnumerable<MostrarPedidoIntroducaoDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/PedidosIntroducao/(id)
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<MostrarPedidoIntroducaoDto>> GetGetById(String id)
        {
            var p = await _service.GetByIdAsync(new PedidoIntroducaoId(id));

            if (p == null)
            {
                return NotFound();
            }

            return p;
        }

        // GET: api/PedidosIntroducao/JogadorInterm/(jogadorId)
        [HttpGet("JogadorInterm/{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<List<MostrarPedidoIntroducaoDto>>> GetGetbyUserId(string id)
        {
            var list = await _service.GetAllPedidoIntroducaoJogador(id);

            if (list == null)
            {
                return NotFound();
            }

            return list;
        }

        // POST: api/PedidosIntroducao
        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<PedidoIntroducaoDto>> Create(PedidoIntroducaoDto dto)
        {
            var p = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = p.Id }, p);
        }
        
        // DELETE: api/PedidosIntroducao/(id)
        [HttpDelete("{id}/hard")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<PedidoIntroducaoDto>> HardDelete(String id)
        {
            try
            {
                var p = await _service.DeleteAsync(new PedidoIntroducaoId(id));

                if (p == null)
                {
                    return NotFound();
                }

                return Ok(p);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }

        // PUT: api/PedidoIntroducao/id
        [HttpPut("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<PedidoIntroducaoDto>> Update(Guid id, PedidoIntroducaoDto dto)
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
    }
}