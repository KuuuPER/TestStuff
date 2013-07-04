using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public interface IRepository
    {
        IEnumerable<User> GetUsersContainsString(int count, string content);
        IEnumerable<User> GetUsers();
        void InsertUsers(IEnumerable<User> users);
    }
}
