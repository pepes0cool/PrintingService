using Microsoft.AspNetCore.Mvc;
using SSPS.DataAccess.Repository;
using SSPS.DataAccess.Repository.IRepository;
using SSPS.Models;
namespace SSPS.Areas.SPSO.Controllers
{
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
    }
}
