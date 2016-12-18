using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace iTasksProject.Models
{
    class _KullaniciAdminmiKontrolAttribute : ActionFilterAttribute
    {// kullanici girişi gerektiren sayfalarda kullanici girişi kontrolu için attribute
        ApplicationDbContext db = new ApplicationDbContext();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           //var kullanici = db.Users.Where(u=>u.)
           //if (!YardimciMethodlar.uyeAdminmi())
           //{
           //    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
           //    {
           //        controller = "kullanici",
           //        action = "index",
           //        dil = YardimciMethodlar.dilSessionGetir()
           //    }));
           //    return;
           //}

        }
    }

}