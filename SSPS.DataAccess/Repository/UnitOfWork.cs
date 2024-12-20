﻿using System;
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
        public IUserRepository User { get; private set; }
        public IHistoryRepository History { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Printer = new PrinterRepository(_db);
            User = new UserRepository(_db);
            History = new HistoryRepository(_db);

        }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
