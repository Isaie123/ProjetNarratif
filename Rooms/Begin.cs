using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace ProjetNarratif.Rooms
{
    internal class Begin : Room
    {
        bool RestartArme = true;
        



        internal override string CreateDescription()
        {
            Console.Write("Avant de commencer, veuillez-vous entre votre nom: ");
            string playername = Console.ReadLine();
            SharedData.PlayerName = playername;
            Console.Clear();

            string description = $"Bonjour, {SharedData.PlayerName}.\n\n";
            description += "Tu te réveilles dans ton bon lit douillet et tu remarques que le village est en panique.\n";
            description += $"Sans perdre de temps, tu décides d'aller voir un villageois pour lui demander ce qu'il se passe.\n";
            description += "Le villageois te répond avec panique : \"LA PRINCESSE A ÉTÉ KIDNAPPÉE\"\n";
            description += $"Après avoir entendu cela, une vague de détermination submerge {SharedData.PlayerName} qui décide d'aller chercher son armure.\n";
            description += $"En allant voir tes armes, {SharedData.PlayerName} remarque qu'il a le choix entre deux armes : une [épée] ou une [longue épée].";
            return description;


            
        }

        internal override void ReceiveChoice(string choice)
        {
            while (RestartArme)
            {
                switch (choice)
                {
                    case "epee":
                    case "épée":
                        Console.WriteLine($"En regardant l'épée, {SharedData.PlayerName} a remarqué qu'elle infligait 50 dégâts.");
                        Console.WriteLine("Veux-tu [continuer] et la prendre, ou [changer] pour voir l'autre option.");
                        string line = Console.ReadLine().ToLower();
                        if (line == "continuer")
                        {
                            Console.WriteLine("Tu as décidé de prendre l'épée, bon choix");
                            SharedData.SelectedArme = "épée"; 
                            RestartArme = false;
                        }
                        else if (line == "changer")
                        {
                            Console.WriteLine("Tu as décidé d'aller voir l'autre arme, pas de problème.");
                            Console.WriteLine("La longue épée inflige 100 dégâts, bien qu'elle touche une fois sur deux.");
                            Console.WriteLine("Maintenant, tu décides de prendre quelle arme : l'[épée] ou la [longue épée].");
                            line = Console.ReadLine().ToLower();
                            if (line == "epee" || line == "épée")
                            {
                                Console.WriteLine("Tu as opté pour l'épée, bon choix");
                                SharedData.SelectedArme = "épée";
                                RestartArme = false;
                            }
                            else if (line == "longue epee" || line == "longue épée")
                            {
                                Console.WriteLine("Tu as décidé de prendre la longue épée, bon choix");
                                SharedData.SelectedArme = "longue épée"; 
                                RestartArme = false;
                            }
                            else
                            {
                                Console.WriteLine("Choix incorrect, veuillez réessayer.");
                            }
                        }
                        break;

                    case "longue epee":
                    case "longue épée":
                        Console.WriteLine($"En examinant la longue épée, {SharedData.PlayerName} a perçu son incroyable talent dégâts, \n" +
                            $"mais touche une fois sur deux.");
                        Console.WriteLine("Veux-tu [continuer] et la prendre ou [changer] pour obsever l'autre arme.");
                        line = Console.ReadLine().ToLower();
                        if (line == "continuer")
                        {
                            Console.WriteLine("Tu as décidé de prendre la longue épée, bon choix");
                            SharedData.SelectedArme = "longue épée"; 
                            RestartArme = false;
                        }
                        else if (line == "changer")
                        {
                            Console.WriteLine("Tu as décidé d'aller voir l'autre arme, pas de problème.");
                            Console.WriteLine("L'épée moin impossant inflige 50 dégâts.");
                            Console.WriteLine("Maintenant, tu décides de prendre quelle arme : l'[épée] ou la [longue épée].");
                            line = Console.ReadLine().ToLower();
                            if (line == "epee" || line == "épée")
                            {
                                Console.WriteLine("Tu as opté pour l'épée, bon choix");
                                SharedData.SelectedArme = "épée"; 
                                RestartArme = false;
                            }
                            else if (line == "longue epee" || line == "longue épée")
                            {
                                Console.WriteLine("Tu as décidé degardé ton chois la longue épée, bon choix");
                                SharedData.SelectedArme = "longue épée"; 
                                RestartArme = false;
                            }
                            else
                            {
                                Console.WriteLine("Choix incorrect, veuillez réessayer.");
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Choix incorrect, veuillez réessayer.");
                        Console.WriteLine("Choisissez entre l'[épée] ou la [longue épée]");
                        choice = Console.ReadLine().ToLower();
                        break;
                }
            }

            Console.Clear();
            Game.Transition<Village>();
        }
    }
}
