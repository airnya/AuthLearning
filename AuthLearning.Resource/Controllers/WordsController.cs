using AuthLearning.Resource.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthLearning.Resource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly FaithDetailContext _db;
        public WordsController(FaithDetailContext db )
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetWords()
        {
            return Ok( _db.Words );
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create( WordDetail word)
        {
            _db.Words.Add( word );
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
