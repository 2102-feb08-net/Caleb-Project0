using System;
using Microsoft.EntityFrameworkCore;
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
    public class Disposable
    {
        private static DbContextOptions<DB_BestEatsContext> options;
        //private readonly DB_BestEatsContext _context;
        public DB_BestEatsContext ConnectDB(string[] args = null)
        {
            //var logStream = new StreamWriter("BE-logs.txt", append: false) { AutoFlush = true };
            string connString = File.ReadAllText("C:/Users/piran/revature/BestEatsConnectString.txt");


            var optionBuild = new DbContextOptionsBuilder<DB_BestEatsContext>();
            optionBuild.UseSqlServer(connString);

                    return new DB_BestEatsContext(optionBuild.Options);
        }

        /*
        public ICustomerRepo CreateCustomerRepo()
        {
            var dbContext = ConnectDB();
            _disposable.add(dbContext);
            return new CustomerRepo(dbContext);
        */

        }


        
    }
}
