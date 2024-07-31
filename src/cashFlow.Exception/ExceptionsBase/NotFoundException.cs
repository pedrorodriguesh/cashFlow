using System.Net;

namespace cashFlow.Exception.ExceptionsBase;

public class NotFoundException(string errorMessage) : CashFlowException(errorMessage)
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;
    public override List<string> GetErrors()
    {
        return [Message];
    }
}