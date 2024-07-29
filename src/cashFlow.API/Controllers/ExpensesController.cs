using cashFlow.Application.UseCases.Expenses.Create;
using cashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace cashFlow.API.Controllers
{
    // The API project is the front door of the application, here we have the controllers that will receive the requests and call the use cases
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult>  Create(
            [FromServices] ICreateExpenseUseCase useCase,
            [FromBody] RequestCreateExpenseJson request)
        {
            // using filterException we don't need to use try catch block here, the filter will catch every exception and return a response with the error
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
