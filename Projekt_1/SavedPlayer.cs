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
            List<Rating> ratingList = GetRating();
            

            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(rating);
                Rating selectRank = ratingList.FirstOrDefault(c => c.Grade == rating);
                if (selectRank != null)
                {
                    Console.WriteLine($"Successfully added rate equal to {selectRank.Rate}");
                    ratingInGame.Add(selectRank.Rate);
                }
                else
                {
                    throw new ArgumentException($"Invalid rating");

                }

                if (!double.TryParse(rating, out double grade))
                {
                    throw new ArgumentException($"Invalid rating");
                }
                else if (grade >= 0 && grade <= 10.0)
                {
                    ratingInGame.Add(grade);

                    if (RankAdded != null && grade < 3.0)
                    {
                        RankAdded(this, new EventArgs());
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid rating {nameof(rating)}.");
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

