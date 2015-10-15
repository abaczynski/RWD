using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using PurpleBricksDemo.Web.Models.Container;
using Core.Users;
using Infrastructure.DataAccess;
using Core.Model.Users;
using PurpleBricksDemo.Web.Models.Sessions;
using PurpleBricksDemo.Web.Infrastructure;
using PurpleBricksDemo.Web.Services;
using Core.Model.Offers;
using Core.Offers;
using Core.Model.Property;
using Core.Property;
using Infrastructure.Security;

namespace PurpleBricksDemo.Web.App_Start
{
    public static class BootStrapper
    {
        public static void Initialize(IMVCContainer container)
        {
            InitializeContainer(container);
        }

        private static void InitializeContainer(IMVCContainer container)
        {
            DataAccessBootStrapper.Initialize(container);
            container.Register<IUserService, UserService>();
            container.Register<IOfferService, OfferService>();
            container.Register<IPropertyService, PropertyService>();
            container.Register<IAuthentication, FormsAuthentication>();
            container.Register<ISessionManager, SessionManager>();
            container.Register<PurpleBricksDemo.Web.Models.Sessions.ISessionStorage, SessionStorage>();
            container.Register<ISecurityService, Pbkdf2>();
            
            container.Register(Types.FromThisAssembly().BasedOn(typeof(Controller)).WithService.Self().LifestyleTransient());
        }

    }
}
