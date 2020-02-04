using Microsoft.AspNetCore.Mvc.RazorPages;

namespace scribanonline.Pages
{
    public class IndexModel : PageModel
    {
        public string Version => ScribanUtils.Version;
        public void OnGet()
        {
        }
    }
}