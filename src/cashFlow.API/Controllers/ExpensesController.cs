using cashFlow.Application.UseCases.Expenses.Create;
using cashFlow.Application.UseCases.Expenses.DeleteExpense;
using cashFlow.Application.UseCases.Expenses.GetAll;
using cashFlow.Application.UseCases.Expenses.GetExpenseById;
using cashFlow.Application.UseCases.Expenses.UpdateExpense;
using cashFlow.Communication.Requests;
using cashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create([FromServices] ICreateExpenseUseCase useCase,
            [FromBody] RequestExpenseJson request)
        {
            // using filterException we don't need to use try catch block here, the filter will catch every exception and return a response with the error
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpensesUseCase useCase) // FromServices we receive the useCase from the dependency injection
        {
            var response = await useCase.Execute();

            if (response.Expenses.Count != 0) return Ok(response);

            return NoContent();
        }

        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseExpenseJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExpenseById([FromRoute] long id,
            [FromServices] IGetExpenseByIdUseCase useCase)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:long}")]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteExpense([FromRoute] long id,
            [FromServices] IDeleteExpenseUseCase useCase)
        {
            await useCase.Execute(id);

            return NoContent();
        }

        [HttpPut]
        [Route("{id:long}")]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateExpense([FromRoute] long id,
            [FromServices] IUpdateExpenseUseCase useCase, [FromBody] RequestExpenseJson request)
        {
            await useCase.Execute(id, request);

            return NoContent();
        }
    }
}
