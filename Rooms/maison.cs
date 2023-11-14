using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class maison : Room
    {
        internal override string CreateDescription()
        {
            string description = "Tu as decide de retourne chez toi cela te permette de [changer] d'arme si tu le shouaite \n";
            description += "Sinon tu peux toujour retourne au [village]";
            return description;
        }

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "changer":
                    Console.Write("Tu veux choisir qu'elle arme maintenant");
                    Console.WriteLine("\nl'[épée] ou bien la [longue épée]");
                    string ChoiceArme = Convert.ToString(Console.ReadLine().ToLower());

                    if (ChoiceArme == "epee" || ChoiceArme == "épée")
                    {
                        Console.WriteLine($"En regardant l'épée, {SharedData.PlayerName} a remarqué qu'elle faisait {SharedData.EpeeDamage} dégâts.");
                        Console.WriteLine("Écris [continuer] pour la prendre ou [changer] pour voir l'autre.");
                        string line = Console.ReadLine().ToLower();
                        if (line == "continuer")
                        {
                            Console.WriteLine("Tu as décidé de prendre l'épée, bon choix");
                            SharedData.SelectedArme = "épée";

                        }
                        else if (line == "changer")
                        {
                            Console.WriteLine("Tu as décidé d'aller voir l'autre arme, pas de problème.");
                            Console.WriteLine($"D'abord, la longue épée fait {SharedData.LongueEpee} dégâts, mais elle touche une fois sur deux.");
                            Console.WriteLine("Maintenant, tu décides de prendre quelle arme : l'[épée] ou la [longue épée].");
                            line = Console.ReadLine().ToLower();
                            if (line == "epee" || line == "épée")
                            {
                                Console.WriteLine("Tu as décidé de prendre l'épée, bon choix");
                                SharedData.SelectedArme = "épée";

                            }
                            else if (line == "longue epee" || line == "longue épée")
                            {
                                Console.WriteLine("Tu as décidé de prendre la longue épée, bon choix");
                                SharedData.SelectedArme = "longue épée";

                            }
                            else
                            {
                                Console.WriteLine("Choix incorrect, veuillez réessayer.");
                            }
                        }
                        break;
                    }

                    if (ChoiceArme == "longue epee" || ChoiceArme == "longue épée")
                    {
                        Console.WriteLine($"En regardant la longue épée, {SharedData.PlayerName} a remarqué qu'elle fait {SharedData.LongueEpee} dégâts, mais elle touche une fois sur deux.");
                        Console.WriteLine("Écris [continuer] pour la prendre ou [changer] pour voir l'autre.");
                        string line = Console.ReadLine().ToLower();
                        if (line == "continuer")
                        {
                            Console.WriteLine("Tu as décidé de prendre la longue épée, bon choix");
                            SharedData.SelectedArme = "longue épée";

                        }
                        else if (line == "changer")
                        {
                            Console.WriteLine("Tu as décidé d'aller voir l'autre arme, pas de problème.");
                            Console.WriteLine($"D'abord, l'épée fait {SharedData.EpeeDamage} dégâts.");
                            Console.WriteLine("Maintenant, tu décides de prendre quelle arme : l'[épée] ou la [longue épée].");
                            line = Console.ReadLine().ToLower();
                            if (line == "epee" || line == "épée")
                            {
                                Console.WriteLine("Tu as décidé de prendre l'épée, bon choix");
                                SharedData.SelectedArme = "épée";

                            }
                            else if (line == "longue epee" || line == "longue épée")
                            {
                                Console.WriteLine("Tu as décidé de prendre la longue épée, bon choix");
                                SharedData.SelectedArme = "longue épée";

                            }
                            else
                            {
                                Console.WriteLine("Choix incorrect, veuillez réessayer.");
                            }
                        }
                        break;
                    } break;

                case "village":
                    Console.Clear();
                    Game.Transition<Village>();
                    break;

               

                default:
                    Console.WriteLine("Choix incorrect, veuillez réessayer.");
                        Console.WriteLine("Choisissez entre l'[épée] ou la [longue épée] ou [village]");
                        choice = Console.ReadLine().ToLower();
                        break;
                    
            }


        }
    }
}
