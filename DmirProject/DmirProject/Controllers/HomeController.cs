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
using DmirProject.Infrastructure;
using DmirProject.ViewModel;

namespace DmirProject.Controllers
{
    public class HomeController : Controller
    {
        private IParser _parser;
        private IBusiness _business;
        private PageConfig _pageConfig;

        public HomeController(IParser parser, IBusiness business, PageConfig pageConfig)
        {
            _business = business;
            _parser = parser;
            _pageConfig = pageConfig;
        }

        [HttpGet]
        public ActionResult Index(int n = 0)
        {
            var usersBirthdays = _business.GetUsersBirthdays(n, _pageConfig.ElementsPerPage);

            return View(new AgeCountModel
            {
                AgeCounts = usersBirthdays.AgeCounts,
                TotalCount = usersBirthdays.TotalElementsCount,
                Pages = (int)Math.Ceiling((double)usersBirthdays.TotalElementsCount / (double)_pageConfig.ElementsPerPage)
            });
        }

        public ActionResult UsersFile(HttpPostedFileBase usersFile)
        {
            var stream = usersFile.InputStream;

            if (stream != null && stream.Length > 0)
            {
                _business.InsertUsersFromStream(stream, _parser);
            }

            return RedirectToAction("Index");
        }        
    }
}
