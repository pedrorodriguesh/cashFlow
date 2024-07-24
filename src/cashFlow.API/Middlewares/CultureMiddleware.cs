using System.Globalization;

namespace cashFlow.API.Middlewares;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    
    
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    // needs to be exactly this way
    public async Task Invoke(HttpContext context)
    {
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
        
        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
        
        var cultureInfo = new CultureInfo("en");

        if (!string.IsNullOrWhiteSpace(requestedCulture) 
            && supportedLanguages.Exists(language => language.Name.Equals(requestedCulture)))
        {
            cultureInfo = new CultureInfo(requestedCulture);
        }
        
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
        
        await _next(context);
    }
}