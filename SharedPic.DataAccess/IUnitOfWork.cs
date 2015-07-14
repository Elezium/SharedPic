using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedPic.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
