using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.PedidosLigacao;
using SocialNetwork.Domain.Jogadores;
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
    public class PedidosLigacaoController : ControllerBase
    {
        private readonly PedidoLigacaoService _service;

        public PedidosLigacaoController(PedidoLigacaoService service)
        {
            _service = service;
        }

         // GET: api/PedidosLigacao
        [HttpGet]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<IEnumerable<MostrarPedidoLigacaoDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/PedidosLigacao/(id)
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<MostrarPedidoLigacaoDto>> GetGetById(String id)
        {
            var p = await _service.GetByIdAsync(new PedidoLigacaoId(id));

            if (p == null)
            {
                return NotFound();
            }

            return p;
        }

        // POST: api/PedidosLigacao
        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<PedidoLigacaoDto>> Create(PedidoLigacaoDto dto)
        {
            var p = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = p.Id }, p);
        }

        // DELETE: api/PedidosIntroducao/(id)
        [HttpDelete("{id}/hard")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<PedidoLigacaoDto>> HardDelete(String id)
        {
            try
            {
                var p = await _service.DeleteAsync(new PedidoLigacaoId(id));

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

        // PUT: api/PedidoLigacao/id
        [HttpPut("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<PedidoLigacaoDto>> Update(Guid id, PedidoLigacaoDto dto)
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