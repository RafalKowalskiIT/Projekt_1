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
            var stringCheckList = new List<string>()
            { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "1+", "1-", "2+", "2-", "3+", "3-", "4+", "4-", "5-", "5+", "6-", "6+", "7-", "7+", "8-", "9+", "9-", "10-", "0+" };
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
            else if (rating.Contains("."))
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

