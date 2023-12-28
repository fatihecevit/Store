using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contract;


var builder = WebApplication.CreateBuilder(args);

//Bu satır, uygulamaya MVC (Model-View-Controller) hizmetlerini ekler. 
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b => b.MigrationsAssembly("StoreApp"));
});

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

var app = builder.Build();

//Bu middleware, HTTP üzerinden gelen istekleri otomatik olarak HTTPS'ye yönlendirir. Bu, güvenli bir bağlantı (SSL/TLS) kullanımını zorunlu kılar.
app.UseHttpsRedirection();

//Bu middleware, gelen HTTP isteklerini belirli bir işlem sırasına göre yönlendirmek ve ilgili işlemleri gerçekleştirmek için kullanılır. 
app.UseRouting();

app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{   
    endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
