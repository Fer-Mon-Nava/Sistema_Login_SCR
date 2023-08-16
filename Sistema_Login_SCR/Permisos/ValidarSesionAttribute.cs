using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Login_SCR.Permisos
{
    public class ValidarSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Login_scr"] == null)
            {
                filterContext.Result = new RedirectResult("~/Login/Login");

            }

                base.OnActionExecuting(filterContext);
        }
    }
}