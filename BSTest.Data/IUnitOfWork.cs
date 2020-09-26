using System;
using System.Collections.Generic;
using System.Text;

namespace BSTest.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
