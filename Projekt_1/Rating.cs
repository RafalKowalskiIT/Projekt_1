using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1
{
    public class Rating
    {
        public Rating(string grade, double rate)
        {
            this.Grade = grade;
            this.Rate = rate;
        }
        public string Grade { get; set; }
        public double Rate { get; set; }
    }
}
