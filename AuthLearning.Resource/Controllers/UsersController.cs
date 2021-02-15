using AuthLearning.Resource.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthLearning.Resource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly UserStore store;
        public UsersController( UserStore store )
        {
            this.store = store;
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetAllUsers()
        {
            return Ok( store.Users );
        }
    }
}
