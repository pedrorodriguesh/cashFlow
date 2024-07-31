namespace cashFlow.Exception.ExceptionsBase;

public class NotFoundException(string errorMessage) : CashFlowException(errorMessage);