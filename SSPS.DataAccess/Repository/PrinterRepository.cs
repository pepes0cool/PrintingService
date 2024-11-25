using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSPS.DataAccess.Data;
using SSPS.DataAccess.Repository.IRepository;
using SSPS.Models;
using WebdotNet.DataAccess.Repository;

namespace SSPS.DataAccess.Repository
{
    public class PrinterRepository : Repository<Printer>, IPrinterRepository
    {
        private readonly ApplicationDbContext _db;
        public PrinterRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Printer printer)
        {
            var objFromDb = _db.printers.FirstOrDefault(p => p.Id == printer.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = printer.Name;
                objFromDb.Model = printer.Model;
                objFromDb.SerialNumber = printer.SerialNumber;
                objFromDb.paperNumber = printer.paperNumber;
            }
        }
    }
}
