using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contract;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model=_manager.ProductService.GelAllProducts(false);
            return View(model);
        }

         public IActionResult Get([FromRoute(Name="id")]int id){
            var model=_manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }
    }

}