using Castle.Windsor;

namespace SoberSoftware.CastleWindsor.Installation.Installation
{
    public interface IInstallationStrategy
    {
        void InstallMainApplication(IWindsorContainer container);

        void InstallPluginAssemblies(IWindsorContainer container);

        IMainAssemblyProvider MainAssemblyProvider { get; }

        IPluginAssembliesProvider PluginAssembliesProvider { get; }
    }
}