using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SocialNetwork.Domain.Shared;
using Microsoft.AspNetCore.Cors;
using SocialNetwork.Domain.Posts;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly  PostService _service;

        public PostsController(PostService service)
        {
            _service = service;
        }

        // GET: api/Posts
        [HttpGet]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Posts/(id)
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<PostDto>> GetGetById(String id)
        {
            var p = await _service.GetByIdAsync(id);

            if (p == null)
            {
                return NotFound();
            }

            return p;
        }

        // PUT: api/Posts/(id)/like
        [HttpPut("{id}/like")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<PostDto>> LikePost(String id)
        {
            var p = await _service.GetByIdAsync(id);

            int likesnr = Int32.Parse(p.Likes);

            likesnr = likesnr + 1;

            p.Likes = ""+likesnr;

            var pFinal = await _service.UpdateAsync(p);

            return pFinal;
        }

        // PUT: api/Posts/(id)/dislike
        [HttpPut("{id}/dislike")]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<PostDto>> DislikePost(String id)
        {
            var p = await _service.GetByIdAsync(id);

            int dislikesnr = Int32.Parse(p.Dislikes);

            dislikesnr = dislikesnr + 1;

            p.Dislikes = ""+dislikesnr;

            var pFinal = await _service.UpdateAsync(p);

            return pFinal;
        }

        // POST: api/Posts
        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task<ActionResult<PostDto>> Create(CriarPostDto dto)
        {
            var p = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = p.id }, p);
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