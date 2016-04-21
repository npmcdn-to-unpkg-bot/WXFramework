[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WXFrameworkWeb.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WXFrameworkWeb.App_Start.NinjectWebCommon), "Stop")]

namespace WXFrameworkWeb.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using NPoco;
    using ArchBll.Session;
    using ArchLib;
    using System.Web.Http;
    using ArchBll.User;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        public static IKernel Kernel
        {
            get { return bootstrapper.Kernel; }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //http://stackoverflow.com/questions/20595472/mvc5-web-api-2-and-and-ninject
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
            

            kernel.Bind<Database>().ToConstructor(
              context => new Database("UserConnection")
            ).InRequestScope().Named("SSO");
            kernel.Bind<Database>().ToConstructor(
                context => new Database("AppConnection")
            ).InRequestScope().Named("App");
            kernel.Bind<IUserManager>().To<SSOUserManager>().InRequestScope();
            kernel.Bind<ISessionManager>().To<SessionManager>().InRequestScope();
            kernel.Bind<ExcelMappingUtil>().ToSelf().InRequestScope();
            kernel.Bind(x => x.FromAssembliesMatching("*.dll")
                .Select(f => f.Name.EndsWith("Repository") || f.Name.EndsWith("Service"))
                .BindToSelf().Configure(binding => binding.InRequestScope())
            );
        }
    }
}
