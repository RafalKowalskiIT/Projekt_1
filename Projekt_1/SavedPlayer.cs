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
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(rating);
                if (RankAdded != null)
                {
                    RankAdded(this, new EventArgs());
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

