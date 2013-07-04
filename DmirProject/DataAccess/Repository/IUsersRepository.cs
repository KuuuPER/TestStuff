using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public interface IUsersRepository
    {
        IEnumerable<User> Get(int count, string contains);
        IEnumerable<User> Get();
        void Insert(IEnumerable<User> users);
    }
}
