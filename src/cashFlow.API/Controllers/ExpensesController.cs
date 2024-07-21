using cashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace cashFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {

        [HttpPost]
        public IActionResult Create([FromBody] RequestCreateExpenseJson request)
        {
            return Created();
        }
    }
}
