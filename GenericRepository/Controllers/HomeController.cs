using GenericRepository.Models;
using GenericRepository.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GenericRepository.Controllers
{
	public class HomeController : Controller
	{
		private IProductService _productService;

		public HomeController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{

			//Generic Repository GetById çalýþtýrýldý
			//var result= _productService.GetProductId(1);


			var result = _productService.GetAll();

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
