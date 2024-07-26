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
        public IActionResult Create(
            [FromServices] ICreateExpenseUseCase useCase,
            [FromBody] RequestCreateExpenseJson request)
        {
            // using filterException we don't need to use try catch block here, the filter will catch every exception and return a response with the error
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
