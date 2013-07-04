using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using DataAccess;
using System.IO;

namespace DmirProject.Controllers
{
    public class UserController : Controller
    {
        [Inject]
        public IRepository Repository { get; set; }

        public ActionResult Index(IRepository repo)
        {
            //IEnumerable<User> users;

            var users = repo.GetUsers();

            return View(users);
        }

        public void Index(StreamReader users)
        {
            var userStr = users.ReadToEnd();
        }
    }
}
