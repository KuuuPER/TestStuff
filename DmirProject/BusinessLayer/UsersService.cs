using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Ninject;
using System.Text.RegularExpressions;
using BusinessLayer.Parser;
using System.IO;

namespace BusinessLayer
{
    public class UsersServiceLogic : IUsersService
    {
        IUsersRepository _usersRepository;

        public UsersServiceLogic(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IEnumerable<AgeCount> GetBirthdaysCount()
        {
            var users = _usersRepository.Get().OrderByDescending(u => u.BirthDate);

            return users
                .GroupBy(u => u.BirthDate.Year, (birthYear, userList) => 
                {
                    return userList.Where(u => u.BirthDate.Year == birthYear);
                })
                .Select(u => new AgeCount {
                    Count = u.Count(),
                    Age = DateTime.Now.Year - u.First().BirthDate.Year
                }).ToArray();
        }

        public void InsertFromStream(Stream source)
        {
            var users = ParserFactory.GetUsersParser(ParserType.CSV).Parse(source);
            _usersRepository.Insert(users);
        }
    }

    public class AgeCount
    {
        public int Count { get; internal set; }
        public int Age { get; internal set; }
    }
}
