using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Common;
using Ninject.Parameters;
using Ninject.Syntax;
using System.Configuration;
using DAL;
using BusinessLayer;


namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<DataAccessContext>().ToMethod(d => new DataAccessContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)).InRequestScope();
            kernel.Bind<IUsersRepository>().To<SqlUsersRepository>();
            kernel.Bind<IUsersService>().To<UsersService>();
        }
    }
}