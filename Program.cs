using ProjetNarratif;
using ProjetNarratif.Rooms;

var game = new Game();
game.Add(new Begin());
game.Add(new ennemis());
game.Add(new Village());
game.Add(new maison());
game.Add(new Cave());
game.Add(new RoadCaveAndLac());
game.Add(new CaveFight());



while (!game.IsGameOver())
{
    Console.WriteLine("--");
    Console.WriteLine(game.CurrentRoomDescription);
    string? choice = Console.ReadLine()?.ToLower() ?? "";
    Console.Clear();
    game.ReceiveChoice(choice);
}

Console.WriteLine("FIN");
Console.ReadLine();