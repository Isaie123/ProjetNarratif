using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Village : Room
    {
        internal override string CreateDescription()
        {
           
            string description = $"En sortant, {SharedData.PlayerName} a vu une [boutique] et des [villageois] qui se parlaient entre eux.\n";
            description += $"Il y avait également un camp d'[ennemis] un peu plus loin et un [route] en pierre.\n" +
                $"Ou retourne à [maison] pour changer d'arme";
            return description;
        }

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "boutique":
                    Console.Clear();
                    Console.WriteLine($"{SharedData.PlayerName} est entré dans la boutique et le vendeur lui a souhaité la bienvenue.");
                    Console.WriteLine($"{SharedData.PlayerName} a remarqué sur l'étagère :");
                    Console.WriteLine("- Un sac de [bombes]\n" +
                        "- Une [potion max]\n" +
                        "- Une [potion]\n" +
                        "- [Amélioration] pour l'arme ");
                    Console.WriteLine($"En voyant cela, le vendeur a demandé à {SharedData.PlayerName} quels objets il souhaitait examiner ou s'il préférait [regarder].");
                    string ChoixItem = Convert.ToString(Console.ReadLine());

                    //Bombe Boucle 
                    if (ChoixItem == "bombes")
                    {
                        if (SharedData.Gold < 5)
                        {
                            Console.Clear();
                            Console.WriteLine("Vous n'avez pas assez d'or pour acheter des bombes.");
                            Console.WriteLine("Petit indice aller battre des monstres");
                            Console.WriteLine($"{SharedData.PlayerName} est sorti de la boutique pour retourner au village.");
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine($"Après que {SharedData.PlayerName} lui ait dit qu'il aimerait voir de plus près le sac de bombes, le vendeur lui en a apporté un.");
                        Console.WriteLine($"{SharedData.PlayerName} a remarqué que le sac de bombes coûtait 5 pièces d'or pour 10 bombes à l'intérieur.");
                        Console.WriteLine($"{SharedData.PlayerName} a vérifié combien de pièces d'or il avait : {SharedData.Gold}");
                        Console.WriteLine("Le vendeur lui a demandé s'il voulait les acheter ou non.");
                        Console.WriteLine($"{SharedData.PlayerName} a répondu [oui] bien sûr ou [non] peut-être une prochaine fois.");
                        string line = Convert.ToString(Console.ReadLine());

                        if (SharedData.Gold >= 5 && line == "oui")
                        {
                            Console.Clear();
                            SharedData.Bombe += 10;
                            SharedData.Gold -= 5;
                            Console.Clear();
                            Console.WriteLine("Merci, a dit le vendeur.");
                           
                        }
                     

                        else if (line == "non")
                        {
                            Console.WriteLine($" Le vendeur a dit bye bye  a {SharedData.PlayerName}");
                        }
                    } ///End Bombe boucle
                   
                    ///Potion max Boucle 
                    if (ChoixItem == "potion max")
                    {
                    
                    if (SharedData.Gold < 25)
                    {
                            Console.Clear();
                            Console.WriteLine("Vous n'avez pas assez d'or pour acheter la potion max.");
                            Console.WriteLine("Petit indice aller battre des monstres");
                            Console.WriteLine($"{SharedData.PlayerName} est sorti de la boutique pour retourner au village.");
                            break;
                         
                    }
                        Console.Clear();
                        Console.WriteLine($"\nAprès que {SharedData.PlayerName} lui ait dit qu'il aimerait voir de plus près la potion max, le vendeur lui en a apporté une.");
                        Console.WriteLine($"{SharedData.PlayerName} a remarqué que la potion max coûtait 25 pièces d'or et restaurait tous les points de vie (HP) plus un bonus de 150 HP supplémentaires.");
                        Console.WriteLine($"{SharedData.PlayerName} a vérifié combien de pièces d'or il avait : {SharedData.Gold}");
                        Console.WriteLine("Le vendeur lui a demandé s'il voulait l'acheter, le [prendre] pour plus tard ou non.");
                        Console.WriteLine($"{SharedData.PlayerName} a répondu [oui] bien sûr ou [non] peut-être une prochaine fois.");
                        string line = Convert.ToString(Console.ReadLine());

                        if (SharedData.Gold >= 25 && line == "oui")
                        {
                            Console.Clear();
                            SharedData.HealtHero = 300;
                            SharedData.HPBonus += 150;
                            SharedData.HealtHero += SharedData.HPBonus;
                            SharedData.Gold -= 25;
                            Console.WriteLine($"Tu as maintenant {SharedData.HealtHero} HP, {SharedData.PlayerName}.");
                            Console.WriteLine("Merci, a dit le vendeur.");
                        }
                        
                        else if (line == "non")
                        {
                            Console.Clear();
                            Console.WriteLine($"Le vendeur a dit bye bye  a {SharedData.PlayerName}");
                        }
                        else if (SharedData.Gold>=25&&line == "prendre")
                        {
                            Console.Clear();
                            Console.WriteLine("Tu as decidé de prende cela te permet maintenant de te Heal en combat.");
                            SharedData.TakePotionMax+= 1;
                            SharedData.Gold -= 25;
                            Console.WriteLine($"Tu as maintenant {SharedData.TakePotionMax} potion Max dans ton sac.");
                        }
                        
                    }///End Potion Max Boucle 


                    //Boucle potion
                    if (ChoixItem == "potion")
                    {

                        if (SharedData.Gold < 25)
                        {
                            Console.Clear();
                            Console.WriteLine("Vous n'avez pas assez d'or pour acheter la potion max.");
                            Console.WriteLine("Petit indice aller battre des monstres");
                            Console.WriteLine($"{SharedData.PlayerName} est sorti de la boutique pour retourner au village.");
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine($"\nAprès que {SharedData.PlayerName} lui ait dit qu'il aimerait voir de plus près la potion, le vendeur lui en a apporté une.");
                        Console.WriteLine($"{SharedData.PlayerName} a remarqué que la potion max coûtait 15 pièces d'or et restaurait tous les points de vie (HP)");
                        Console.WriteLine($"{SharedData.PlayerName} a vérifié combien de pièces d'or il avait : {SharedData.Gold}");
                        Console.WriteLine("Le vendeur lui a demandé s'il voulait l'acheter, le [prendre] pour plus tard ou non.");
                        Console.WriteLine($"{SharedData.PlayerName} a répondu [oui] bien sûr ou [non] peut-être une prochaine fois.");
                        string line = Convert.ToString(Console.ReadLine());

                        if (SharedData.Gold >= 15 && line == "oui")
                        {
                            Console.Clear();
                            SharedData.HealtHero += 300;
                            SharedData.Gold -= 15;
                            Console.WriteLine($"Tu as maintenant {SharedData.HealtHero} HP, {SharedData.PlayerName}.");
                            Console.WriteLine("Merci, a dit le vendeur.");
                        }
                       
                        else if (line == "non")
                        {
                            Console.Clear();
                            Console.WriteLine($"Le vendeur a dit bye bye  a {SharedData.PlayerName}");
                        }
                        else if (SharedData.Gold >= 15 && line == "prendre")
                        {
                            Console.Clear();
                            Console.WriteLine("Tu as decidé de prende cela te permet maintenant de te Heal en combat.");
                            SharedData.TakePotion += 1;
                            SharedData.Gold -= 25;
                            Console.WriteLine($"Tu as maintenant {SharedData.TakePotion} potion dans ton sac.");
                        }
                       
                    }//End boucle potion


                    //Amelioration boucle 
                    if (ChoixItem == "amélioration"||ChoixItem=="amelioration")
                    {
                        Console.Clear();
                        int epeebonus = SharedData.EpeeDamage + 50;
                        Console.WriteLine($"\nAprès que {SharedData.PlayerName} lui ait dit qu'il aimerait voir de plus près l'amélioration, le vendeur lui apporta.");
                        Console.WriteLine($"{SharedData.PlayerName} a remarqué que l'amélioration coûtait 30 pièces d'or et donne \n" +
                            $"Maintenant 50 dégas de plus donc l'épée une attaque de {epeebonus} dégas.\n" +
                            $"Puis, pour la longue épée 100 d'attaque de plus donc, 200 dégas.");
                        Console.WriteLine($"{SharedData.PlayerName} a vérifié combien de pièces d'or il avait : {SharedData.Gold}");
                        Console.WriteLine("Le vendeur lui a demandé s'il voulait l'acheter ou non.");
                        Console.WriteLine($"{SharedData.PlayerName} a répondu [oui] bien sûr ou [non] peut-être une prochaine fois.");
                        string line = Convert.ToString(Console.ReadLine());

                        if (SharedData.Gold >= 30 && line == "oui")
                        {
                             if (SharedData.Gold < 30)
                            {
                                Console.Clear();
                                SharedData.Gold -= 30;
                                Console.WriteLine("Vous n'avez pas assez d'or pour acheter l'amélioration.");
                                Console.WriteLine("Petit indice aller battre des monstres");
                                Console.WriteLine($"{SharedData.PlayerName} est sorti de la boutique pour retourner au village.");
                                break;
                            }
                            if (SharedData.SelectedArme == "épée")
                            {
                                Console.Clear();
                                SharedData.EpeeDamage += 50;
                                Console.WriteLine($"Tu fait maintenant {SharedData.EpeeDamage} {SharedData.PlayerName}.");
                                Console.WriteLine("Merci, a dit le vendeur.");
                               
                               
                            }

                            if (SharedData.SelectedArme == "longue épée")
                            {
                                Console.Clear();
                                SharedData.LongueEpee += 100;
                                Console.WriteLine($"Tu fait maintenant {SharedData.LongueEpee} {SharedData.PlayerName}.");
                                Console.WriteLine("Merci, a dit le vendeur.");
                                
                                
                            }
                            break;
                        }
                      
                        else if (line == "non")
                        {
                            Console.WriteLine($"Le vendeur a dit bye bye  a {SharedData.PlayerName}");
                        }

                    }

                    Console.WriteLine($"{SharedData.PlayerName} est sorti de la boutique pour retourner au village.");
                    break;

                case "villageois":
                    Console.Clear();
                    Console.WriteLine("Tu t'aprochais des villageois qui discutait et tu as entendu\n" +
                        "Pour dévoiler le chemin caché et atteindre le trésor secret, souviens-toi de ces mots : Tourne à  droite, puis encore à droite, " +
                        "ensuite prends à gauche, avance vers le milieu, et enfin, dirige-toi à gauche. " +
                        "Sauras-tu suivre ces directives  pour découvrir la voie qui te mènera à la victoire ?");
                    Console.WriteLine($"\n{SharedData.PlayerName} decida de ce souvenir de ces direction car peut-être que ça vas être utile");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "ennemis":
                    Game.Transition<ennemis>();
                    break;

                case "route":
                    Game.Transition<RoadCaveAndLac>();
                    break;

                case "maison":
                    Game.Transition<maison>();
                    break;


                default:
                    Console.WriteLine("Choix incorrect.");
                    break;
            }
            
        }
    }
}