using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using DAL;
using System.IO;

namespace DmirProject.Controllers
{
    public class UserController : Controller
    {
        [Inject]
        public IUsersRepository UsersRepository { get; set; }

        public ActionResult Index(IUsersRepository repo)
        {
            //IEnumerable<User> users;

            var users = repo.Get();

            return View(users);
        }

        public void Index(StreamReader users)
        {
            // Что это????
            var userStr = users.ReadToEnd();
        }
    }
}
