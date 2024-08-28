using Set;

Console.WriteLine("Welcome to the game of Set!");
Console.WriteLine("---------------------------");
Console.WriteLine();
Console.WriteLine("Select an option: ");
Console.WriteLine("S - Start Game");
Console.WriteLine();
Console.WriteLine("Press any other key to quit");

var entry = Console.ReadLine();
if(entry == null) 
    return;
if(!entry.Equals("S"))  {
    Console.WriteLine("Exiting game"); 
    return;
}

Console.WriteLine("Starting Game");
var game = new SetGame();

Console.Write("Enter number of players: ");
var enteredNumPlayers = Console.ReadLine();
if(enteredNumPlayers == null) 
    return;

int numPlayers = Convert.ToInt32(enteredNumPlayers);
Console.WriteLine($"Starting game with {numPlayers} player");
for(int i = 0; i < numPlayers; i++){
    Console.Write($"Enter name for player {i + 1}: ");
    var name = Console.ReadLine();
    if(name != null) {
        game.Players.Add(new Player(name));
    }
}
game.StartGame();

for(int i = 1; i < 13; i++){
    Console.WriteLine($"{i}: {game.Table[i-1]}");
}

Console.WriteLine("Options: ");
Console.WriteLine("S - SET!");
Console.WriteLine("Q - Quit game");
Console.Write("Enter: ");
var choice = Console.ReadLine();
if (choice == null) return;

while(choice.Equals("S")){
    Console.WriteLine("Choose player: ");
    for(int i = 1; i < game.Players.Count + 1; i++){
        Console.WriteLine($"{i}: {game.Players[i-1].Name}");
    }
    var cardIndices = new List<int>();

    while(cardIndices.Count < 3){
        Console.Write($"Enter position of card: ");
        var input = Console.ReadLine();
        if(input is null){
            Console.WriteLine("Invalid input");
            continue;
        }
        if (!int.TryParse(input, out int cardPosition))
        {
            Console.WriteLine("Invalid input");
            continue;
        }
        if (cardPosition > 12){
            Console.WriteLine("Invalid input");
            continue;
        }
        cardIndices.Add(cardPosition - 1);
    }

    if(game.ValidSet(0, cardIndices[0], cardIndices[1], cardIndices[2])){
        Console.WriteLine("The entered set was correct!");
    }else{
        Console.WriteLine("The entered set was incorrect");
    }
    Console.WriteLine("Scoreboard:");
    for(int i = 1; i < game.Players.Count+1; i++){
        Console.WriteLine($"Name: {game.Players[i-1].Name}: Score: {game.Players[i-1].Score}");
    }
    Console.WriteLine("Options: ");
    Console.WriteLine("S - SET!");
    Console.WriteLine("Q - Quit game");
    Console.Write("Enter: ");
    choice = Console.ReadLine();
    if (choice == null) return;
}
Console.WriteLine("Final Scoreboard");
for(int i = 1; i < game.Players.Count+1; i++){
    Console.WriteLine($"Name: {game.Players[i-1].Name}: Score: {game.Players[i-1].Score}");
}
Console.WriteLine("Thanks for playing!");