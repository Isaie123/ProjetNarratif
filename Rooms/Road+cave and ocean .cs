using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{

    
    internal class RoadCaveAndLac: Room
    {
        bool fin = false;
        bool bombe = false;
        bool PNG = false;
        internal override string CreateDescription()
        {
            string description = $"Arrivée à une intersection, {SharedData.PlayerName} avait le choix d'aller dans trois directions.\n";
            description += $"À droite, tu as vu un [mer] avec une plaine de l'autre côté.\n";
            description += $"À gauche, tu as vu une [grotte].\n";
            description += $"Ou finalement tu souhaite retourner au [village].";
            return description;
        }
        bool fins = false;
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "mer":
                    while (!PNG)
                    {
                        Console.WriteLine($"{SharedData.PlayerName} s'approcha du lac et vit une personne");
                        Console.WriteLine("En s'approchant de plus en plus la personne la vu\n");
                        string discussionE = "??? \"La vue n'est pas magnifique n'est pas ?\n";
                        discussionE += "Cette vue sur la mer est à couper le souffle.\"\n";

                        foreach (char c in discussionE)
                        {
                            Console.Write($"{c}");
                            Thread.Sleep(40);
                        }

                        discussionE = $"\n{SharedData.PlayerName} \"C'est vrais que l'a vue est magnifique ici.\"\n";
                        Console.WriteLine(discussionE);
                        Thread.Sleep(1000);

                        discussionE = "??? \"À désoler, je me suis encore perdu dans mes pensée! Haha. Mon nom est Élénore.\n" +
                            "Puis savoir qu'est elle votre nom ?\"\n";
                        foreach (char c in discussionE)
                        {
                            Console.Write($"{c}");
                            Thread.Sleep(40);

                        }

                        Console.WriteLine($"\n{SharedData.PlayerName} \"Mon nom est {SharedData.PlayerName} content de faire votre rencontre Élénore!\"\n");
                        Thread.Sleep(1000);

                        discussionE = "Élénore fixe les yeux sur vous avec un sourire chaleureux. \n\"Je vois dans vos yeux une détermination à vous aventurer dans ce monde.\"\n";
                        discussionE += "Elle continue : \"Ce monde regorge de mystères et d'aventures, mais il peut aussi être dangereux. Soyez prêt à affronter l'inconnu et à faire des choix difficiles.\"\n";

                        foreach (char c in discussionE)
                        {
                            Console.Write($"{c}");
                            Thread.Sleep(40);
                        }
                        discussionE = $"\nÉlénore sort une vieille carte usée de sa poche et vous la tend. \n\"Prenez cette carte, {SharedData.PlayerName} vous sera utile dans votre voyage.\"\n";

                        foreach (char c in discussionE)
                        {
                            Console.Write($"{c}");
                            Thread.Sleep(60);
                        }
                        Console.WriteLine($"\n{SharedData.PlayerName} \"Merci beaucoup Élénore pour ce cadeau\"");
                        Thread.Sleep(1000);
                        SharedData.Carte = true;
                        Console.Write("Vous récupérer une ville carte\n");
                        Console.Write("Vous pouvez maintenant écrit dans la Console [carte] à tout moment et cela ouvrira la carte\n");

                        string discutionE = "\nÉlénore \"Attend avant de parir j'ai oublie de vous donner ceci\n" +
                            "voici des nageoirs pour t'aider a traverser la mer.\"\n ";

                        foreach (char c in discutionE)
                        {
                            Console.Write($"{c}");
                            Thread.Sleep(40);
                        }
                        Console.WriteLine($"\n{SharedData.PlayerName} \"Remerci encore Élénore pour ce cadeau.\"");
                        Thread.Sleep(1000);
                        SharedData.Fins = true;
                        PNG = true;
                    }
                    Game.Transition<Lac>();

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
                case "carte":
                    new Carte();
                    break;

                default:
                    Console.WriteLine("Choix incorrect, veuillez réessayer.");
                    break;
            }
         
        }
    }
}
