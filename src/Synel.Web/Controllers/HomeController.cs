using Microsoft.AspNetCore.Mvc;
using Synel.Application.Services;
using Synel.Web.Models;
using System.Diagnostics;

namespace Synel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmployeeService _employeeService;

       

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ViewModel viewModel)
        {
            var file = viewModel.formFile;
            string filePath = "";

            try
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath);
                filePath = Path.Combine(uploadFolder, fileName); // Change this to your desired directory.

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error: {ex.Message}");
            }
            
               await _employeeService.ImportFile(filePath);

            return View(new ViewModel
            {
            });
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
