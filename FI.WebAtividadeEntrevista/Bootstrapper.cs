using System.Web.Mvc;
using FI.AtividadeEntrevista.BLL;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using WebAtividadeEntrevista.Services.Clientes;

namespace WebAtividadeEntrevista
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IServiceCliente, ServiceCliente>();
            container.RegisterType<IServiceBeneficiario, ServiceBeneficiario>();
            container.RegisterType<IBoCliente, BoCliente>();
            container.RegisterType<IBoBeneficiario, BoBeneficiario>();

            return container;
        }
    }
}