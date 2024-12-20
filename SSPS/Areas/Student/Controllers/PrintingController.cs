using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSPS.DataAccess;
using SSPS.DataAccess.Repository.IRepository;
using SSPS.Models;

namespace SSPS.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize]
    public class PrintingController : Controller
    {
        private readonly ILogger<PrintingController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public PrintingController(ILogger<PrintingController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var user = _unitOfWork.User.Get(u => u.UserName == username);
            return View(user);
        }
        public IActionResult Option()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }


        [HttpPost]
        public IActionResult PrintA4(int printerId)
        {
            var username = User.Identity.Name;
            var user = _unitOfWork.User.Get(u => u.UserName == username);
            if (user == null)
            {
                return RedirectToAction("Error");
            }

            var printer = _unitOfWork.Printer.Get(p => p.Id == printerId);
            if (printer == null)
            {
                return RedirectToAction("Error");
            }

            if (user.PaperBalance < 1)
            {
                TempData["Error"] = "Insufficient paper balance.";
                return RedirectToAction("Index");
            }

            user.PaperBalance -= 1;

            var historyRecord = new History
            {
                UserID = user.Id,
                PrinterID = printer.Id,
                paperNum = 1,
                status = "Printed",
                date = DateTime.Now
            };
            _unitOfWork.History.Add(historyRecord);
            _unitOfWork.Save();

            TempData["Success"] = "Printing updated successfully!";
            return View(user);
        }

    }
}
