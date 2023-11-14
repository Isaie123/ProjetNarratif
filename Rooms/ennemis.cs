
using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace ProjetNarratif.Rooms
{

    internal class ennemis : Room
    {
        int HPGoblin;
        int HPHero;
        string line = "oui";
        int gold;
        bool combat = true;
        bool attaque = true;
        Random random = new Random();


        internal override string CreateDescription()
        {
            while (!combat)
            {
                Console.WriteLine("Tu as déjà tué l'ennemi, tu décides donc de retourner au village.");
                Game.Transition<Village>();
                return string.Empty;
                

            }
            

            string description = $"{SharedData.PlayerName} decida de se rentre au camps d'ennemi\n";
              description+= $"Arrive sur les lieux {SharedData.PlayerName} vit un monstre qui lui courut dessus.\n" +
             $"tu décida de l'[attaquer] ou bien de [fuir].";
            return description;
        }

        internal override void ReceiveChoice(string choice)
        {

            if (SharedData.SelectedArme == "épée")
            {
                switch (choice)
                {
                    case "attaquer":
                        while (SharedData.HealGoblin > 0 && line == "oui" && combat == true)
                        {
                            attaque = true;

                            int rmdcritique = random.Next(5);
                            if (random.Next(5) == 0)
                            {
                                Console.WriteLine($"{SharedData.PlayerName} effectue une attaque critique !");
                                HPGoblin -= SharedData.EpeeDamage * 2; // Double les dégâts pour une attaque critique
                                HPGoblin = Math.Max(HPGoblin, 0);
                                Console.WriteLine($"{SharedData.PlayerName} a pu lui enlever {SharedData.EpeeDamage * 2} HP, il lui reste {HPGoblin}");
                                attaque = false;
                            }
                            if (attaque == true)
                            {


                                Console.Clear();
                                Console.WriteLine($"{SharedData.PlayerName} brandit son épée avec détermination !");
                                HPGoblin = SharedData.HealGoblin - SharedData.EpeeDamage;
                                HPGoblin = Math.Max(HPGoblin, 0);
                                Console.WriteLine($"{SharedData.PlayerName} a pu lui enlever {SharedData.EpeeDamage} HP, il lui reste {HPGoblin}");
                                SharedData.HealGoblin = HPGoblin;

                                HPHero = SharedData.HealtHero - SharedData.AttaqueGoblin;
                                HPHero = Math.Max(HPHero, 0);
                                Console.WriteLine($"Le Goblin riposte, il reste {HPHero} à {SharedData.PlayerName}");
                                SharedData.HealtHero = HPHero;
                            }

                            if (HPGoblin == 0)
                            {
                                Console.WriteLine("Bravo, tu as réussi à le tuer !");
                                Console.WriteLine("Tu as obtenu 50 gold.");
                                Console.WriteLine("Après cette victoire, tu décides de retourner au village.");
                                gold = 100;
                                SharedData.Gold += gold;
                                combat = false;
                                Game.Transition<Village>();
                                return;
                            }
                        }
                            Console.WriteLine("Voulez-vous réattaquer ? Si vous écrivez [oui], sinon écrivez [non]");
                            line = Console.ReadLine().ToLower();

                            if (line == "non")
                            {
                                Console.WriteLine($"{SharedData.PlayerName} décida de courir le plus rapidement pour le semer.");
                                Game.Transition<Village>();
                                return;
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

            if (SharedData.SelectedArme == "longue épée")
            {
                switch (choice)
                {
                    case "attaquer":
                        while (SharedData.HealGoblin > 0 && line == "oui")
                        {
                            attaque = true;
                            Console.WriteLine($"{SharedData.PlayerName} manie sa longue épée avec élégance !");

                            int rdmattaque = random.Next(2);
                            int rmdcritique = random.Next(5);

                            if (rmdcritique == 0 && rdmattaque == 0)
                            {
                                Console.WriteLine($"{SharedData.PlayerName} effectue une attaque critique !");
                                HPGoblin = SharedData.HealGoblin- SharedData.LongueEpee * 2; // Double les dégâts pour une attaque critique
                                Console.WriteLine($"{SharedData.PlayerName} a pu lui enlever {SharedData.LongueEpee} HP, il lui reste {HPGoblin}");
                                attaque=false;  
                            }
                            
                            if (rdmattaque == 0&& attaque==true)
                            {
                                Console.Clear();
                                HPGoblin = SharedData.HealGoblin - SharedData.LongueEpee;
                                HPGoblin = Math.Max(HPGoblin, 0);
                                Console.WriteLine($"{SharedData.PlayerName} a pu lui enlever {SharedData.LongueEpee} HP, il lui reste {HPGoblin}");
                                SharedData.HealGoblin = HPGoblin;
                                HPHero = SharedData.HealtHero - SharedData.AttaqueGoblin;
                                HPHero = Math.Max(HPHero, 0);
                                Console.WriteLine($"Le Goblin a aussi attaqué, il reste {HPHero} à {SharedData.PlayerName}");
                                SharedData.HealtHero = HPHero;
                            }
                           
                            if (HPGoblin == 0)
                                {
                                    Console.WriteLine("Bravo, tu as réussi à le tuer!");
                                    gold = 100;
                                SharedData.Gold += gold;
                                Console.WriteLine($"Tu as obtenu {SharedData.Gold} gold.");
                                    combat = false;
                                    Game.Transition<Village>();
                                    return;
                                }
                            
                            else
                            {
                                Console.WriteLine("Tu n'as pas pu attaquer cette fois malheureusement.");
                                HPHero = SharedData.HealtHero - SharedData.AttaqueGoblin;
                                HPHero = Math.Max(HPHero, 0);
                                Console.WriteLine($"Le Goblin a attaqué, il reste {HPHero} à {SharedData.PlayerName}");
                                SharedData.HealtHero = HPHero;
                            }

                            Console.WriteLine("Voulez-vous réattaquer ? Si vous écrivez [oui], sinon écrivez [non]");
                            line = Console.ReadLine().ToLower();
                            if (line == "non")
                            {
                                Console.Clear();
                                Console.WriteLine($"{SharedData.PlayerName} décida de courir le plus rapidement pour semer l'ennemi.");
                                Game.Transition<Village>();
                                return;
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