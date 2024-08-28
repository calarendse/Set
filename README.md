# Set

Implementation of the card game Set (see <https://en.wikipedia.org/wiki/Set_(card_game)>).

## Description

This implementation of the card game Set is playable with 1 or more players. The game begins with 12 cards from the 82-card deck shown. The goal of the game is to discover all sets of 3 cards. A valid set is one which has all the same features (shape, color, number, and shading) or all different features. The first player to think of a set gets to guess. If a set is correctly guessed, the player is rewarded with one point and the 3 cards are replaced with cards from the deck. If a set is guessed incorrectly, one point is deducted from the player's score. If all players are unable to find a set from the 12 cards, 3 more cards can be added. The player with the highest score wins.

## Getting Started

### Depedencies

* .NET 8
* xUnit

### Installing

* Clone this repository to your local machine.

### Executing Program

* To start the game open any command line in the directory of the cloned repository
* Change directories to the Set folder
* Run the program by executing

```bash
dotnet run
```

* To run the unit tests, open a command line in the directory of the cloned repository
* Execute the command

```bash
dotnet test
```

## Authors

Caleb Arendse
[calarendse] (https://github.com/calarendse)
