using Projekt_1;

var player = new SavedPlayer("Robert", "Lewandowski", "Striker");

player.LowRankAdded += OnRankAdded;

EnterRating(player);

var stats = player.GetStatistic();
Console.WriteLine($"Best: {stats.Best}");
Console.WriteLine($"Worst: {stats.Worst}");
Console.WriteLine($"Average: {stats.Average}");

static void OnRankAdded(object sender, EventArgs args)
{
    Console.WriteLine($"This is rly low rank!!");
}

static void EnterRating(SavedPlayer player)
{
    while (true)
    {
        Console.WriteLine($"Hi, Enter rating for {player.FullName}");
        var rating = Console.ReadLine();

        if (rating == "q")
        {
            break;
        }

        player.AddRating(rating);

    }
}