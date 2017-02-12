using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using Rations4Animals_MVC.Models;

namespace Rations4Animals_MVC.Controllers
{
    public class DatabaseController : Controller
    {
        //
        // GET: /Database/

        public ActionResult Index()
        {
            string table = Request.QueryString["table"];
            return View(GetRows(string.Format("SELECT * FROM {0}",table), table));
        }


        private object[] GetRows(string sql, string table)
        {
            return new object[] { Database.getRows(sql), Database.getAllColumns(table) };
        }


        //
        // GET: /Database/Report
        public ActionResult Report()
        {
            Statistics s = new Statistics();
            s.numberOfFormulations = Database.getRows("SELECT COUNT(*) AS NumberOfFormulations FROM tableCalculation")[0].Field<int>("NumberOfFormulations");
            s.numberOfSuccessfulFormulations = Database.getRows("SELECT COUNT(*) AS NumberOfFormulations FROM tableCalculation WHERE Successful = true;")[0].Field<int>("NumberOfFormulations");
            s.numberOfUnsuccessfulFormulations = Database.getRows("SELECT COUNT(*) AS NumberOfFormulations FROM tableCalculation WHERE Successful = false;")[0].Field<int>("NumberOfFormulations");
            s.numberOfUsers = Database.getRows("SELECT COUNT(*) AS NumberOfUsers FROM (SELECT IPAddress FROM tableCalculation GROUP BY IPAddress);")[0].Field<int>("NumberOfUsers");
            s.numberOfUsersPaid = Database.getRows("SELECT COUNT(*) AS NumberOfUsers FROM (SELECT IPAddress FROM tableCalculation WHERE Paid = true GROUP BY IPAddress);")[0].Field<int>("NumberOfUsers");
            s.numberOfPaidFormulations = Database.getRows("SELECT COUNT(*) AS NumberOfFormulations FROM tableCalculation WHERE Paid = true;")[0].Field<int>("NumberOfFormulations");
            return View(s);
        }

    }
}
