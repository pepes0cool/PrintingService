using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SSPS.DataAccess;
using SSPS.DataAccess.Repository.IRepository;
using SSPS.Models;

namespace SSPS.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize]
    public class BuyController : Controller
    {
        private readonly ILogger<BuyController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public BuyController(ILogger<BuyController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var username = User.Identity.Name;
            var user = _unitOfWork.User.Get(u => u.UserName == username);
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }


        [HttpPost]
        public IActionResult BuyPages(User obj, int numPage)
        {
            var username = User.Identity.Name;
            var user = _unitOfWork.User.Get(u => u.UserName == username);
            user.PaperBalance += numPage;
            _unitOfWork.Save();
            return View(user);
        }
    }
}
