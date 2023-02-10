using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Domain.Tags;
using Microsoft.AspNetCore.Cors;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly TagService _service;

        public TagsController(TagService service)
        {
            _service = service;
        }

        // GET: api/Tags
        [HttpGet]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<IEnumerable<TagDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Tags/(id)
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<TagDto>> GetGetById(String id)
        {
            var t = await _service.GetByIdAsync(new TagId(id));

            if (t == null)
            {
                return NotFound();
            }

            return t;
        }

        // POST: api/Tags
        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<TagDto>> Create(TagDto dto)
        {
            var t = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = t.Id }, t);
        }
        
        // DELETE: api/Tags/(id)
        [HttpDelete("{id}/hard")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<TagDto>> HardDelete(String id)
        {
            try
            {
                var t = await _service.DeleteAsync(new TagId(id));

                if (t == null)
                {
                    return NotFound();
                }

                return Ok(t);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}