namespace Set.Tests;
public class SetGame_StartGameShould {
    readonly SetGame game;
    public SetGame_StartGameShould() {
        game = new SetGame();
        game.StartGame();
    }

    [Theory]
    [InlineData(Shape.Ovals, Color.Red, 1, Shading.Solid)]
    [InlineData(Shape.Squiggles, Color.Purple, 2, Shading.Striped)]
    [InlineData(Shape.Diamonds, Color.Green, 3, Shading.Outlined)]
    public void SetGame_DeckCardHas4Features(Shape shape, Color color, int number, Shading shading){
        var actualCard = game.Deck.FirstOrDefault(card => card.Shape == shape && card.Color == color && card.Number == number && card.Shading == shading);
        
        if (actualCard == null)
            actualCard = game.Table.First(card => card.Shape == shape && card.Color == color && card.Number == number && card.Shading == shading);

        var expectedCard = new Card(shape, color, number, shading);
        Assert.Equal(expectedCard, actualCard);
    }

    [Theory]
    [InlineData(Shape.Ovals, Color.Red, 0, Shading.Solid)]
    [InlineData(Shape.Ovals, Color.Red, 4, Shading.Solid)]
    public void SetGame_DeckCardDoesNotHaveNumber(Shape shape, Color color, int number, Shading shading) {
        var actualCard = game.Deck.FirstOrDefault(card => card.Shape == shape && card.Color == color && card.Number == number && card.Shading == shading);
        Assert.Null(actualCard);
    }
    [Fact]
    public void SetGame_TableHas12Cards(){
        Assert.Equal(12, game.Table.Count);
    }
    [Fact]
    public void SetGame_DeckSizeIs69() {
        Assert.Equal(69, game.Deck.Count);
    }

}