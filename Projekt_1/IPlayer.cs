using static Projekt_1.PlayerBase;

namespace Projekt_1
{
    public interface IPlayer
    {
        void AddRating(string rating);
        Statistics GetStatistics();
        string Name { get; set; }
        string Surname { get; set; }
        string Position { get; set; }
        public event RankAddedDelegade RankAdded;

        public const string CLUB = "F.C. Barcelona";

        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }



    }

}
