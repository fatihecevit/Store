using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Views.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class DashboardController :Controller
    {
        public IActionResult Index(){

            return View();
        }
    }
}