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
    public class BooksController : ControllerBase
    {
        public readonly BookStore store;
        public BooksController(BookStore store)
        {
            this.store = store;
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetAvaibleBooks()
        {
            return Ok(store.Books);
        }
    }
}
