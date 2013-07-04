using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using BusinessLayer;
using DataAccess;

namespace DmirProject.Controllers
{
    public class HomeController : Controller
    {
        private IBusiness _business;

        public HomeController(IBusiness business)
        {
            _business = business;
        }

        public ActionResult Index()
        {
            //IEnumerable<User> users;

            //using (var ent = new DataEntitiesContext())
            //{
            //    users = ent.Users.ToArray();
            //}

            var users = _business.UsersCountBirthdays();

            return View(users);
        }

        public ActionResult UsersFile(HttpPostedFileBase terrFile)
        {
            var contentType = terrFile.ContentType;

            var stream = terrFile.InputStream;

            if (stream != null && stream.Length > 0)
            {
                _business.InsertUsersFromStream(stream);
            }

            return RedirectToAction("Index");
        }
    }
}
