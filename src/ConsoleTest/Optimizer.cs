using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;

namespace Rations4Animals_MVC.Models
{
    public class Optimizer
    {
        public double MixWeight { get; set; }
        public FeedStuff[] ListFeedStuff { get; set; }
        public FeedFormula FormulaFeed { get; set; }
        private LPSolver solver = new LPSolver();


        public double getConstraintValue(string decision)
        {
        
                string constraint = "";
                FeedStuff feed = ListFeedStuff[0];
                double feedValue = (double)feed.getValue(decision);

                constraint = (feedValue / 100) + "*" + feed.Weight;

                for (int j = 1; j < ListFeedStuff.Length; j++)
                {
                    feed = ListFeedStuff[j];
                    feedValue = (double)feed.getValue(decision);
                    constraint += "+" + (feedValue / 100) + "*" + feed.Weight;
                }
                constraint = constraint.Replace(',', '.');
                DataTable dt = new DataTable();
                object result = dt.Compute(constraint, null);
                return Convert.ToDouble(result.ToString());
  
        }

        public void addAllConstraints(string[] decisions)
        {
           
                for (int i = 0; i < decisions.Length; i++)
                {
                    double decisionMin = (double)FormulaFeed.getValue(decisions[i] + "_Min");
                    double decisionMax = (double)FormulaFeed.getValue(decisions[i] + "_Max");
                    string constraint = "";

                    FeedStuff feed = ListFeedStuff[0];
                    double feedValue = (double)feed.getValue(decisions[i]);
                    string feedName = removeIllegalChars(feed.Feedstuff);

                    constraint = (feedValue / 100) + "*" + feedName;

                    for (int j = 1; j < ListFeedStuff.Length; j++)
                    {
                        feed = ListFeedStuff[j];
                        feedValue = (double)feed.getValue(decisions[i]);
                        feedName = removeIllegalChars(feed.Feedstuff);
                        constraint += "+" + (feedValue / 100) + "*" + feedName;
                    }

                    string constraint_Min = constraint + ">=" + (MixWeight * decisionMin / 100);
                    string constraint_Max = constraint + "<=" + (MixWeight * decisionMax / 100);

                    if (decisionMin > 0)
                    {
                        solver.addConstraint(decisions[i] + "_Min", constraint_Min);
                    }

                    if (decisionMax > 0)
                    {
                        solver.addConstraint(decisions[i] + "_Max", constraint_Max);      

                    }
                }

    

        }

        public void addLimitConstraints()
        {
            foreach (FeedStuff f in ListFeedStuff)
            {
                solver.addConstraint(removeIllegalChars(f.Feedstuff) + "_LimitMin", removeIllegalChars(f.Feedstuff) + f.persentageLimitMin);
                solver.addConstraint(removeIllegalChars(f.Feedstuff) + "_LimitMax", removeIllegalChars(f.Feedstuff) + f.persentageLimitMax);
            }
        }

        public void setDecisions()
        {
            
                foreach (FeedStuff f in ListFeedStuff)
                {
                    solver.addDecision(removeIllegalChars(f.Feedstuff));
                }
   
        }

        public void setObjectiveFormula()
        {
         
                string formula = "(" + removeIllegalChars(ListFeedStuff[0].Feedstuff) + "*" + ListFeedStuff[0].CostPerKilogram.ToString().Replace(',', '.') + ")";
                for (int j = 1; j < ListFeedStuff.Length; j++)
                {
                    FeedStuff feed = ListFeedStuff[j];
                    formula += "+(" + removeIllegalChars(feed.Feedstuff) + "*" + feed.CostPerKilogram.ToString().Replace(',', '.') + ")";

                }
                solver.AddGoal(formula);


        }

        public double GetOptimalCost()
        {
            return solver.goals[0].ToDouble();
        }

        public void getResults()
        {
          
                string[,] results = solver.Calculate();
                foreach (FeedStuff f in ListFeedStuff)
                {
                    for (int i = 0; i < results.GetLength(0); i++)
                    {
                        string name = results[i, 0];
                        double weight = Convert.ToDouble(results[i, 1]);
                        if (removeIllegalChars(f.Feedstuff).Equals(name))
                        {
                            f.Weight = weight;
                        }
                    }
                }

        }

        public void addDefaultConstraint()
        {
             string constraint = removeIllegalChars(ListFeedStuff[0].Feedstuff);
                for (int i = 1; i < ListFeedStuff.Length; i++)
                {
                    constraint += "+" + removeIllegalChars(ListFeedStuff[i].Feedstuff);
                }
                constraint += "==" + MixWeight;
                solver.addConstraint("Weight", constraint);

        }

        private string removeIllegalChars(string str)
        {
            string newStr = "";
            foreach (char c in str)
            {
                if (Char.IsLetter(c))
                {
                    newStr += c;
                }
                else if (c == '%')
                {
                    newStr += "PER";
                }
                else if (c == '&')
                {
                    newStr += "AMP";
                }
                else if (c >= 48 && c <= 57)
                {
                    newStr += c;
                }
            }
            return newStr;
        }

        public static string Serialize(Optimizer op)
        {
           
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Optimizer));
                StringWriter textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, op);
                return textWriter.ToString();
         
        }

        public static Optimizer DeSerialize(string str)
        {
             StringReader reader = new StringReader(str);
                XmlSerializer serializer = new XmlSerializer(typeof(Optimizer));
                Optimizer obj = (Optimizer)serializer.Deserialize(reader);
                return obj;
      
        }
    }
}
