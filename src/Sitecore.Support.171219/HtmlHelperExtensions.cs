using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Common;
using Sitecore.Mvc.Configuration;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Pipelines;
using Sitecore.Mvc.Pipelines.Response.RenderPlaceholder;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using Sitecore.Mvc.Presentation;
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
using Sitecore.Support.Mvc.Helpers;


namespace Sitecore.Support.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static SitecoreHelper SitecoreSupport(this HtmlHelper htmlHelper)
        {
            Assert.ArgumentNotNull(htmlHelper, "htmlHelper");
            SitecoreHelper sitecoreHelper = Sitecore.Mvc.Helpers.ThreadHelper.GetThreadData<SitecoreHelper>();
            if (sitecoreHelper != null)
            {
                return sitecoreHelper;
            }
            sitecoreHelper = new SitecoreHelper(htmlHelper);
            Sitecore.Mvc.Helpers.ThreadHelper.SetThreadData<SitecoreHelper>(sitecoreHelper);
            return sitecoreHelper;
        }
    }
}
