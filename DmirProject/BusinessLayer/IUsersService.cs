using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IUsersService
    {
        IEnumerable<AgeCount> GetBirthdaysCount();
        void InsertFromStream(Stream source);
    }
}
