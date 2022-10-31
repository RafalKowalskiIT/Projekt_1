using System.Diagnostics;

namespace Projekt_1
{
    public abstract class PlayerBase : DataObject, IPlayer
    {
        public PlayerBase(string name, string surname, string position) : base(name, surname, position)
        {

        }

        public event LowRankAddedDelegade LowRankAdded;
        
        
        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }
        private List<double> ratingInGame = new List<double>();
        static List<Rating> GetRating()
        {
            return new List<Rating>
            {
                new Rating("0", 0),
                new Rating("0+", 0.5),
                new Rating("0.5", 0.5),
                new Rating("1", 1),
                new Rating("1+", 1.5),
                new Rating("1.5", 1.5),
                new Rating("2", 2),
                new Rating("2+", 2.5),
                new Rating("2.5", 2.5),
                new Rating("3", 3),
                new Rating("3+", 3.5),
                new Rating("3.5", 3.5),
                new Rating("4", 4),
                new Rating("4+", 4.5),
                new Rating("4.5", 4.5),
                new Rating("5", 5),
                new Rating("5+", 5.5),
                new Rating("5.5", 5.5),
                new Rating("6", 6),
                new Rating("6+", 6.5),
                new Rating("6.5", 6.5),
                new Rating("7", 7),
                new Rating("7+", 7.5),
                new Rating("7.5", 7.5),
                new Rating("8", 8),
                new Rating("8+", 8.5),
                new Rating("8.5", 8.5),
                new Rating("9", 9),
                new Rating("9+", 9.5),
                new Rating("9.5", 9.5),
                new Rating("10", 10),
            };
        }

        public virtual void AddRating(string rating)
        {
            List<Rating> ratingList = GetRating();
            Console.WriteLine($"Add rate");
            string rankInput = Console.ReadLine();

            Rating selectRank = ratingList.FirstOrDefault(c => c.Grade == rankInput);
            if (selectRank != null)
            {
                Console.WriteLine($"Successfully added rate equal to {selectRank.Rate}");
                ratingInGame.Add(selectRank.Rate);
            }
            else
            {
                throw new ArgumentException($"Invalid rating");

            }

            if (!double.TryParse(rankInput, out double grade))
            {
                throw new ArgumentException($"Invalid rating");
            }
            else if (grade >= 0 && grade <= 10.0)
            {
                ratingInGame.Add(grade);

                if (LowRankAdded != null && grade < 3.0)
                {
                    LowRankAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid rating {nameof(rating)}.");
            }

        }

        public virtual Statistics GetStatistic()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.Best = double.MinValue;
            result.Worst = double.MaxValue;

            foreach (var rating in ratingInGame)
            {
                result.Best = Math.Max(result.Best, rating);
                result.Worst = Math.Min(result.Worst, rating);
                result.Average += rating;
            }
            result.Average /= ratingInGame.Count;
            return result;

        }

        //metoda zmiana imienia piłkarza ---- do poprawy żeby wpisywało poprawne imie
        public void changeName(string newName)
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
