using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SolverFoundation.Common;
using Microsoft.SolverFoundation.Services;
using System.IO;
using System.Data;

namespace Rations4Animals_MVC.Models
{

    public class LPSolver
    {

        private SolverContext context;
        private Model model;
        public Decision[] decisions { get { return model.Decisions.ToArray(); } }
        public Goal[] goals { get { return model.Goals.ToArray(); } }


        public LPSolver()
        {
                context = SolverContext.GetContext();
                model = context.CreateModel();
                File.AppendAllText(Database.severMap + "log.txt", string.Format("{1}{0}", DateTime.Now,Environment.NewLine));
        }

        public void addConstraint(string name, string exp)
        {
            File.AppendAllText(Database.severMap + "log.txt",string.Format("{2}{0} : {1}",name,exp.Replace(',', '.'),Environment.NewLine));
                model.AddConstraint(name, exp.Replace(',', '.'));
        }

        public void addDecision(string name)
        {
                model.AddDecision(new Decision(Domain.RealNonnegative, name));

        }

        public void AddGoal(string formula)
        {
     
                model.AddGoal("Cost", GoalKind.Minimize, formula);
       

        }

        public string[,] Calculate()
        {
        
                Solution solution = context.Solve();
                Report report = solution.GetReport();

                Console.WriteLine(solution.Quality);

                string[,] decisionsValues = new string[model.Decisions.Count(), 2];

                for (int i = 0; i < model.Decisions.Count(); i++)
                {
                    Decision d = model.Decisions.ElementAt(i);
                    decisionsValues[i, 0] = d.Name;
                    decisionsValues[i, 1] = d.GetDouble().ToString();

                }
                context.ClearModel();



                return decisionsValues;

        }


    }
}
