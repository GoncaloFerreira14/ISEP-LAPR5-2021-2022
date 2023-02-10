using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Relacoes;
using Microsoft.AspNetCore.Cors;
using System.Linq;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class RelacoesController : ControllerBase
    {
        private readonly RelacaoService _service;

        public RelacoesController(RelacaoService service)
        {
            _service = service;
        }

        // GET: api/Relacoes
        [HttpGet]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<IEnumerable<RelacaoDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Relacoes/(id)
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<RelacaoDto>> GetGetById(String id)
        {
            var r = await _service.GetByIdAsync(new RelacaoId(id));

            if (r == null)
            {
                return NotFound();
            }

            return r;
        }

        // POST: api/Relacoes
        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<RelacaoDto>> Create(RelacaoDto dto)
        {
            var r = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = r.Id }, r);
        }
        
        // DELETE: api/Relacoes/(id)
        [HttpDelete("{id}/hard")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<RelacaoDto>> HardDelete(String id)
        {
            try
            {
                var r = await _service.DeleteAsync(new RelacaoId(id));

                if (r == null)
                {
                    return NotFound();
                }

                return Ok(r);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }

        // PUT: api/Relacoes/(id)
        [HttpPut("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<RelacaoDto>> Update(Guid id, RelacaoDto dto)
        {
            if (!(id.ToString().CompareTo(dto.Id) == 0))
            {
                return BadRequest();
            }
            try
            {
                var r = await _service.UpdateAsync(dto);
                
                if (r == null)
                {
                    return NotFound();
                }
                return Ok(r);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }


        // GET: api/Relacoes/(id)
        [HttpGet("leaderboard/fortaleza")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<List<LeaderboardFortalezaDto>>> GetLeaderboardFortaleza()
        {
            var p = await _service.GetAllFortaleza();

            

            if (p == null)
            {
                return NotFound();
            }

            return new ObjectResult(p);
        }

    }
}