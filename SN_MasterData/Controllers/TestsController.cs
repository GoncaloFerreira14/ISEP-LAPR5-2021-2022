using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SocialNetwork.Domain.Shared;
using SocialNetwork.Infrastructure;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly SocialNetworkDbContext _context;

        public TestsController(SocialNetworkDbContext context){
            _context = context;
        }

        public ActionResult<string>deleteAll(){
            _context.Database.EnsureDeleted();
            return Ok ("All data was removed");
        }
    }
}