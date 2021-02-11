using System;
using System.Collections.Generic;
using System.Text;

namespace VemDeZap.Infra.Repositories.Transactions
{
    public interface IUnitOfWork
    {
         void SaveChanges();
    }
}
