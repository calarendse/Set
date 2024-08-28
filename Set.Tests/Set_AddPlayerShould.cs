namespace Set.Tests;
public class SetGame_AddPlayerShould : IDisposable {
    private SetGame _game;
    public SetGame_AddPlayerShould() {
        _game = new SetGame();
    }

    public void Dispose()
    {
        _game = new SetGame();
    }

    [Fact]
    public void SetGame_AddOnePlayer() {
        _game.Players.Add(new Player("name"));
        Assert.Single(_game.Players);
    }
    [Fact]
    public void SetGame_AddOnePlayerDefaultScoreZero() {
        _game.Players.Add(new Player("name"));
        Assert.Equal(0, _game.Players[0].Score);
    }
}