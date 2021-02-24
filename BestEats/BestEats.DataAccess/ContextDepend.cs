using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BestEats.DataAccess
{
    public class ContextDepend : IDisposable
    {

        private bool _disposedValue;
        private readonly List<IDisposable> _disposables = new List<IDisposable>();
        public DB_BestEatsContext ConnectDB(string[] args = null)
        {

            string connString = File.ReadAllText("C:/Users/piran/revature/BestEatsConnectString.txt");
            var optionBuild = new DbContextOptionsBuilder<DB_BestEatsContext>();
            optionBuild.UseSqlServer(connString);

                    return new DB_BestEatsContext(optionBuild.Options);
        }

        
        public BaseRepo CreateBaseRepo()
        {
            var dbContext = ConnectDB();
            _disposables.Add(dbContext);
            return new BaseRepo(dbContext);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    foreach (IDisposable disposable in _disposables)
                    {
                        disposable.Dispose();
                    }
                    
                }
                _disposedValue = true;
            }
        }

        // override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ContextDepend()
        // {
        // }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
