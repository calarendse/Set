using Xunit.Abstractions;

namespace Set.Tests;
public class SetGame_ValidSetShould {
    private readonly SetGame _game;
    private readonly ITestOutputHelper output; 
    public SetGame_ValidSetShould(ITestOutputHelper output) {
        this.output = output;
        _game = new SetGame();
        _game.Players.Add(new Player("p1"));
        _game.Players[0].Score++;
        _game.StartGame();        
    }

    [Theory]
    [InlineData(0, 3, 7)]
    [InlineData(10, 3, 7)]
    [InlineData(10, 7, 3)]
    [InlineData(3, 10, 7)]
    [InlineData(3, 7, 10)]
    [InlineData(7, 3, 10)]
    [InlineData(7, 10, 3)]
    [InlineData(0, 1, 2)]
    [InlineData(0, 2, 1)]
    [InlineData(2, 4, 5)]
    [InlineData(2, 5, 4)]
    [InlineData(4, 2, 5)]
    [InlineData(4, 5, 2)]
    [InlineData(5, 2, 4)]
    [InlineData(2, 5, 11)]
    [InlineData(2, 11, 5)]
    [InlineData(5, 2, 11)]
    [InlineData(5, 11, 2)]
    [InlineData(11, 2, 5)]
    [InlineData(11, 5, 2)]
    [InlineData(5, 6, 8)]
    [InlineData(8, 5, 6)]
    public void Set_ValidSet_Invalid(int cardOne, int cardTwo, int cardThree) {
       output.WriteLine($"{_game.Table[cardOne]}\n{_game.Table[cardTwo]}\n{_game.Table[cardThree]}");
       bool actual = _game.ValidSet(0, cardOne, cardTwo, cardThree);
       Assert.False(actual);
       Assert.Equal(0, _game.Players[0].Score);
    }
    [Theory]
    [InlineData(0, 6, 8)]
    [InlineData(0, 8, 6)]
    [InlineData(6, 0, 8)]
    [InlineData(6, 8, 0)]
    [InlineData(8, 0, 6)]
    [InlineData(8, 6, 0)]
    [InlineData(1, 9, 10)]
    [InlineData(1, 10, 9)]
    [InlineData(10, 9, 1)]
    [InlineData(10, 1, 9)]
    [InlineData(9, 10, 1)]
    [InlineData(9, 1, 10)]
    public void Set_ValidSet_Valid(int cardOne, int cardTwo, int cardThree){
       output.WriteLine($"{_game.Table[cardOne]}\n{_game.Table[cardTwo]}\n{_game.Table[cardThree]}");
       bool actual = _game.ValidSet(0, cardOne, cardTwo, cardThree);
       Assert.True(actual);
       Assert.Equal(2, _game.Players[0].Score);
       Assert.Equal(66, _game.Deck.Count);
       Assert.Equal(12, _game.Table.Count);
    }
    
    
}