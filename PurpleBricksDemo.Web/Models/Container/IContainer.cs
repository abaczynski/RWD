using System;
using Castle.MicroKernel.Registration;
using Infrastructure.Domain;

namespace PurpleBricksDemo.Web.Models.Container
{
    public interface IMVCContainer : IContainer
    {

        void Register(params IRegistration[] registrations);
        object Resolve(Type service);
    }
}
