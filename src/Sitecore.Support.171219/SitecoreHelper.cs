using Sitecore.Mvc.Extensions;
using Sitecore.Pipelines;
using Sitecore.Pipelines.RenderField;
using Sitecore.StringExtensions;
using Sitecore.Xml.Xsl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Sitecore.Support.Mvc.Helpers
{
    public class SitecoreHelper : Sitecore.Mvc.Helpers.SitecoreHelper
    {
        public SitecoreHelper(HtmlHelper htmlHelper) : base(htmlHelper)
        {
        }

        public virtual HtmlString FormHandler(string area, string controller, string action)
        {
            if (controller.IsEmptyOrNull())
            {
                controller = this.GetValueFromCurrentRendering("Form Controller Name");
            }
            if (action.IsEmptyOrNull())
            {
                action = this.GetValueFromCurrentRendering("Form Controller Action");
            }
            if (controller.IsEmptyOrNull())
            {
                return new HtmlString(string.Empty);
            }
            string text = this.HtmlHelper.Hidden("scController", controller).ToString();
            if (!action.IsEmptyOrNull())
            {
                text += this.HtmlHelper.Hidden("scAction", action);
            }
            if (!area.IsEmptyOrNull())
            {
                text += this.HtmlHelper.Hidden("scArea", area);
            }
            return new HtmlString(text);
        }
    }
}