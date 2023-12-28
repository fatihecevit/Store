using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace StoreApp.Components
{
    public class CategoriesMenuViewComponent:ViewComponent{
        private readonly IServiceManager _manager;

        public CategoriesMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _manager.CategoryService.GetAllCategories(false);
            return View(categories);
        }
    }
}