using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class UsersFileParser : IParser
    {
        public IEnumerable<User> Parse(object stream)
        {
            var parsedString = new StreamReader(stream as Stream, Encoding.Default).ReadToEnd();

            var pattern = @".*[^\s]";
            var userStr = Regex.Unescape(parsedString);
            var matches = Regex.Matches(userStr, pattern);

            var users = new List<User>();

            foreach (var item in matches)
            {
                var splitted = item.ToString().Split(';');
                users.Add(new User
                {
                    UserName = splitted[0],
                    BirthDate = DateTime.Parse(splitted[1])
                });
            }

            return users;
        }
    }
}
