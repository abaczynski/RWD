using Castle.Windsor;
using Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Component = Castle.MicroKernel.Registration.Component;

namespace Infrastructure.Container
{
    public class WindsorContainer : IContainer
    {
        private IWindsorContainer _container;

        public IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                    _container = new Castle.Windsor.WindsorContainer();
                return _container;
            }
        }


        public void Register<TService, TImplementation>() where TImplementation : class
        {
            var serviceType = typeof(TService);
            var implementationType = typeof(TImplementation);

            Container.Register(Component.For(serviceType).ImplementedBy(implementationType));
        }

        public void Register<TService>(Func<TService> factoryMethod)
        {
            var serviceType = typeof(TService);

            Container.Register(Component.For(serviceType).UsingFactoryMethod(factoryMethod));
        }

        public TService Resolve<TService>()
        {
            var implementation = Container.Resolve(typeof(TService));
            return (TService)implementation;
        }

        public object Resolve(Type service)
        {
            return Container.Resolve(service);
        }

        public void Release(object instance)
        {
            Container.Release(instance);
        }
    }
}
