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

        /// <summary>
        /// Skip first n*30 elements and returns next 30 elements. When n == 0, method returns first 30 elements.
        /// When n == 1, method skip first 30 elements and returtn from 30 to 60 elements.
        /// </summary>
        /// <param name="n">Skip first n*30 elemets</param>
        /// <returns>30 elements</returns>
        public AgeCountCollection GetUsersBirthdays(int n, int elementsCount)
        {
            var usersBirthdays = _repository.GetUsersBirthdays();

            return new AgeCountCollection
            {
                TotalElementsCount = usersBirthdays.Count(),
                AgeCounts = usersBirthdays
                .Skip(n * elementsCount)
                .Take(elementsCount)
            };
        }


        /// <summary>
        /// Parses the stream content and getting data from it.
        /// Then normalized a UserName and insert to database.
        /// </summary>
        /// <param name="stream">Stream with a file</param>
        /// <param name="parser">Parser which parses the file from stream</param>
        public void InsertUsersFromStream(Stream stream, IParser parser)
        {
            var users = parser.Parse(stream);

            foreach (var user in users)
            {
                user.UserName = NormalizeUsername(user.UserName);
            }

            _repository.InsertUsers(users);
        }

        public UsersSubsequent FindUsers(string userName, int n, int elementsCount)
        {
            if (string.IsNullOrEmpty(userName))
                return null;

            var users = _repository.GetUsersContainsString(userName);

            return new UsersSubsequent
            {
                TotalCount = users.Count(),
                Users = users
                .Skip(n * elementsCount)
                .Take(elementsCount)
            };
        }
        
        private string NormalizeUsername(string userName)
        {
            var chars = userName
                        .ToLowerInvariant()
                        .ToCharArray();

            chars[0] = chars[0]
                .ToString()
                .ToUpper()
                .ToCharArray()
                .First();

            return new string(chars);
        }
    }

    public class AgeCountCollection
    {
        public int TotalElementsCount { get; internal set; }

        public IEnumerable<AgeCount> AgeCounts { get; internal set; }
    }

    public class UsersSubsequent
    {
        public int TotalCount { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
