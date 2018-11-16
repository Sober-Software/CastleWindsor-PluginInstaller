using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace SoberSoftware.CastleWindsor.Installation.Registration
{
    public static class ContainerRegistrationExtensions
    {
        public static void AddHandlerSelector<TImplementation, TService>(this IWindsorContainer container,
            params ISelectionCriterion[] selectionCriteria)
            where TImplementation : TService where TService : class
        {
            container.Kernel.AddHandlerSelector(
                new HandlerSelector<TImplementation, TService>(selectionCriteria));
        }

        public static void RegisterThisAssembly(this IWindsorContainer container)
        {
            container.Register(Classes.FromAssembly(Assembly.GetCallingAssembly()).Pick().WithServiceAllInterfaces()
                .LifestyleTransient());
        }
    }
}