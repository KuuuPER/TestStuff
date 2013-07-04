using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IParser
    {
        IEnumerable<User> Parse(object parsedObject);
    }
}
