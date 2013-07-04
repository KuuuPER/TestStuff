using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DAL
{
    public class SqlUsersRepository : IUsersRepository
    {
        public SqlUsersRepository(DataAccessContext db)
        {
            Db = db;
        }

        [Inject]
        DataAccessContext Db { get; set; }

        public IEnumerable<User> Get(int count, string content)
        {
            return Db.Users.Where(u => u.UserName.Contains(content));
        }

        public IEnumerable<User> Get()
        {
            return Db.Users.ToArray();
        }

        public void Insert(IEnumerable<User> users)
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
