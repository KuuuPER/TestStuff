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
        AgeCountCollection GetUsersBirthdays(int n, int elementsCount);
        void InsertUsersFromStream(Stream stream, IParser parser);
        UsersSubsequent FindUsers(string userName, int n, int elementsCount);
    }
}
