using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rations4Animals_MVC.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result?GUID=xxx-xxx-xxx-xxx

        public ActionResult Index()
        {
            string fileGUID = Request.QueryString["GUID"];
            return View(new Rations4Animals_MVC.Models.Calculation(fileGUID));
        }

    }
}
