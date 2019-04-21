using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using THA.Apresentation.Models;
using THA.Domain;
using THA.Util;

namespace THA.Apresentation.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View(new Result());
        }

        public IActionResult SaveResult(Result model)
        {
            if (!string.IsNullOrEmpty(model.FirstAnalysers.Message))
                model.FirstAnalysers.Compute(model.FirstAnalysers.Message);
            if (!string.IsNullOrEmpty(model.SecondAnalysers.Message))
                model.SecondAnalysers.Compute(model.SecondAnalysers.Message);
            if (!string.IsNullOrEmpty(model.ThirdAnalysers.Message))
                model.ThirdAnalysers.Compute(model.ThirdAnalysers.Message);
            if (!string.IsNullOrEmpty(model.FourthAnalysers.Message))
                model.FourthAnalysers.Compute(model.FourthAnalysers.Message);

            model.Compute();
            FileManager.SaveFile(model, _hostingEnvironment.WebRootPath);
            return RedirectToAction("Result", new { resultId = model.Id });
        }

        public IActionResult Result(Guid resultId)
        {
            var result = FileManager.ReadFile(resultId, _hostingEnvironment.WebRootPath);
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
