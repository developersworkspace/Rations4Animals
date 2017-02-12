using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rations4Animals_MVC.Models
{
    public class Statistics
    {
        public int numberOfFormulations { get; set; }
        public int numberOfUsers { get; set; }
        public int numberOfSuccessfulFormulations { get; set; }
        public int numberOfUnsuccessfulFormulations { get; set; }
        public int numberOfPaidFormulations { get; set; }
        public int numberOfUsersPaid { get; set; }

        public int unsuccessfulPersentage {
            get {
                double persentage = (double)numberOfUnsuccessfulFormulations / (double)numberOfFormulations * 100;
                return Convert.ToInt32(persentage);
            } 
        }

        public int successfulPersentage
        {
            get
            {
                double persentage = (double)numberOfSuccessfulFormulations / (double)numberOfFormulations * 100;
                return Convert.ToInt32(persentage);
            }
        }

        public int paidPersentage
        {
            get
            {
                double persentage = (double)numberOfPaidFormulations / (double)numberOfFormulations * 100;
                return Convert.ToInt32(persentage);
            }
        }

        public int usersPaidPersentage
        {
            get
            {
                double persentage = (double)numberOfUsersPaid / (double)numberOfUsers * 100;
                return Convert.ToInt32(persentage);
            }
        }

    }
}
