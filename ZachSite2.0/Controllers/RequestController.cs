using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.RequestProcessor;

namespace ZachSite2._0.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult request()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestForm(Models.RequestModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateRequest(model.FirstName, 
                    model.LastName, 
                    model.EmailAddress, 
                    model.ProposalMessage);
                TempData["newRequest"] = "true";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}