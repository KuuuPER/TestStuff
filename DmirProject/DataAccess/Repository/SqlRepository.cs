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
        public SqlRepository(DataAccessContext db)
        {
            Db = db;
        }

        DataAccessContext Db { get; set; }

        public IEnumerable<User> GetUsersContainsString(string content)
        {
            return Db.Users.Where(u => u.UserName.StartsWith(content));
        }

        public IEnumerable<AgeCount> GetUsersBirthdays()
        {
            return Db.Users
                .Select(u => new
                {
                    Years = DateTime.Now.Year - u.BirthDate.Year,
                    WasBirthday = DateTime.Now.Month < u.BirthDate.Month 
                    || (DateTime.Now.Month == u.BirthDate.Month && DateTime.Now.Day < u.BirthDate.Day),
                    Element = u
                })
                .Select(u => new
                {
                    Age = u.WasBirthday ? u.Years : (u.Years - 1),
                    Element = u.Element
                })
                .GroupBy(u => u.Age)
                .Select(e => 
                    new AgeCount
                    {
                        Age = e.Key,
                        Count = e.Count()
                    })
                .OrderByDescending(u => u.Count);
        }

        /// <summary>
        /// Insert in database if doesn't exist in current database
        /// </summary>
        /// <param name="users">inserted collection of users</param>
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

    public class AgeCount
    {
        public int Count { get; internal set; }
        public int Age { get; internal set; }
    }
}
