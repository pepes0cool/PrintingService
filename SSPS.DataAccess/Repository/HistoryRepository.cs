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
    public class HistoryRepository : Repository<History>, IHistoryRepository
    {
        private readonly ApplicationDbContext _db;
        public HistoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
