using GenericRepository.DMO;
using GenericRepository.Repository;
using GenericRepository.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(AdventureWorks2019Context));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped(typeof(ProductRepository));
builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));	
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
