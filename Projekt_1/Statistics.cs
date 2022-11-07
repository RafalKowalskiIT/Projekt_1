using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1
{
    public class Statistics
    {
        public double Sum;
        public double Count;

        public double Best;
        public double Worst;

        public Statistics()
        {
            Sum = 0;
            Count = 0;
            Best = double.MinValue;
            Worst = double.MaxValue;
        }


        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public string Rank
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 9:
                        return "Top player";
                    case var d when d >= 5:
                        return "Good player";
                    case var d when d >= 3:
                        return "Bad player";
                    default: return "Rly bad statistics, shame";
                }
            }
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Worst = Math.Min(number, Worst);
            Best = Math.Max(number, Best);
        }

    }
}
