using System.Diagnostics;

namespace Projekt_1
{
    public abstract class PlayerBase : DataObject, IPlayer
    {
        public PlayerBase(string name, string surname, string position) : base(name, surname, position)
        {
        }
        public delegate void RankAddedDelegade(object sender, EventArgs args);
        public event RankAddedDelegade RankAdded;
        public abstract Statistics GetStatistics();

        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }
        public List<double> ratingInGame = new List<double>();
        public static List<string> stringCheckList = new List<string>()
            { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "1+", "1-", "2+", "2-", "3+", "3-", "4+", "4-", "5-", "5+", "6-", "6+", "7-", "7+", "8-", "8+", "9+", "9-", "10-", "0+" };

        public virtual void AddRating(string rating)
        {
            
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

        public void ChangeName(string newName)
        {
            foreach (var character in newName)
            {
                if (char.IsDigit(character))
                {
                    Console.WriteLine($"Character \"{character}\" in name {newName} is invalid ");

                }
                else if (char.IsLetter(character))
                {
                    this.Name = newName;
                }
            }
        }
    }
}
