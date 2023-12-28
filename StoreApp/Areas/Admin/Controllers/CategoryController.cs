using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Views.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class CategoryController :Controller
    {
        public IActionResult Index(){

            return View();
        }
    }
}