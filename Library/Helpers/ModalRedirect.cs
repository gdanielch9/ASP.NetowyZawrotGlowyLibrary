using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Helpers
{
    public class ModalRedirect : ActionResult
    {
        private string url;

        public ModalRedirect(string Url)
        {
            this.url = Url;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var dupa = new UrlHelper(context.RequestContext);
            context.HttpContext.Response.Redirect(dupa.Action(""));
        }
    }
    //zrobic z uzyciem Action, Controller i Routevalues
}