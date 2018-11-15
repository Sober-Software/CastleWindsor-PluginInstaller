using System;
using System.Collections;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace SoberSoftware.CastleWindsor.Installation
{
    public class WindsorContainerWrapper : IWindsorContainer
    {
        private IWindsorContainer container;

        public object this[string key] => container[key];

        public object this[Type service] => container[service];

        public IKernel Kernel { get; }

        public string Name { get; }

        public IWindsorContainer Parent { get; set; }

        public WindsorContainerWrapper(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            this.container = container;
        }

        public void AddChildContainer(IWindsorContainer childContainer)
        {
            container.AddChildContainer(childContainer);
        }

        public IWindsorContainer AddComponent(string key, Type classType)
        {
            container.AddComponent(key, classType);
            return this;
        }

        public IWindsorContainer AddComponent(string key, Type serviceType, Type classType)
        {
            container.AddComponent(key, serviceType, classType);
            return this;
        }

        public IWindsorContainer AddComponent<T>()
        {
            container.AddComponent<T>();
            return this;
        }

        public IWindsorContainer AddComponent<T>(string key)
        {
            container.AddComponent<T>(key);
            return this;
        }

        public IWindsorContainer AddComponent<I, T>() where T : class
        {
            container.AddComponent<I, T>();
            return this;
        }

        public IWindsorContainer AddComponent<I, T>(string key) where T : class
        {
            container.AddComponent<I, T>(key);
            return this;
        }

        public IWindsorContainer AddComponentLifeStyle(string key, Type classType, LifestyleType lifestyle)
        {
            container.AddComponentLifeStyle(key, classType, lifestyle);
            return this;
        }

        public IWindsorContainer AddComponentLifeStyle(string key, Type serviceType, Type classType,
            LifestyleType lifestyle)
        {
            container.AddComponentLifeStyle(key, classType, lifestyle);
            return this;
        }

        public IWindsorContainer AddComponentLifeStyle<T>(LifestyleType lifestyle)
        {
            container.AddComponentLifeStyle<T>(lifestyle);
            return this;
        }

        public IWindsorContainer AddComponentLifeStyle<T>(string key, LifestyleType lifestyle)
        {
            container.AddComponentLifeStyle<T>(key, lifestyle);
            return this;
        }

        public IWindsorContainer AddComponentLifeStyle<I, T>(LifestyleType lifestyle) where T : class
        {
            container.AddComponentLifeStyle<I, T>(lifestyle);
            return this;
        }

        public IWindsorContainer AddComponentLifeStyle<I, T>(string key, LifestyleType lifestyle) where T : class
        {
            container.AddComponentLifeStyle<I, T>(key, lifestyle);
            return this;
        }

        public IWindsorContainer AddComponentProperties<I, T>(IDictionary extendedProperties) where T : class
        {
            container.AddComponentProperties<I, T>(extendedProperties);
            return this;
        }

        public IWindsorContainer AddComponentProperties<I, T>(string key, IDictionary extendedProperties)
            where T : class
        {
            container.AddComponentProperties<I, T>(extendedProperties);
            return this;
        }

        public IWindsorContainer AddComponentWithProperties(string key, Type classType, IDictionary extendedProperties)
        {
            container.AddComponentWithProperties(key, classType, extendedProperties);
            return this;
        }

        public IWindsorContainer AddComponentWithProperties(string key, Type serviceType, Type classType,
            IDictionary extendedProperties)
        {
            container.AddComponentWithProperties(key, serviceType, classType, extendedProperties);
            return this;
        }

        public IWindsorContainer AddComponentWithProperties<T>(IDictionary extendedProperties)
        {
            container.AddComponentWithProperties<T>(extendedProperties);
            return this;
        }

        public IWindsorContainer AddComponentWithProperties<T>(string key, IDictionary extendedProperties)
        {
            container.AddComponentWithProperties<T>(key, extendedProperties);
            return this;
        }

        public IWindsorContainer AddFacility(IFacility facility)
        {
            container.AddFacility(facility);
            return this;
        }

        public IWindsorContainer AddFacility<TFacility>() where TFacility : IFacility, new()
        {
            container.AddFacility<TFacility>();
            return this;
        }

        public IWindsorContainer AddFacility<TFacility>(Action<TFacility> onCreate) where TFacility : IFacility, new()
        {
            container.AddFacility(onCreate);
            return this;
        }

        public IWindsorContainer AddFacility(string idInConfiguration, IFacility facility)
        {
            container.AddFacility(idInConfiguration, facility);
            return this;
        }

        public IWindsorContainer AddFacility<TFacility>(string idInConfiguration) where TFacility : IFacility, new()
        {
            container.AddFacility<TFacility>(idInConfiguration);
            return this;
        }

        public IWindsorContainer AddFacility<TFacility>(string idInConfiguration, Action<TFacility> configureFacility)
            where TFacility : IFacility, new()
        {
            container.AddFacility(idInConfiguration, configureFacility);
            return this;
        }

        public void Dispose()
        {
            container = null;
        }

        public IWindsorContainer GetChildContainer(string name)
        {
            container.GetChildContainer(name);
            return this;
        }

        public IWindsorContainer Install(params IWindsorInstaller[] installers)
        {
            container.Install(installers);
            return this;
        }

        public IWindsorContainer Register(params IRegistration[] registrations)
        {
            container.Register(registrations);
            return this;
        }

        public void Release(object instance)
        {
            container.Release(instance);
        }

        public void RemoveChildContainer(IWindsorContainer childContainer)
        {
            container.RemoveChildContainer(childContainer);
        }

        public object Resolve(string key, Type service)
        {
            return container.Resolve(key, service);
        }

        public object Resolve(Type service)
        {
            return container.Resolve(service);
        }

        public object Resolve(Type service, IDictionary arguments)
        {
            return container.Resolve(service, arguments);
        }

        public object Resolve(Type service, object argumentsAsAnonymousType)
        {
            return container.Resolve(service, argumentsAsAnonymousType);
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public T Resolve<T>(IDictionary arguments)
        {
            return container.Resolve<T>(arguments);
        }

        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            return container.Resolve<T>(argumentsAsAnonymousType);
        }

        public T Resolve<T>(string key)
        {
            return container.Resolve<T>(key);
        }

        public T Resolve<T>(string key, IDictionary arguments)
        {
            return container.Resolve<T>(key, arguments);
        }

        public T Resolve<T>(string key, object argumentsAsAnonymousType)
        {
            return container.Resolve<T>(key, argumentsAsAnonymousType);
        }

        public object Resolve(string key, Type service, IDictionary arguments)
        {
            return container.Resolve(key, service, arguments);
        }

        public object Resolve(string key, Type service, object argumentsAsAnonymousType)
        {
            return container.Resolve(key, service, argumentsAsAnonymousType);
        }

        public object Resolve(string key, IDictionary arguments)
        {
            return container.Resolve(key, arguments);
        }

        public object Resolve(string key, object argumentsAsAnonymousType)
        {
            return container.Resolve(key, argumentsAsAnonymousType);
        }

        public T[] ResolveAll<T>()
        {
            return container.ResolveAll<T>();
        }

        public Array ResolveAll(Type service)
        {
            return ResolveAll(service);
        }

        public Array ResolveAll(Type service, IDictionary arguments)
        {
            return ResolveAll(service, arguments);
        }

        public Array ResolveAll(Type service, object argumentsAsAnonymousType)
        {
            return container.ResolveAll(service, argumentsAsAnonymousType);
        }

        public T[] ResolveAll<T>(IDictionary arguments)
        {
            return container.ResolveAll<T>(arguments);
        }

        public T[] ResolveAll<T>(object argumentsAsAnonymousType)
        {
            return container.ResolveAll<T>(argumentsAsAnonymousType);
        }
    }
}