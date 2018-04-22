using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ConfiguringResolver 
    {
        public static void ConfigureResolver(this IKernel kernel)
        {
            kernel.Bind<IRepository>().To<AccountsFileStorage>();
            kernel.Bind<IBankAccountService>().To<BankAccountService>();
            kernel.Bind<IBonusCounter>().To<BonusCounter>();
            kernel.Bind<IGenerator>().To<Generator>();
        }
    }
}