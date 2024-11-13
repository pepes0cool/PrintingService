using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSPS.DataAccess.Data;
using SSPS.DataAccess.Repository.IRepository;

namespace SSPS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IPrinterRepository Printer { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Printer = new PrinterRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
