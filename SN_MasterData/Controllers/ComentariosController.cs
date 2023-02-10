using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SocialNetwork.Domain.Shared;
using Microsoft.AspNetCore.Cors;
using SocialNetwork.Domain.Comentarios;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly  ComentarioService _service;

        public ComentariosController(ComentarioService service)
        {
            _service = service;
        }

        // GET: api/Comentarios
        [HttpGet]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<List<ComentarioDto>>> GetAllComentarios()
        {
            var p = await _service.GetAllComentarios();

            if (p == null)
            {
                return NotFound();
            }

            return p;
        }

        // GET: api/Comentarios/(id)
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<List<ComentarioDto>>> GetGetComentariosById(String id)
        {
            var p = await _service.GetComentariosByPostIdAsync(id);

            if (p == null)
            {
                return NotFound();
            }

            return p;
        }

        // POST: api/Comentarios
        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<ComentarioDto>> Create(ComentarioDto dto)
        {
            var p = await _service.addAsync(dto);

            return p;
        }
        
        /*

        // GET: api/Posts/(id)
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<PostDto>> GetGetById(string id)
        {
            var p = await _service.GetByIdAsync(new PostId(id));

            if (p == null)
            {
                return NotFound();
            }

            return p;
        }

        */
    }
}