using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BestEats.DataAccess
{
    public class Repository
    {
        
        private readonly DB_BestEatsContext _context;
        public Repository()
        {
            var logStream = new StreamWriter("BE-logs.txt", append: false) { AutoFlush = true };
            string connString = File.ReadAllText("C:/Users/piran/revature/BestEatsConnectString.txt");



            DbContextOptions<DB_BestEatsContext> options = new DbContextOptionsBuilder<DB_BestEatsContext>()
                    .UseSqlServer(connString)
                    .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
                    .Options;
            _context = new DB_BestEatsContext(options);
        }
        
    }
}
