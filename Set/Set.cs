namespace Set;

public class SetGame
{
    public List<Card> Deck { get; private set; } = [];
    public List<Card> Table { get; } = [];
    public List<Player> Players { get; } = [];

    public void StartGame()
    {
        Deck = (
                from shape in Enum.GetValues<Shape>()
                from color in Enum.GetValues<Color>()
                from number in Enumerable.Range(1, 3)
                from shading in Enum.GetValues<Shading>()
                select new Card(shape, color, number, shading)).ToList();
        List<Card> table = [new Card(Shape.Diamonds, Color.Green, 2, Shading.Outlined),
        new Card(Shape.Diamonds, Color.Green, 2, Shading.Striped),
        new Card(Shape.Diamonds, Color.Green, 3, Shading.Striped),
        new Card(Shape.Squiggles, Color.Purple, 2, Shading.Outlined),
        new Card(Shape.Squiggles, Color.Red, 1, Shading.Outlined),
        new Card(Shape.Diamonds, Color.Purple, 2, Shading.Outlined),
        new Card(Shape.Squiggles, Color.Green, 2, Shading.Outlined),
        new Card(Shape.Diamonds, Color.Purple, 1, Shading.Solid),
        new Card(Shape.Ovals, Color.Green, 2, Shading.Outlined),
        new Card(Shape.Squiggles, Color.Red, 3, Shading.Outlined),
        new Card(Shape.Ovals, Color.Purple, 1, Shading.Solid),
        new Card(Shape.Diamonds, Color.Red, 1, Shading.Striped)];

        foreach (var card in table)
        {
            if (Deck.Remove(card))
            {
                Table.Add(card);
            }
        }
    }
    public bool ValidSet(int playerIndex, int cardOneIndex, int cardTwoIndex, int cardThreeIndex)
    {
        var (shapeOne, colorOne, numberOne, shadingOne) = Table[cardOneIndex];
        var (shapeTwo, colorTwo, numberTwo, shadingTwo) = Table[cardTwoIndex];
        var (shapeThree, colorThree, numberThree, shadingThree) = Table[cardThreeIndex];

        static bool isAllSameOrDifferent(int a, int b, int c) =>  a == b && b == c || (a ^ b ^ c) == 7 || (a ^ b ^ c) == 0;

        if (isAllSameOrDifferent((int)colorOne, (int)colorTwo, (int)colorThree) &&
           isAllSameOrDifferent((int)shapeOne, (int)shapeTwo, (int)shapeThree) &&
           isAllSameOrDifferent((int)shadingOne, (int)shadingTwo, (int)shadingThree) &&
           isAllSameOrDifferent(numberOne, numberTwo, numberThree))
        {
            new List<int>([cardOneIndex, cardTwoIndex, cardThreeIndex]).OrderDescending().ToList().ForEach(Table.RemoveAt);
            var rand = new Random();
            while (Table.Count < 12)
            {
                int i = rand.Next(0, Deck.Count);
                Table.Add(Deck[i]);
                Deck.RemoveAt(i);
            }
            Players[playerIndex].Score++;
            return true;
        }
        else
        {
            if (Players[playerIndex].Score > 0) Players[playerIndex].Score--;
            return false;
        }
    }
}
