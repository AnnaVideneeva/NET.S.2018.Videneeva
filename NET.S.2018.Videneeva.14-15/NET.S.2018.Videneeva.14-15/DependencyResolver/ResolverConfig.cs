using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            //kernel.Bind<IAccountService>().To<AccountService>();
            ////kernel.Bind<IRepository>().To<FakeRepository>();
            //kernel.Bind<IRepository>().To<AccountBinaryRepository>().WithConstructorArgument("test.bin");
            //kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();
            ////kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
