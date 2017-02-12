using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Rations4Animals_MVC.Models;
using System.Diagnostics;

namespace ConsoleTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {


            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {

                StreamReader sr = new StreamReader(ofd.FileName);
                string optFile = sr.ReadToEnd();
                sr.Close();

                Optimizer op = Optimizer.DeSerialize(optFile);
                op.setDecisions();
                op.addDefaultConstraint();
                op.setObjectiveFormula();
                op.addLimitConstraints();
                op.addAllConstraints(new string[] { "DM", "CP", "RUP", "CF", "EE", "ADF", "NDF", "eNDF", "TDNCattle", "TDNSheep", "DESheep", "MECattle", "MESheep", "NEmCattle", "NEgCattle", "NElCattle", "MEPoultry", "DEHorse", "DEPig", "MEPig", "Arg", "His", "Iso_L", "Leu", "Lys", "Met", "Cys", "Phe", "Tyr", "Thr", "Trp", "Val", "Gly", "Ser", "Ca", "Cl", "Mg", "P", "K", "Na", "S", "Co", "Cu", "I", "Fe", "Mn", "Se", "Zn", "VitA", "VitD", "VitE", "VitK", "Biotin", "Choline", "Folic", "Niacin", "Pantot", "VitB2", "VitB1", "VitB6", "VitB12" });
                op.getResults();
                Console.WriteLine(op.GetOptimalCost());
                Console.ReadLine();
                
            }
            else
            {
                MessageBox.Show("No file select.");
            }
           
        }


        private static string PayWithPayPal(string GUID)
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
