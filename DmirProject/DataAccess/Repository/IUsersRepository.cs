using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{

    // На самом деле надо было назвать IUsersRepository и убрать слово Users из навания методов.
    public interface IRepository
    {
        IEnumerable<User> GetUsersContainsString(int count, string content);
        IEnumerable<User> GetUsers();
        void InsertUsers(IEnumerable<User> users);
    }
}
