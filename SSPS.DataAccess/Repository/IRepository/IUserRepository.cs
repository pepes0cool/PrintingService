using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSPS.Models;

namespace SSPS.DataAccess.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        void AddPage(User user, int numPage);
    }


}
