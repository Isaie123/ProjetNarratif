
using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace ProjetNarratif.Rooms
{

    internal class ennemis : Room
    {
        
        string line = "oui";
        int gold;
        bool combat = true;
        bool attaque = true;
        Random random = new Random();

        internal override string CreateDescription()
        {
            if (!combat)
            {
               
                Console.WriteLine("Tu as déjà tué l'ennemi, tu décides donc de retourner au village.");
                Game.Transition<Village>();
                return string.Empty;
            }
           
            string description = $"{SharedData.PlayerName} décida de se rendre au camp de l'ennemi.\n";
            description += $"Arrivé sur les lieux, {SharedData.PlayerName} vit un monstre qui lui courut dessus.\n" +
                            $"Tu décides de l'[attaquer] ou bien de [fuir].";
            return description;
        }

        internal override void ReceiveChoice(string choice)
        {
            if (SharedData.SelectedArme == "épée")
            {
                switch (choice)
                {
                    case "attaquer":
                        while (SharedData.HealGoblin > 0 && line == "oui" && combat)
                        {
                            
                            attaque = true;

                            int rmdcritique = random.Next(5);
                            if (rmdcritique == 0)
                            {
                                
                                Console.WriteLine($"{SharedData.PlayerName} effectue une attaque critique !");
                                SharedData.HealGoblin-= SharedData.EpeeDamage * 2; // Double les dégâts pour une attaque critique
                                SharedData.HealGoblin= Math.Max(SharedData.HealGoblin, 0);
                                Console.WriteLine($"{SharedData.PlayerName} a pu lui enlever {SharedData.EpeeDamage * 2} HP, il lui reste {SharedData.HealGoblin}");
                                attaque = false;
                            }

                            if (attaque)
                            {
                                
                               
                               
                                Console.WriteLine($"{SharedData.PlayerName} brandit son épée avec détermination !");
                                SharedData.HealGoblin -= SharedData.EpeeDamage;
                                SharedData.HealGoblin = Math.Max(SharedData.HealGoblin, 0);
                                Console.WriteLine($"{SharedData.PlayerName} a pu lui enlever {SharedData.EpeeDamage} HP, il lui reste {SharedData.HealGoblin}");


                                SharedData.HealtHero -= SharedData.AttaqueGoblin;
                                SharedData.HealtHero = Math.Max(SharedData.HealtHero, 0);
                                Console.WriteLine($"Le Goblin riposte, il te reste {SharedData.HealtHero} HP {SharedData.PlayerName}");
                                
                            }

                            if (SharedData.HealGoblin <= 0)
                            {
                                Console.Clear();
                                
                                Console.WriteLine("Bravo, tu as réussi à le tuer !");
                                gold = 100;
                                SharedData.Gold += gold;
                                Console.WriteLine($"Tu as obtenu {gold} gold.");
                                Console.WriteLine("Après cette victoire tu décida de retrourner au village");
                                combat = false;
                                Game.Transition<Village>();
                                break;
                            }

                            Console.WriteLine("Voulez-vous réattaquer ? Si vous écrivez [oui], sinon écrivez [non]");
                           
                            line = Console.ReadLine().ToLower();
                            Console.Clear();

                            if (line == "non")
                            {
                                Console.WriteLine($"{SharedData.PlayerName} décida de courir le plus rapidement pour le semer.");
                                line = "oui";
                                Game.Transition<Village>();
                                break;
                            }
                        }
                        break;

                    case "fuir":
                        Console.WriteLine($"{SharedData.PlayerName} décida de courir le plus rapidement pour semer l'ennemi.");
                        Game.Transition<Village>();
                        break;

                    default:
                        Console.WriteLine("Choix incorrect, veuillez réessayer.");
                        break;
                }
            }
            else if (SharedData.SelectedArme == "longue épée")
            {
                switch (choice)
                {
                    case "attaquer":
                        Console.WriteLine($"{SharedData.PlayerName} manie sa longue épée avec élégance !");
                        while (SharedData.HealtHero > 0 && line == "oui" && combat)
                        {
                          
                            attaque = true;
                            

                            int rdmattaque = random.Next(2);
                            int rmdcritique = random.Next(5);

                            if (rmdcritique == 0 && rdmattaque == 0)
                            {
                                
                                Console.WriteLine($"{SharedData.PlayerName} effectue une attaque critique !");
                                SharedData.HealGoblin -= SharedData.LongueEpee * 2; // Double les dégâts pour une attaque critique
                                SharedData.HealGoblin = Math.Max(SharedData.HealGoblin, 0);
                                Console.WriteLine($"{SharedData.PlayerName} a pu lui enlever {SharedData.LongueEpee} HP, il lui reste {SharedData.HealGoblin}");
                            }

                            if (rdmattaque == 0 && attaque)
                            {
                                
                                Console.Clear();
                               
                                SharedData.HealGoblin -= SharedData.LongueEpee;
                                SharedData.HealGoblin = Math.Max(SharedData.HealGoblin, 0);
                                Console.WriteLine($"{SharedData.PlayerName} a pu lui enlever {SharedData.LongueEpee} HP, il lui reste {SharedData.HealGoblin}");


                                SharedData.HealtHero -= SharedData.AttaqueGoblin;
                                SharedData.HealtHero = Math.Max(SharedData.HealtHero, 0);
                                Console.WriteLine($"Le Goblin a aussi attaqué, il te reste {SharedData.HealtHero} HP {SharedData.PlayerName}");
                               
                            }
                            else
                            {
                                Console.WriteLine("Tu n'as pas pu attaquer cette fois malheureusement.");
                                SharedData.HealtHero -= SharedData.AttaqueGoblin;
                                SharedData.HealtHero = Math.Max(SharedData.HealtHero, 0);
                                Console.WriteLine($"Le Goblin a attaqué, il te reste {SharedData.HealtHero} HP {SharedData.PlayerName}");
                                
                            }

                            if (SharedData.HealtHero == 0)
                            {
                                
                                Console.Clear();
                                Console.WriteLine("Bravo, tu as réussi à le tuer !");
                                gold = 100;
                                SharedData.Gold += gold;
                                Console.WriteLine($"Tu as obtenu {SharedData.Gold} gold.");
                                Console.WriteLine("Après cette victoire tu décida de retrourner au village");
                                combat = false;
                                Game.Transition<Village>();
                                break;
                            }
                            

                            Console.WriteLine("Voulez-vous réattaquer ? Si vous écrivez [oui], sinon écrivez [non]");
                            line = Console.ReadLine().ToLower();
                            if (line == "non")
                            {
                                
                                Console.Clear();
                                Console.WriteLine($"{SharedData.PlayerName} décida de courir le plus rapidement pour semer l'ennemi.");
                                line = "oui";
                                Game.Transition<Village>();
                                break; ;
                            }
                        }
                        break;

                    case "fuir":
                        Console.Clear();
                        Console.WriteLine($"{SharedData.PlayerName} décida de courir le plus rapidement pour semer l'ennemi.");
                        Game.Transition<Village>();
                        break;

                    default:
                        Console.WriteLine("Choix incorrect, veuillez réessayer.");
                        Console.WriteLine("Choisissez entre [attaquer] ou [fuir]");
                        choice = Console.ReadLine().ToLower();
                        break;
                }
            }
        }
    }
}