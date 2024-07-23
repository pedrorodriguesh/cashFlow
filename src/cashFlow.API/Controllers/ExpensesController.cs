using cashFlow.API.Filters;
using cashFlow.Application.UseCases.Expenses.Create;
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
            // using filterException we dont need to use try catch block here, the filter will catch every exceptions and return a response with the error
            var useCase = new CreateExpenseUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
