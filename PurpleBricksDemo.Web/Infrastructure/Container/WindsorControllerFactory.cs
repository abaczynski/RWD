using PurpleBricksDemo.Web.Models.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Infrastructure.Domain;


namespace PurpleBricksDemo.Web.Infrastructure.Container
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IMVCContainer _container;

        public WindsorControllerFactory(IMVCContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return _container.Resolve(controllerType) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            _container.Release(controller);
        }
    }
}