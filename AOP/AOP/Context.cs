using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
    public class Context : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        public Context():base("AOP")
        {
        }
    }
}
