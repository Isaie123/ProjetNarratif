using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    
    internal class Village : Room
    {
        int epeebonus = 50;
        int longueswordbonus = 100;
        
        internal override string CreateDescription()
        {
          
            string description = $"En sortant, {SharedData.PlayerName} vu une [boutique] et des [villageois] qui se parlaient entre eux.\n";
            description += $"Il y avait également un camp d'[ennemis] un peu plus loin et une [route] en pierre. sinon au loin tu vois une [forêt]\n" +
                $"Ou tu peux toujours retourne à [maison] pour changer d'arme";
            return description;
        }
        

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "boutique":
                   
                    Console.Clear();
                   
                    Console.WriteLine($"{SharedData.PlayerName} entra dans la boutique et le vendeur lui souhait la Bienvenue.");
                        Console.WriteLine($"{SharedData.PlayerName} remarque sur l'étagère :");
                        Console.WriteLine("- Un sac de [bombes] à 5 golds\n" +
                            "- Une [potion max] à 25 golds \n" +
                            "- Une [potion] à 15 golds \n" +
                            "- Une [amélioration] pour son arme à 30 golds\n");

                        Console.WriteLine($"\n{SharedData.PlayerName} regarda sa sacoche, et indique que tu as {SharedData.Gold} gold\n");
                        Console.WriteLine($"En voyant cela, le vendeur demande si tu souhaite examiner certains \n" +
                            $"objets ou peut-être simplement regarder au tour et [quitté].");
                        string ChoixItem = Console.ReadLine();

                        //Bombe Boucle 
                        if (ChoixItem == "bombes")
                        {
                            if (SharedData.Gold < 5)
                            {
                                Console.Clear();
                                Console.WriteLine("Vous n'avez pas assez de gold pour acheter des bombes.");
                                Console.WriteLine("Petit indice aller battre des monstres");
                                Console.WriteLine($"{SharedData.PlayerName} est sorti de la boutique pour retourner au village.");
                                break;
                            }
                            Console.Clear();
                            Console.WriteLine($"Après que {SharedData.PlayerName} lui ait dit \"j'aimerait voir de plus près le sac de bombes\", le vendeur lui apporta.");
                            Console.WriteLine($"Le vendeur a demandé a {SharedData.PlayerName} voulez-vous l'acheter ou non.");
                            Console.WriteLine($"{SharedData.PlayerName} répondit [oui] bien sûr ou [non] peut-être une prochaine fois.");
                            string line = Console.ReadLine();

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
                                Console.WriteLine($" Le vendeur dit bye bye à {SharedData.PlayerName}");
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
                       
                        Console.WriteLine($"Après que {SharedData.PlayerName} lui ait dit \"j'aimerait voir de plus près la potion max\", le vendeur lui apporta.");
                            Console.WriteLine($"{SharedData.PlayerName} remarque que la potion max restaure tous les points de vie (HP) plus un bonus de 150 HP supplémentaires.");
                            Console.WriteLine($"Le vendeur a demandé à {SharedData.PlayerName} voulez-vous l'acheter tout de suite, ou de le [prendre] pour plus tard ou oublier.");
                            Console.WriteLine($"{SharedData.PlayerName} a répondu [oui] bien sûr ou [non] peut-être une prochaine fois.");
                            string line = Console.ReadLine();

                            if (SharedData.Gold >= 25 && line == "oui")
                            {
                                Console.Clear();
                                SharedData.HealtHero = 300;
                                SharedData.HPBonus = 150;
                                SharedData.HealtHero += SharedData.HPBonus;
                                SharedData.Gold -= 25;
                                Console.WriteLine($"Tu as maintenant {SharedData.HealtHero} d'HP, {SharedData.PlayerName}.");
                                Console.WriteLine("Merci, a dit le vendeur.");
                            }

                            else if (line == "non")
                            {
                                Console.Clear();
                                Console.WriteLine($"Le vendeur dit bye bye à {SharedData.PlayerName}");
                            }
                            else if (SharedData.Gold >= 25 && line == "prendre")
                            {
                                Console.Clear();
                                Console.WriteLine("Tu as decidé de le prende, cela te permet maintenant de te Heal en combat.");
                                SharedData.TakePotionMax += 1;
                                SharedData.Gold -= 25;
                                Console.WriteLine($"Tu as maintenant {SharedData.TakePotionMax} potion Max dans ton sac.");
                            }

                        }///End Potion Max Boucle 


                        //Boucle potion
                        if (ChoixItem == "potion")
                        {

                            if (SharedData.Gold < 15)
                            {
                                Console.Clear();
                                Console.WriteLine("Vous n'avez pas assez d'or pour acheter la potion max.");
                                Console.WriteLine("Petit indice aller battre des monstres");
                                Console.WriteLine($"{SharedData.PlayerName} est sorti de la boutique pour retourner au village.");
                                break;
                            }

                            Console.Clear();
                        
                        Console.WriteLine($"Après que {SharedData.PlayerName} lui ait dit \"j'aimerait voir de plus près la potion\", le vendeur lui apporta.");
                            Console.WriteLine($"Le vendeur a demandé à {SharedData.PlayerName} voulez-vous l'acheter tout de suite, ou de le [prendre] pour plus tard ou oublier.");
                            Console.WriteLine($"{SharedData.PlayerName} a répondu [oui] bien sûr ou [non] peut-être une prochaine fois.");
                            string line = Console.ReadLine();

                            if (SharedData.Gold >= 15 && line == "oui")
                            {
                                Console.Clear();
                                SharedData.HealtHero = 300;
                                SharedData.Gold -= 15;
                                Console.WriteLine($"Tu as maintenant {SharedData.HealtHero} HP, {SharedData.PlayerName}.");
                                Console.WriteLine("Merci, a dit le vendeur.");
                            }

                            else if (line == "non")
                            {
                                Console.Clear();
                                Console.WriteLine($"Le vendeur dit bye bye a {SharedData.PlayerName}");
                            }
                            else if (SharedData.Gold >= 15 && line == "prendre")
                            {
                                Console.Clear();
                                Console.WriteLine("Tu as decidé de le prende cela te permet maintenant de te Heal en combat.");
                                SharedData.TakePotion += 1;
                                SharedData.Gold -= 25;
                                Console.WriteLine($"Tu as maintenant {SharedData.TakePotion} potion dans ton sac.");
                            }

                        }//End boucle potion


                        //Amelioration boucle 
                        if (ChoixItem == "amélioration" || ChoixItem == "amelioration")
                        {
                            if (SharedData.Gold < 30)
                            {
                                Console.Clear();
                                Console.WriteLine("Vous n'avez pas assez d'or pour acheter l'amélioration.");
                                Console.WriteLine("Petit indice aller battre des monstres");
                                Console.WriteLine($"{SharedData.PlayerName} est sorti de la boutique pour retourner au village.");
                                break;
                            }
                            Console.Clear();

                            epeebonus = SharedData.EpeeDamage + 50;
                            longueswordbonus = SharedData.LongueEpee + 100;
                            Console.WriteLine($"Après que {SharedData.PlayerName} lui ait dit \"j'aimerait voir de plus près l'amélioration\", le vendeur lui apporta.");
                            Console.WriteLine($"{SharedData.PlayerName} remarque que l'amélioration coûte 30 gold\n" +
                                $"Si vous avez chosi l'épée vous feriez 50 dégas de plus donc l'épée aura une attaque de {epeebonus} dégâs.\n" +
                                $"Sinon, si vous avez chosi la longue épée vous feriez 100 dégas de plus donc,{longueswordbonus} dégâs.\n");
                            Console.WriteLine($"{SharedData.PlayerName} vérifié combien de gold avait : {SharedData.Gold} gold");
                            Console.WriteLine($"Le vendeur a demandé a {SharedData.PlayerName} voulez-vous l'acheter ou non.");
                            Console.WriteLine($"{SharedData.PlayerName} a répondu [oui] bien sûr ou [non] peut-être une prochaine fois.");
                            string line = Console.ReadLine();

                            if (SharedData.Gold >= 30 && line == "oui")
                            {

                                if (SharedData.SelectedArme == "épée")
                                {
                                    Console.Clear();
                                    SharedData.EpeeDamage += 50;
                                    Console.WriteLine($"Tu fait maintenant {SharedData.EpeeDamage} dégâs {SharedData.PlayerName}.");
                                    SharedData.Gold -= 30;
                                    Console.WriteLine("Merci, dit le vendeur et bonne journée.");

                                }

                                if (SharedData.SelectedArme == "longue épée")
                                {
                                    Console.Clear();
                                    SharedData.LongueEpee += 100;
                                    SharedData.Gold -= 30;
                                    Console.WriteLine($"Tu fait maintenant {SharedData.LongueEpee} dégâs {SharedData.PlayerName}.");
                                    Console.WriteLine("Merci, dit le vendeur et bonne journée.");


                                }
                                break;
                            }

                            else if (line == "non")
                            {
                                Console.WriteLine($"Le vendeur a dit bye bye et lui shouait une bonne journée");
                            }

                        }

                        Console.WriteLine($"{SharedData.PlayerName} sorti de la boutique pour retourner au village.");
                        
                    
                    break;

              

                case "villageois":
                    Console.Clear();
                    Console.WriteLine("Tu t'approchais des villageois qui discutaient, et tu as entendu leur conversation :\n");
                    Console.WriteLine("Pour dévoiler le chemin caché et atteindre le trésor secret, souviens-toi de ces mots :");
                    Console.WriteLine("1. Tourne à droite.");
                    Console.WriteLine("2. Puis encore à droite.");
                    Console.WriteLine("3. Ensuite, prends à gauche.");
                    Console.WriteLine("4. Avance vers le milieu.");
                    Console.WriteLine("5. Et enfin, dirige-toi à gauche.\n");

                    Console.WriteLine("Sauras-tu suivre ces directives pour découvrir la voie qui te mènera à la victoire ?\n");
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

                case "carte":
                    new Carte();
                    break;

                case "forêt":
                case "foret":
                    Game.Transition<Forest>();
                    break;
                default:
                    Console.WriteLine("Choix incorrect.");
                    break;
            }
            
        }
    }
}