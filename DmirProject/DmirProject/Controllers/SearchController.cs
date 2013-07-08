using BusinessLayer;
using DmirProject.Infrastructure;
using DmirProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DmirProject.Controllers
{
    public class SearchController : Controller
    {
        private IBusiness _business;
        private PageConfig _pageConfig;

        public SearchController(IBusiness business, PageConfig pageConfig)
        {
            _business = business;
            _pageConfig = pageConfig;
        }

        public ActionResult Index()
        {
            return View(new SearchModel());
        }

        public ActionResult FindUsers(string SearchName)
        {
            var finds = _business.FindUsers(SearchName, 0, _pageConfig.ElementsPerPage);

            return View("Index", new SearchModel
            {
                Users = finds.Users,
                TotalCount = finds.TotalCount,
                SearchName = SearchName,
                Pages = (int)Math.Ceiling((double)finds.TotalCount / (double)_pageConfig.ElementsPerPage)
            });
        }

        [HttpGet]
        public ActionResult FindUsers(string SearchName, int n = 0)
        {
            var finds = _business.FindUsers(SearchName, n, _pageConfig.ElementsPerPage);

            return View("Index", new SearchModel
            {
                Users = finds.Users,
                TotalCount = finds.TotalCount,
                SearchName = SearchName,
                Pages = (int)Math.Ceiling((double)finds.TotalCount / (double)_pageConfig.ElementsPerPage)
            });
        }
    }
}
