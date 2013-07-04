using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DataAccess
{
    public class SqlUsersRepository : IUsersRepository
    {
        public SqlUsersRepository(DataAccessContext db)
        {
            Db = db;
        }

        [Inject]
        DataAccessContext Db { get; set; }

        public IEnumerable<User> GetUsersContainsString(int count, string content)
        {
            return Db.Users.Where(u => u.UserName.Contains(content));
        }

        public IEnumerable<User> GetUsers()
        {
            return Db.Users.ToArray();
        }

        public void InsertUsers(IEnumerable<User> users)
        {
            var usersInDb = Db.Users.ToArray();

            foreach (var user in users)
            {
                var isContain = usersInDb.Any(u =>
                    u.UserName == user.UserName
                    && u.BirthDate == user.BirthDate);

                if (!isContain)
                {
                    Db.Users.Add(user);
                }
            }

            Db.SaveChanges();
        }
    }
}
