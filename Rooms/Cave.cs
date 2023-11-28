using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Cave : Room
    {
        internal override string CreateDescription()
        {
            string description = "Arrivé dans la groutte tu vois trois chemains [droite], [gauche] et [milieu]\n ";
            description += "Aussi vous pouvez toujour [quitter] la grotte a tout moment";
            return description;
               
        }

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "droite":
                    Console.Clear();
                    Console.WriteLine("Tu as choisi le bon chemin.\n");
                    Console.WriteLine("Maintenant, tu as encore le choix de aller [droite], [gauche] et [milieu].");
                    string line = Convert.ToString(Console.ReadLine());
                    if (line == "droite")
                    {
                        Console.Clear();
                        Console.WriteLine("Encore le bon chemin.\n");
                        Console.WriteLine("Tu dois maintenant choisir entre [droite], [gauche] et [milieu].");
                        line = Convert.ToString(Console.ReadLine());
                        if (line == "gauche")
                        {
                            Console.Clear();
                            Console.WriteLine("Parfait, tu es sur la bonne voie.\n");
                            Console.WriteLine("Il reste à choisir entre [droite], [gauche] et [milieu].");
                            line = Convert.ToString(Console.ReadLine());
                            if (line == "milieu")
                            {
                                Console.Clear();
                                Console.WriteLine("Excellent, la victoire est proche!\n");
                                Console.WriteLine("Dernier choix : [droite], [gauche] ou [milieu].");
                                line = Convert.ToString(Console.ReadLine());
                                if (line == "gauche")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Félicitations! Tu as trouvé la voie qui mène à la victoire!");
                                    Game.Transition<CaveFight>();
                                }
                                else
                                {
                                    Console.WriteLine("Malheureusement, ce n'est pas le bon chemin. Recommence.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Mauvaise direction, essaie encore.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ce n'est pas correct, retour au début.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Erreur de parcours, recommençons.");
                    }
                    break;
                case "quitter":
                    Console.Clear();
                    Game.Transition<Village>();
                    break;
                default:
                    Console.WriteLine("Choix non valide, tu dois choisir [droite], [gauche] ou [milieu].");
                    break;
            }
        }
    }
}
