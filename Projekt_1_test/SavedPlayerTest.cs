using Projekt_1;
using System.Runtime.CompilerServices;

namespace Projekt_1_test;

public class SavedPlayerTest
{
    [Fact]
    public void Test1()
    {
        //arrane
        var plr = new InMemoryPlayer("Robert", "Lewandowski", "FC");
        plr.AddRating("8+");
        plr.AddRating("1.5");
        plr.AddRating("7");
        //act
        var result = plr.GetStatistics();
        //assert
        Assert.Equal(5.7, result.Average, 1);
        Assert.Equal(8.5, result.Best);
        Assert.Equal(1.5, result.Worst);
        Assert.Equal(17, result.Sum);
    }

    [Fact]
    public void Test2()
    {
        var plr1 = Player("Roberto", "Baggio", "ST");
        var plr2 = Player("Alessandro", "Del Piero", "ST");
        var plr3 = Player("Sebastian", "Szymañski", "MC");
        var plr4 = Player("Sebastian", "Szymañski", "MC");

        Assert.NotSame(plr2, plr1);
        Assert.False(Object.ReferenceEquals(plr2, plr1));
        Assert.NotSame(plr4, plr3);
    }

    private SavedPlayer Player(string name, string surname, string position)
    {
        return new SavedPlayer(name, surname, position);
    }
}