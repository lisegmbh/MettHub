using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MettHub.WebApp.Models;
using MettHub.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace MettHub.WebApp.Controllers 
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMettCalculationService _mettCalculationService;

        public HomeController(IHostingEnvironment hostingEnvironment, IMettCalculationService mettCalculationService)
        {
            _hostingEnvironment = hostingEnvironment;
            _mettCalculationService = mettCalculationService;
        }

        public IActionResult Index() => RedirectToAction("MettCalculator");

        public async Task<IActionResult> MettCalculator(MettAmountViewModel amountViewModel)
        {
            if (amountViewModel.People > 0)
            {
                amountViewModel.MettAmountNeeded = await _mettCalculationService.CalculateAsync(amountViewModel.People);
            }

            return View(amountViewModel);
        }

        public IActionResult MettGallery()
        {
            var picPaths = Directory.GetFiles(Path.Combine(_hostingEnvironment.ContentRootPath, "MettPics"));
            var mettPicUrls = picPaths.Select(x => "/MettPics/" + (new FileInfo(x)).Name);

            ViewData["MettPicUrls"] = mettPicUrls;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
