using System.Reflection.PortableExecutable;

namespace Projekt_1
{
    public class InMemoryPlayer : PlayerBase
    {
        public InMemoryPlayer(string name, string surname, string position) : base(name, surname, position)
        {
        }
        public event RankAddedDelegade RankAdded;

        public override void AddRating(string rating)
        {            
            if (stringCheckList.Contains(rating))
            {
                if (rating.Contains("+"))
                {
                    var result = double.Parse(rating.Substring(0, 1));
                    result += 0.5;
                    this.ratingInGame.Add(result);
                    if (RankAdded != null)
                    {
                        RankAdded(this, new EventArgs());
                    }
                }
                else if (rating.Contains("-"))
                {
                    var result = double.Parse(rating.Substring(0, 1));
                    result -= 0.25;
                    this.ratingInGame.Add(result);
                    if (RankAdded != null)
                    {
                        RankAdded(this, new EventArgs());
                    }
                }
                else
                {
                    var result = double.Parse(rating.Substring(0, 1));
                    this.ratingInGame.Add(result);
                    if (RankAdded != null)
                    {
                        RankAdded(this, new EventArgs());
                    }
                }
            }
            else if (rating.Contains('.') || double.Parse(rating) < 10)
            {
                var result = double.Parse(rating);
                this.ratingInGame.Add(result);
                if (RankAdded != null)
                {
                    RankAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException("Invalid rating");
            }
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            for (var index = 0; index < ratingInGame.Count; index += 1)
            {
                result.Add(ratingInGame[index]);
            }
            return result;
        }
    }
}

