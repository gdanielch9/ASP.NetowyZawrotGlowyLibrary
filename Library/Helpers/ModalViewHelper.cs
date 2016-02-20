using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Helpers
{
    public static class ModalViewHelper
    {
        //metody rozszerzające zwrc. sring lub HTMLstring
        public static HtmlString ModalButton(this HtmlHelper Dupa, string action, string controler, string displayname, object routeattributes, object htmlattributes)
        {
            var builder = new TagBuilder("button");
            builder.MergeAttribute("onClick", "buttonOnClick(this)");
            builder.MergeAttributes(HtmlHelper.ObjectToDictionary(htmlattributes));
            builder.SetInnerText(displayname);
            var urlHelper = new UrlHelper(Dupa.ViewContext.RequestContext);
            builder.MergeAttribute("modal-url", urlHelper.Action(action, controler, routeattributes));

            return new HtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static HtmlString ModalButton(this HtmlHelper Dupa, string action, string controler, string displayname) {
            return Dupa.ModalButton(action, controler, displayname, null, new { @class = "btn" });
        }

        public static HtmlString ModalHeader(this HtmlHelper Dupa, string name)
        {
            return new HtmlString("<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button><h4 class=\"modal-title\">"+name+"</h4></div>");
        }

        public static IDisposable ModalBody(this HtmlHelper Dupa)
        {
            var writer = Dupa.ViewContext.Writer;
            writer.WriteLine("<div class=\"modal-body\">");
            return new ModalBuilder(writer);
        }

        public static IDisposable ModalFooter(this HtmlHelper Dupa)
        {
            var writer = Dupa.ViewContext.Writer;
            writer.WriteLine("<div class=\"modal-footer\">");
            return new ModalBuilder(writer);
        }

    }

    public class ModalBuilder : IDisposable
    {
        TextWriter text;

        public ModalBuilder(TextWriter newText)
        {
            text = newText;
        }
        public void Dispose()
        {
            text.Write("</div>");
        }
    }
}