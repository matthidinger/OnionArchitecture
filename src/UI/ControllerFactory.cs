using System;
using System.Web.Mvc;
using System.Web.Routing;
using Core;

namespace UI
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return base.GetControllerInstance(requestContext, controllerType);

            if (!typeof(IController).IsAssignableFrom(controllerType))
                throw new ArgumentException(string.Format(
                    "Type requested is not a controller: {0}", controllerType.Name),
                                            "controllerType");

            return ServiceLocator.Current.GetInstance(controllerType) as IController;
        }
    }
}