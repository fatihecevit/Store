using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contract;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.ProductService.GelAllProducts(false).Count().ToString();
        }
    }
}