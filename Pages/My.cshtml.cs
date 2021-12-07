using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace solarsystem.Pages;

public class MyModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public MyModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
