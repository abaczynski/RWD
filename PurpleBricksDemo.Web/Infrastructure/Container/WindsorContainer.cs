using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PurpleBricksDemo.Web.Models.Container;
using Infrastructure.Domain;

namespace PurpleBricksDemo.Web.Infrastructure.Container
{
    public class WindsorContainer : IMVCContainer
    {
        public IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                    _container = new Castle.Windsor.WindsorContainer();
                return _container;
            }
        }

        public bool EnableInterceptor;

        public WindsorContainer()
        {
            
        }

        private IWindsorContainer _container;


        public void Register<TService, TImplementation>() where TImplementation : class
        {
            Type serviceType = typeof(TService);
            Type implementationType = typeof(TImplementation);
 
                Container.Register(Component.For(serviceType).ImplementedBy(implementationType));
        }


        public void Register(params IRegistration[] registrations)
        {
            Container.Register(registrations);
        }

        public void Register(Type service, Type implementation)
        {

                Container.Register(Component.For(service).ImplementedBy(implementation));
        }

        public void Register<TService>(Func<TService> factoryMethod)
        {
            Type serviceType = typeof(TService);

            Container.Register(Component.For(serviceType).UsingFactoryMethod(factoryMethod));
        }

        public TService Resolve<TService>()
        {
            object implementation = Container.Resolve(typeof(TService));
            return (TService)implementation;
        }

        public object Resolve(Type service)
        {
            return Container.Resolve(service);
        }

        public TService[] ResolveAll<TService>()
        {
            Array implementations = Container.ResolveAll(typeof(TService));
            return (TService[])implementations;
        }

        public Array ResolveAll(Type service)
        {
            return Container.ResolveAll(service);
        }

        public void Release(object instance)
        {
            Container.Release(instance);
        }

    }
}