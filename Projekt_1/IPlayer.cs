namespace Projekt_1
{
    public interface IPlayer
    {
        void AddRating(string rating);
        Statistics GetStatistics();
        string Name { get; set; }
        string Surname { get; set; }
        string Position { get; set; }

        public const string CLUB = "F.C. Barcelona";
        event LowRankAddedDelegade LowRankAdded;


    }

}
