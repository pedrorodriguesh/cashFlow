using cashFlow.Application.UseCases.Expenses.Create;
using cashFlow.Communication.Requests;
using cashFlow.Communication.Responses;
using cashFlow.Exception.ExceptionsBase;
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
            try
            {
                var useCase = new CreateExpenseUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ErrorOnValidationException e)
            {
                var errorResponse = new ResponseErrorJson(e.Errors);

                return BadRequest(errorResponse);
            }
            catch
            {
                var errorResponse = new ResponseErrorJson("unknown error");
                
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
