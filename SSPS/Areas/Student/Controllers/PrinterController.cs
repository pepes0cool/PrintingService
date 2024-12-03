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
    public class PrinterController : Controller
    {
        private readonly ILogger<PrinterController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public PrinterController(ILogger<PrinterController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Printer> objPrinter = _unitOfWork.Printer.GetAll().ToList();
            return View(objPrinter);
        }

        public IActionResult Print(int? id)
        {
            TempData["Notification"] = "The request has been sent to printer!";
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}