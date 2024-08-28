using Set;
namespace Set.UnitTests;

public class Card_Should {
    [Theory]
    [InlineData(Shape.Ovals, Color.Red, 0, Shading.Solid)]
    [InlineData(Shape.Ovals, Color.Purple, 0, Shading.Solid)]
    [InlineData(Shape.Ovals, Color.Green, 0, Shading.Solid)]
    public void Card_HasColorFeature(Shape shape, Color color, int number, Shading shading) {
        var card = new Card(shape, color, number, shading);
        Assert.Equal(color, card.Color);
    }
    [Theory]
    [InlineData(Shape.Ovals, Color.Red, 0, Shading.Solid)]
    [InlineData(Shape.Squiggles, Color.Red, 0, Shading.Solid)]
    [InlineData(Shape.Diamonds, Color.Red, 0, Shading.Solid)]
    public void Card_HasShapeFeature(Shape shape, Color color, int number, Shading shading) {
        var card = new Card(shape, color, number, shading);
        Assert.Equal(shape, card.Shape);
    }
    [Theory]
    [InlineData(Shape.Ovals, Color.Red, 1, Shading.Solid)]
    [InlineData(Shape.Ovals, Color.Red, 2, Shading.Solid)]
    [InlineData(Shape.Ovals, Color.Red, 3, Shading.Solid)]
    public void Card_HasNumberFeature(Shape shape, Color color, int number, Shading shading) {
        var card = new Card(shape, color, number, shading);
        Assert.Equal(number, card.Number);
    }
    [Theory]
    [InlineData(Shape.Ovals, Color.Red, 0, Shading.Solid)]
    [InlineData(Shape.Ovals, Color.Red, 0, Shading.Striped)]
    [InlineData(Shape.Ovals, Color.Red, 0, Shading.Outlined)]
    public void Card_HasShadingFeature(Shape shape, Color color, int number, Shading shading){
        var card = new Card(shape, color, number, shading);
        Assert.Equal(shading, card.Shading);
    }
}