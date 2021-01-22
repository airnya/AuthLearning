using AuthLearning.Resource.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthLearning.Resource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly BookStore store;
        private Guid userId => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public OrdersController(BookStore store)
        {
            this.store = store;
        }

        [HttpGet]
        [Authorize( Roles = "User")]
        [Route("")]
        public ActionResult GetOrders()
        {
            if (!store.Orders.ContainsKey(userId))
                return Ok(Enumerable.Empty<Book>());

            var orderedBookIds = store.Orders.Single(o => o.Key == userId).Value;
            var orderedBooks = store.Books.Where(b => orderedBookIds.Contains(b.Id));

            return Ok(orderedBooks);
        }
    }
}
