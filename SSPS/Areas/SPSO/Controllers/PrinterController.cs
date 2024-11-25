using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol;
using SSPS.DataAccess.Repository;
using SSPS.DataAccess.Repository.IRepository;
using SSPS.Models;
namespace SSPS.Areas.SPSO.Controllers
{
    [Area("SPSO")]
    [Route("SPSO/[controller]/[action]")]
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Printer obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Printer.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Printer create successfully!!";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) return NotFound();

            Printer? PrinterDb = _unitOfWork.Printer.Get(u=>u.Id == id);
            if(PrinterDb == null) return NotFound();
            return View(PrinterDb);
        }

        [HttpPost]
        public IActionResult Edit(Printer obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Printer.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Printer updated successfully!!";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            Printer? PrinterDb = _unitOfWork.Printer.Get(u => u.Id == id);
            if (PrinterDb == null) return NotFound();
            return View(PrinterDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Printer? obj = _unitOfWork.Printer.Get(u=>u.Id==id);

            if (obj == null) return NotFound();
            _unitOfWork.Printer.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Printer deleted successfully!!";
            return RedirectToAction("Index");
        }
    }
}
