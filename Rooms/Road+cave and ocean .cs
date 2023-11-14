using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{

    
    internal class RoadCaveAndLac: Room
    {
        bool fin = false;
        bool bombe = false;
        internal override string CreateDescription()
        {
            string description = $"Arrivée à une intersection, {SharedData.PlayerName} avait le choix d'aller dans trois directions.\n";
            description += $"À droite, tu as vu un [lac] avec une plaine de l'autre côté.\n";
            description += $"À gauche, tu as vu une [grotte].\n";
            description += $"Ou finalement tu souhaite retourner au [village].";
            return description;
        }
        bool fins = false;
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "lac":
                    
                  
                    if(fin == false)
                    {
                        Console.WriteLine("Vous ne pouvez pas traverser car il vous manque quelque chose.");
                        break;
                    }
                    break;
                case "grotte":
                    if (SharedData.Bombe>=1)
                    {
                        Console.WriteLine($"Avec les bombes que {SharedData.PlayerName} a achetées,\n" +
                              $"{SharedData.PlayerName} décida de les utiliser pour faire sauter le rocher qui bloquait le chemin.");
                        Game.Transition<Cave>();
                    }
                    else if (SharedData.Bombe==0)
                    {
                        Console.WriteLine("Un gros rocher vous bloque le chemin, essayez de trouver quelque chose pour le faire sauter.");
                    }
                    break;
                case "village":
                    Console.Clear();
                    Game.Transition<Village>();
                    break;

                default:
                    Console.WriteLine("Choix incorrect, veuillez réessayer.");
                    break;
            }
         
        }
    }
}
