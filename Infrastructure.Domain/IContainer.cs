using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Domain
{
    public interface IContainer
    {
        void Register<TService, TImplementation>() where TImplementation : class;    
        void Register<TService>(Func<TService> factoryMethod);
        TService Resolve<TService>();
        void Release(object instance);


    }
}
