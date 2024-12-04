using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SSPS.Models;
using SSPS.DataAccess;
using SSPS.DataAccess.Repository.IRepository;
using SSPS.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace SSPS.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork,
            ApplicationDbContext db)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _db = db;
        }

        public IActionResult Index()
        {
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

        public IActionResult ViewHistory()
        {
            var username = User.Identity.Name;
            var user = _unitOfWork.User.Get(u => u.UserName == username);
            if (user == null)
            {
                return RedirectToAction("Error");
            }
            var historyRec = _unitOfWork.History.GetAll(
                                filter: hr => hr.UserID == user.Id,
                                includeProperties: "User,Printer").ToList();
            //var medicalRecords = _db.MedicalRecords
            //                       .Include(mr => mr.User)
            //                       .Where(mr => mr.UserID == userId)
            //                       .ToList();

            return View(historyRec);
        }
    }

}
