using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVente.Extensions
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString Conditional(this HtmlHelper html, Boolean condition, String ifTrue, String ifFalse)
        {
            return MvcHtmlString.Create(condition ? ifTrue : ifFalse);
        }

    }
}