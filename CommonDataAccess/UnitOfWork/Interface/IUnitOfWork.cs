using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataAccess.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        public void SaveChanges();
    }
}
