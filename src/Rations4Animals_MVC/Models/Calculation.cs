using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rations4Animals_MVC.Models
{
    public class Calculation
    {

        public Optimizer optimizer;

        public Calculation(string GUID)
        {
            string fileContent = File.ReadAllText(string.Format("{0}Calculations\\{1}.opt",Database.severMap,GUID));
            optimizer = Optimizer.DeSerialize(fileContent);
        }



    }
}
