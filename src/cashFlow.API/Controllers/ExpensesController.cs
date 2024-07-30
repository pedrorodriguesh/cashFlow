using cashFlow.Application.UseCases.Expenses.Create;
using cashFlow.Application.UseCases.Expenses.GetAll;
using cashFlow.Communication.Requests;
using cashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace cashFlow.API.Controllers
{
    // The API project is the front door of the application, here we have the controllers that will receive the requests and call the use cases
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreatedExpenseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult>  Create(
            [FromServices] ICreateExpenseUseCase useCase,
            [FromBody] RequestCreateExpenseJson request)
        {
            // using filterException we don't need to use try catch block here, the filter will catch every exception and return a response with the error
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpensesUseCase useCase)
        {
            var response = await useCase.Execute();
            
            if (response.Expenses.Count != 0) return Ok(response);

            return NoContent();
        }
    }
    
    
}
