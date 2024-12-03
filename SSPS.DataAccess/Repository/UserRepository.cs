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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void AddPage(User user, int numPage)
        {
            var objFromDb = _db.users.FirstOrDefault(u => u.UserName == user.UserName);
            if (objFromDb != null)
            {
                objFromDb.Name = user.Name;
                objFromDb.PaperBalance = user.PaperBalance + numPage;
            }
        }
    }
}
