using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext(string connection) : base(connection)
        { }

        public DbSet<User> Users { get; set; }
    }
}
