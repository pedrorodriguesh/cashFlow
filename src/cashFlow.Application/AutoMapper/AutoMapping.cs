using AutoMapper;
using cashFlow.Communication.Requests;
using cashFlow.Communication.Responses;
using cashFlow.Domain.Entities;

namespace cashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestCreateExpenseJson, Expense>();
    }
    
    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseCreatedExpenseJson>();
    }
}