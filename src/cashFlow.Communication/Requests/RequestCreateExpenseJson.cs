using cashFlow.Communication.Enums;

namespace cashFlow.Communication.Requests;

public class RequestCreateExpenseJson
{
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public DateTime Date { get; set; }
    
    public decimal Amount { get; set; }
    
    public PaymentType PaymentType { get; set; }
}