using DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBusiness
    {
        IEnumerable<AgeCount> UsersCountBirthdays();
        void InsertUsersFromStream(Stream stream);
    }
}
