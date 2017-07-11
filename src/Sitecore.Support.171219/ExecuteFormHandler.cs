using Sitecore.Mvc.Configuration;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Pipelines.Request.RequestBegin;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sitecore.Support.Mvc.Pipelines.Request.RequestBegin
{
    public class ExecuteFormHandler : Sitecore.Mvc.Pipelines.Request.RequestBegin.ExecuteFormHandler
    {
        public override void Process(RequestBeginArgs args)
        {
            base.Process(args);
        }

        protected override void ExecuteHandler(NameValueCollection formValues, RequestBeginArgs args)
        {
            string controllerName = formValues["scController"].OrIfEmpty(MvcSettings.DefaultFormControllerName);
            string actionName = formValues["scAction"];
            string area = formValues["scArea"].OrIfEmpty("");
            if (!area.IsEmpty())
                Sitecore.Mvc.Presentation.PageContext.Current.RequestContext.RouteData.DataTokens["area"] = area;
            ControllerLocator controllerLocator = MvcSettings.ControllerLocator;
            Tuple<string, string> controllerAndAction = controllerLocator.GetControllerAndAction(controllerName, actionName);
            if (controllerAndAction == null)
            {
                return;
            }
            controllerName = controllerAndAction.Item1;
            actionName = controllerAndAction.Item2;
            this.ExecuteHandler(controllerName, actionName, args);
        }

    }
}
