using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.EstadosEmocionais;
using Microsoft.AspNetCore.Cors;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class EstadosEmocionaisController : ControllerBase
    {
        private readonly EstadoEmocionalService _service;

        public EstadosEmocionaisController(EstadoEmocionalService service)
        {
            _service = service;
        }

        // GET: api/EstadosEmocionais
        [HttpGet]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<IEnumerable<EstadoEmocionalDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/EstadosEmocionais/(id)
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<EstadoEmocionalDto>> GetGetById(String id)
        {
            var e = await _service.GetByIdAsync(new EstadoEmocionalId(id));

            if (e == null)
            {
                return NotFound();
            }

            return e;
        }
        // POST: api/EstadosEmocionais
        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<EstadoEmocionalDto>> Create(EstadoEmocionalDto dto)
        {
            var e = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = e.Id }, e);
        }
        
         // PUT: api/Categories/5
        [HttpPut("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<EstadoEmocionalDto>> Update(Guid id, EstadoEmocionalDto dto)
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
        
        // DELETE: api/EstadosEmocionais/(id)
        [HttpDelete("{id}/hard")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<EstadoEmocionalDto>> HardDelete(String id)
        {
            try
            {
                var e = await _service.DeleteAsync(new EstadoEmocionalId(id));

                if (e == null)
                {
                    return NotFound();
                }

                return Ok(e);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}