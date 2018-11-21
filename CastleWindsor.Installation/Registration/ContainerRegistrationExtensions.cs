using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace SoberSoftware.CastleWindsor.Installation.Registration
{
    public static class ContainerRegistrationExtensions
    {
        /// <summary>
        ///     Add service implementation criteria.
        ///     <para>
        ///         Criteria registered by during installation will automatically be added to the container.
        ///         Selection criteria passed as arguments is concatenated to registered implementation criteria.
        ///     </para>
        /// </summary>
        /// <typeparam name="TImplementation"></typeparam>
        /// <typeparam name="TService"></typeparam>
        /// <param name="container"></param>
        /// <param name="selectionCriteria"></param>
        public static void AddImplementationCriteria<TImplementation, TService>(this IWindsorContainer container,
            params ISelectionCriterion[] selectionCriteria)
            where TImplementation : class, TService where TService : class
        {
            ISelectionCriterion<TImplementation>[] implementationCriteria =
                container.ResolveAll<ISelectionCriterion<TImplementation>>();

            ISelectionCriterion[] combinedCriteria = implementationCriteria.Concat(selectionCriteria).ToArray();

            container.Kernel.AddHandlerSelector(
                new HandlerSelector<TImplementation, TService>(combinedCriteria));
        }

        public static void RegisterThisAssembly(this IWindsorContainer container)
        {
            container.Register(Classes.FromAssembly(Assembly.GetCallingAssembly()).Pick().WithServiceAllInterfaces()
                .LifestyleTransient());
        }

        public static void SetServiceDefault<TImplementation, TService>(this IWindsorContainer container)
            where TImplementation : TService where TService : class
        {
            container.Register(Component.For<TService, TImplementation>().IsDefault());
        }
    }
}