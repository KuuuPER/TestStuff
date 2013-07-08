using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public interface IRepository
    {
        IEnumerable<User> GetUsersContainsString(string content);
        IEnumerable<AgeCount> GetUsersBirthdays();
        void InsertUsers(IEnumerable<User> users);
    }
}
