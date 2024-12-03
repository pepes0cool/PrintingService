using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSPS.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPrinterRepository Printer { get; }
        IUserRepository User { get; }
        IHistoryRepository History { get; }
        void Save();
    }
}
