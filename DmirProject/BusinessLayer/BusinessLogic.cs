using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Ninject;
using System.Text.RegularExpressions;
using BusinessLayer.Parser;
using System.IO;

namespace BusinessLayer
{
    public class BusinessLogic : IBusiness
    {
        IRepository _repository;

        public BusinessLogic(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AgeCount> UsersCountBirthdays()
        {
            var users = _repository.GetUsers().OrderByDescending(u => u.BirthDate);

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

        public void InsertUsersFromStream(Stream stream)
        {
            var users = ParserFactory.GetUsersParser(ParserType.CSV).Parse(stream);
            _repository.InsertUsers(users);
        }
    }

    public class AgeCount
    {
        public int Count { get; internal set; }
        public int Age { get; internal set; }
    }
}
