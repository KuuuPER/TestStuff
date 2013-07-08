using BusinessLayer;
using DataAccess;
using DmirProject.Infrastructure;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DmirProject.App_Start
{
    static internal class Bindings
    {
        static public void Bind(IKernel kernel)
        {
            kernel.Bind<DataAccessContext>().ToMethod(d => new DataAccessContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)).InRequestScope();
            kernel.Bind<PageConfig>().ToMethod(p => new PageConfig(ConfigurationManager.AppSettings["ElementsPerPage"].ToString()));
            kernel.Bind<IRepository>().To<SqlRepository>();
            kernel.Bind<IBusiness>().To<BusinessLogic>();
            kernel.Bind<IParser>().To<UsersFileParser>();
        }
    }
}