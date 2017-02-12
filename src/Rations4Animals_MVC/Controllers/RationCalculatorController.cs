using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Rations4Animals_MVC.Models;
using System.IO;
using System.Globalization;

namespace Rations4Animals_MVC.Controllers
{
    public class RationCalculatorController : Controller
    {

        //POST:  /RationCalculator/FeedStuffAndFeedFormulas
        [HttpPost]
        public ActionResult FeedStuffAndFeedFormulas()
        {
            FeedFormula[] feedFormulas = FeedFormula.getFeedFormula();

            List<string[]> listFeedFormula = new List<string[]>();
            foreach (FeedFormula ff in feedFormulas)
            {
                listFeedFormula.Add(new string[] { ff.ID.ToString(), ff.FormulaName });
            }

            FeedStuff[] feedstuff = FeedStuff.getFeedStuff();

            List<string[]> listFeedstuff = new List<string[]>();
            foreach (FeedStuff fs in feedstuff)
            {
                listFeedstuff.Add(new string[] { fs.ID.ToString(), fs.Feedstuff });
            }

            string[][] feedstuffList = listFeedstuff.ToArray();
            string[][] feedFormulaList = listFeedFormula.ToArray();

            return Json(new { feedstuffList, feedFormulaList, errorCode = 0 });
        }

        //POST:  /RationCalculator/GetPrice
        [HttpPost]
        public ActionResult GetPrice()
        {

            //string jsonData_FeedStuff = Request["feedstuff"];

            string jsonData_FeedStuff = "[\"135;7000,00;0;1000\",\"131;2000,00;0;1000\",\"137;800,00;4;4\",\"107;6060,00;0;4\",\"98;5000,00;0;1000\",\"87;4600,00;0;120\",\"82;4600,00;0;1000\",\"59;6060,00;0;80\",\"58;1500,00;0;80\",\"52;2900,00;0;1000\",\"50;2800,00;0;1000\",\"46;2600,00;0;1000\",\"45;2500,00;0;1000\",\"8;2200,00;0;1000\",\"7;2100,00;0;1000\"]";
            System.IO.File.AppendAllText(string.Format("{0}aaa.txt", Database.severMap), jsonData_FeedStuff);

            List<FeedStuff> listFeedstuff = new List<FeedStuff>();
            string[] feedstuff = JsonConvert.DeserializeObject<string[]>(jsonData_FeedStuff);
            foreach (string feedstuffStr in feedstuff)
            {
                string[] feedstuffValues = feedstuffStr.Split(';');
                FeedStuff tempFeedstuff = FeedStuff.getFeedStuff(Convert.ToInt32(feedstuffValues[0]));
                double cost;
                Double.TryParse(feedstuffValues[1].Replace(',', '.'), System.Globalization.NumberStyles.Currency, CultureInfo.CreateSpecificCulture("en-GB"), out cost);
                tempFeedstuff.CostPerKilogram = cost / 1000;
                
                double min;
                double max;

                Double.TryParse(feedstuffValues[2].Replace(',', '.'),System.Globalization.NumberStyles.Currency,CultureInfo.CreateSpecificCulture("en-GB"), out min);
                Double.TryParse(feedstuffValues[3].Replace(',', '.'),System.Globalization.NumberStyles.Currency,CultureInfo.CreateSpecificCulture("en-GB"), out max);
                tempFeedstuff.persentageLimitMin = ">=" + min;
                tempFeedstuff.persentageLimitMax = "<=" + max;
                listFeedstuff.Add(tempFeedstuff);
            }

            int feedformulaIndex = Convert.ToInt32(Request["feedformula"]);
            FeedFormula feedformula = FeedFormula.getFeedFormula(feedformulaIndex);


            Optimizer op = new Optimizer();
            op.FormulaFeed = feedformula;
            //op.ListFeedStuff = listFeedstuff.ToArray();

            FeedStuff[] f = FeedStuff.getFeedStuff();
            foreach (FeedStuff fs in f) {
                fs.CostPerKilogram = 5;
                fs.persentageLimitMax = "<=1000";
                fs.persentageLimitMin = ">=0";
            }
            op.ListFeedStuff = f;
           // op.ListFeedStuff = FeedStuff.getFeedStuff();
            op.MixWeight = 1000;
            op.setDecisions();
            op.addDefaultConstraint();
            op.setObjectiveFormula();
            op.addLimitConstraints();
            op.addAllConstraints(new string[] { "CP", "RUP", "CF", "EE", "ADF", "NDF", "eNDF", "TDNCattle", "TDNSheep", "DESheep", "MECattle", "MESheep", "NEmCattle", "NEgCattle", "NElCattle", "MEPoultry", "DEHorse", "DEPig", "MEPig", "Arg", "His", "Iso_L", "Leu", "Lys", "Met", "Cys", "Phe", "Tyr", "Thr", "Trp", "Val", "Gly", "Ser", "Ca", "Cl", "Mg", "P", "K", "Na", "S", "Co", "Cu", "I", "Fe", "Mn", "Se", "Zn", "VitA", "VitD", "VitE", "VitK", "Biotin", "Choline", "Folic", "Niacin", "Pantot", "VitB2", "VitB1", "VitB6", "VitB12" });
            op.getResults();

            string GUID = Guid.NewGuid().ToString();
            System.IO.File.AppendAllText(string.Format("{0}Calculations\\{1}.opt", Database.severMap, GUID), Optimizer.Serialize(op));

            string ip = Request.ServerVariables["REMOTE_ADDR"];

            string paypalUrl = PayWithPayPal(GUID);

            bool success = true;

            double p = op.GetOptimalCost();
            if (double.IsInfinity(p))
            {
                p = 0;
                success = false;
            }

            string date = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
            Database.ExecuteSQL(string.Format("INSERT INTO tableCalculation (Identifier,Paid,IPAddress,Successful,TimeOfCalculation) VALUES ('{0}',{1},'{2}',{3},#{4}#)", GUID, false, Request.ServerVariables["REMOTE_ADDR"], success, date));
            return Json(new { price = Math.Round(p, 2).ToString(), error = !success, calculationGUID = GUID, errorCode = 0 });

        }

        private string PayWithPayPal(string GUID)
        {
            string redirecturl = "";
            redirecturl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + "bjcustomsoft@gmail.com";
            redirecturl += "&item_name=" + "Ration Formula";
            redirecturl += "&amount=" + "28.99";
            redirecturl += "&quantity=1";
            redirecturl += "&currency=" + "USD";
            redirecturl += string.Format("&return=http://www.bjcustomsoft.somee.com/Results?GUID={0}", GUID);
            redirecturl += "&cancel_return=" + "http://www.bjcustomsoft.somee.com/";

            return redirecturl;

        }







    }
}
