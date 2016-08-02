using JonHuss_CaaS.DataModel;
using JonHuss_CaaS.UserInterface.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace JonHuss_CaaS.UserInterface.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            if(Request.IsAuthenticated)
            {
                if (User.Identity is ClaimsIdentity)
                {
                    Claim claim = ((ClaimsIdentity)User.Identity).Claims.Single(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

                    CaaSDataModel db = new CaaSDataModel();
                    model.ConversationTemplates = db.ConversationTemplates.Where(c => c.UserId == claim.Value);
                }
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}