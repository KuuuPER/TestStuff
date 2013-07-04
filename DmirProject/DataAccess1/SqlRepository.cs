using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DataAccess
{
    public class SqlRepository : IRepository
    {
        [Inject]
        DataEntitiesContext Db { get; set; }

        public IEnumerable<User> GetUsersContainsString(int count, string content)
        {
            return Db.Users.Where(u => u.UserName.Contains(content));
        }

        public IEnumerable<User> GetUsers()
        {
            return Db.Users.ToArray();
        }
    }
}
