using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    /// <summary>
    ///     Installation Order:
    ///     <list type="number">
    ///         <item>
    ///             <term>DeclareDefaultServiceImplementations</term>
    ///         </item>
    ///         <item>
    ///             <term>InstallAssembly</term>
    ///         </item>
    ///         <item>
    ///             <term>DeclareResolutionScenarios</term>
    ///         </item>
    ///     </list>
    /// </summary>
    public interface IScenarioInstaller
    {
        /// <summary>
        ///     Installation Step 1:
        ///     <para>
        ///         Declare default service implementations.
        ///         If two or more scenario criteria collections return true,
        ///         the declared default is used. If no default is declared,
        ///         resolution defaults to first implementation registered for
        ///         the service.
        ///     </para>
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        void DeclareDefaultServiceImplementations(IWindsorContainer container, IConfigurationStore store);

        /// <summary>
        ///     Installation Step 2:
        ///     <para>
        ///         Install register the assembly with the container.
        ///     </para>
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        void InstallAssembly(IWindsorContainer container, IConfigurationStore store);

        /// <summary>
        ///     Installation Step 3:
        ///     <para>
        ///         Declare resolution scenarios for a service implementation.
        ///         When the container attempts to resolve the service, the handler
        ///         which matches the implementation and service, and whose selection
        ///         criteria are all true, will be chosen to resolve the implementation.
        ///         In the result of a tie, the default implementation is used.
        ///     </para>
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        void DeclareResolutionScenarios(IWindsorContainer container, IConfigurationStore store);
    }
}