using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1
{

    public class SavedPlayer : PlayerBase
    {
        public SavedPlayer(string name, string surname, string position) : base(name, surname, position)
        {
        }

        public event RankAddedDelegade RankAdded;


        public override void AddRating(string rating)
        {
            var stringCheckList = new List<string>()
            { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "1+", "1-", "2+", "2-", "3+", "3-", "4+", "4-", "5-", "5+", "6-", "6+", "7-", "7+", "8-", "8+", "9+", "9-", "10-", "0+"};

            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(rating);
                if (stringCheckList.Contains(rating))
                {
                    if (rating.Contains("+"))
                    {
                        var result = double.Parse(rating.Substring(0, 1));
                        result += 0.5;
                        this.ratingInGame.Add(result);
                    }
                    else if (rating.Contains("-"))
                    {
                        var result = double.Parse(rating.Substring(0, 1));
                        result -= 0.25;
                        this.ratingInGame.Add(result);
                    }
                    else
                    {
                        var result = double.Parse(rating.Substring(0, 1));
                        this.ratingInGame.Add(result);
                    }
                }
                else if (rating.Contains("."))
                {
                    var result = double.Parse(rating);
                    this.ratingInGame.Add(result);
                }

                else
                {
                    throw new ArgumentException("Invalid rating");

                }

            }
            using (var writer = File.AppendText($"audit_{Name}.txt"))
            {
                writer.WriteLine(rating);
                if (RankAdded != null)
                {
                    RankAdded(this, new EventArgs());

                }
                writer.WriteLine(DateTime.UtcNow);
            }
                       
           
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();

                }
            }

            return result;
        }

    }
}

