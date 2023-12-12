using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    
    internal class CaveFight : Room
    {
        internal override string CreateDescription()
        {
            string description = "Arrivé à la fin du chemin de la grotte, tu remarques quelqu'un devant un coffre, " +
                "\net c'est à ce moment que tu reconnais ton propre frère, tenant la princesse captive.\n";
            description += "Devant cette scène choquante, la rage augmente en toi. Tu n'as plus le choix, tu dois le [vaincre].";
            return description;
        }
        

        internal override void ReceiveChoice(string choice)
        {
            int HPBoss;
            int HPHero;
            string line;
            int gold;
            bool combat = true;
            Random random = new Random();
            bool bruler = true;
            bool geler = true;
            string[,] attaqueepee = new string[,] {
             { "[1].Coup de Tonnerre", "80", "30","Un coup puissant chargé d'électricité statique qui étourdit l'ennemi" },
             { "[2].Lame de Feu", "100", "40" ,"Une attaque enflammée qui infliger x2 a ton attaque normal prochine."},
             { "[3].Vortex Glacial", "60", "25", "rien à dire" }
};



            ////Code si il chosi l'epee
            if (SharedData.SelectedArme == "épée")
            {
                switch (choice)
                {

                    case "vaincre":

                        
                        Console.WriteLine("Tu sorta ton épée pour le défier en duel");
                        Console.WriteLine("Tu as entendu une voix te parler qui ta dit voila un cadeau pour t'aider");
                        Console.WriteLine("Premièrement, tu as obtenu un nouveau pouvoir des compétance spécial et de la mana pour les utilisés");
                        SharedData.Mana += 80;
                        Console.WriteLine("Puis, la vois ta soignier au maximum");
                        Console.WriteLine("Le combat peux commencer maintenant");
                        SharedData.HealtHero = 300;
                        while (combat && SharedData.HPBoss > 0 && SharedData.HealtHero > 0)
                        {
                            
                            Console.WriteLine($"{SharedData.PlayerName} utilise une [attaque], une [défense], l'utilisation d'un [objet] ou les compétences [spéciales]");
                            Console.SetCursorPosition(0, Console.CursorTop);
                            line = Console.ReadLine().ToLower();



                            switch (line)
                            {
                                case "attaque":

                                    if (bruler == true)
                                    {
                                        Console.Clear();
                                        HPBoss = SharedData.HPBoss - SharedData.EpeeDamage;
                                        SharedData.HPBoss = HPBoss;
                                        SharedData.HPBoss = Math.Max(HPBoss, 0);
                                        Console.WriteLine($"Avec ton épee tu lui a enlever {SharedData.EpeeDamage} HP donc, il lui reste {HPBoss} HP ");

                                        if(SharedData.HPBoss > 0)
                                        {
                                        HPHero = SharedData.HealtHero - SharedData.AttaqueBoss;
                                        SharedData.HealtHero = HPHero;
                                        SharedData.HealtHero = Math.Max(HPHero, 0);
                                        Console.WriteLine($"La Boss a aussi attaquer il t'a enlever {SharedData.AttaqueBoss} donc il te reste {HPHero}");
                                        }
                                    }
                                    if (bruler == false)
                                    {
                                        Console.Clear();
                                        HPBoss = SharedData.HPBoss - (SharedData.EpeeDamage * 2);
                                        SharedData.HPBoss = HPBoss;
                                        SharedData.HPBoss = Math.Max(HPBoss, 0);
                                        Console.WriteLine($"Avec ton épee tu lui a enlever {SharedData.EpeeDamage * 2} HP donc, il lui reste {HPBoss} ");
                                        if (SharedData.HPBoss > 0)
                                        {
                                        HPHero = SharedData.HealtHero - SharedData.AttaqueBoss;
                                        SharedData.HealtHero = HPHero;
                                        SharedData.HealtHero = Math.Max(HPHero, 0);
                                        Console.WriteLine($"La Boss a aussi attaquer il t'a enlever {SharedData.AttaqueBoss} donc il te reste {HPHero}");
                                        bruler = true;
                                        }



                                    }
                                    break;

                                case "défense":
                                case "defense":

                                    int rdmattaque = random.Next(2);

                                    if (rdmattaque == 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Avec la rage tu as pu te défendre même si son attaque était forte");
                                        Console.WriteLine("Grâce à ta défence tu as pu trouver une ouverture pour l'attaquer un peux");
                                        HPBoss = SharedData.HPBoss - 30;
                                        SharedData.HPBoss = HPBoss;
                                        SharedData.HPBoss = Math.Max(HPBoss, 0);
                                        Console.WriteLine($"Grâce à l'ouverture tu as pu lui enlever 30HP donc, il lui reste {HPBoss}");


                                    }
                                    else
                                    {
                                        Console.WriteLine("Tu as éssaie de te défendre mais son attaque était trop rapide tu la bloquer mais il t'a toucher avant.");
                                        HPHero = SharedData.HealtHero - 20;
                                        SharedData.HealtHero = HPHero;
                                        HPHero = Math.Max(HPHero, 0);
                                        Console.WriteLine($"Maleureusement tu as perdu 20HP donc il te reste {HPHero}");


                                    }
                                    break;

                                case "objet":
                                    Console.WriteLine("Tu as ouvert ton sac et tu remarqua que tu avais:\n" +
                                    $"-Potion: {SharedData.TakePotion} \n" +
                                    $"-Potion Max {SharedData.TakePotionMax}\n" +
                                    $"Vous voulez utiliser quoi une [potion] ou une [potion max] ou [rien]");
                                    string choiceIteam = Convert.ToString(Console.ReadLine().ToLower());

                                    switch (choiceIteam)
                                    {
                                        case "potion":

                                            if (SharedData.TakePotion > 0)
                                            {
                                                Console.Write("Tu as pris un potion pour te soignier");
                                                SharedData.HealtHero = 300;
                                                SharedData.TakePotion -= 1;
                                                Console.WriteLine($"Tu as repris tout t'a vie tu es rendu a {SharedData.HealtHero} ");
                                                
                                            }
                                            else
                                            {
                                                Console.WriteLine("Tu n'a plus de potion ");
                                            }
                                            break;

                                        case "potion max":

                                            if (SharedData.TakePotionMax > 0)
                                            {
                                                Console.Write("Tu as pris un potion Max pour te soignier");
                                                SharedData.HealtHero = 300;
                                                SharedData.HPBonus = 150;
                                                SharedData.HealtHero += SharedData.HPBonus;
                                                SharedData.TakePotion -= 1;
                                                Console.WriteLine($"Tu as repris tout t'a vie tu es rendu a {SharedData.HealtHero} ");

                                            }
                                            else
                                            {
                                                Console.WriteLine("Tu n'a plus de potion max ");

                                            }
                                            break;

                                        case"rien":
                                            break;
                                    }
                                    break;

                                case "spéciales":
                                case "speciales":
                                    Console.Clear();
                                    Console.Write($"Tu as {SharedData.Mana} de manas donc réflichi bien\n");
                                    Console.WriteLine($"{SharedData.PlayerName} dans les chois proposer choisi le numéro de l'attaque spécial que tu veux faire\n");

                                    for (int i = 0; i < attaqueepee.GetLength(0); i++)////affiher 
                                    {

                                        Console.WriteLine($"Nom: {attaqueepee[i, 0]}, Dégâts: {attaqueepee[i, 1]}, Mana requis: {attaqueepee[i, 2]}, Description: {attaqueepee[i, 3]}");

                                    }


                                    string input = Console.ReadLine();
                                    int choix = Convert.ToInt32(input) - 1;

                                    if (choix >= 0 && choix < attaqueepee.GetLength(0))
                                    {
                                        Console.WriteLine($"Tu as chosis {attaqueepee[choix, 0]}!");


                                        switch (choix)
                                        {
                                            case 0:///Attaque Tonnerre
                                                Console.Clear();
                                                Console.WriteLine($"Vous avez choisi d'utiliser {attaqueepee[choix, 0]}!");

                                                Console.WriteLine("Avec l'attque Coup de Tonnerre  ");

                                                HPBoss = SharedData.HPBoss - 80;
                                                SharedData.HPBoss = HPBoss;
                                                SharedData.HPBoss = Math.Max(HPBoss, 0);
                                                Console.WriteLine($"Tu lui as enlever 80 HP donc, il lui reste {HPBoss} ");
                                                if (SharedData.HPBoss > 0)
                                                {
                                                HPHero = SharedData.HealtHero - 10;
                                                SharedData.HealtHero = HPHero;
                                                Console.WriteLine($"Comme tu l'a étourdit il ta juste enlever 10HP il te reste {SharedData.HealtHero}\n");
                                                SharedData.Mana -= 30;
                                                SharedData.HealtHero = Math.Max(HPHero, 0);
                                                }
                                                break;

                                            case 1:///Attaque feu
                                                Console.Clear();
                                                Console.WriteLine("Avec l'attque Lame de Feue  ");

                                                HPBoss = SharedData.HPBoss - 100;
                                                SharedData.HPBoss = HPBoss;
                                                SharedData.HPBoss = Math.Max(HPBoss, 0);
                                                Console.WriteLine($"Tu lui a enlever 100 HP donc, il lui reste {HPBoss} ");
                                                Console.WriteLine("Comme tu l'a enflammée ton attaque normal prochaine infligera x2 de dégas");
                                                Console.Write("Comme tu l'a brulé il n'a pas pu attaquer\n");
                                                bruler = false;
                                                SharedData.Mana -= 40;
                                                break;

                                            case 2://Attaque Votex Glacial
                                                Console.Clear();
                                                Console.WriteLine($"Vous avez choisi d'utiliser {attaqueepee[choix, 0]}!");



                                                Console.WriteLine("Avec l'attque Vortex Glacial  ");

                                                HPBoss = SharedData.HPBoss - 60;
                                                SharedData.HPBoss = HPBoss;
                                                SharedData.HPBoss = Math.Max(HPBoss, 0);
                                                Console.WriteLine($"Tu lui a enlever 60 HP donc, il lui reste {HPBoss} ");
                                                if (SharedData.HPBoss > 0)
                                                {
                                                HPHero = SharedData.HealtHero - SharedData.AttaqueBoss;
                                                SharedData.HealtHero = HPHero;
                                                Console.WriteLine($"Comme il l'attaque a rien de spécial le boss ta attaquer donc, il te reste {SharedData.HealtHero} HP\n");
                                                }


                                                SharedData.Mana -= 25;
                                                break;


                                            default:
                                                Console.WriteLine("Action non reconnue.");
                                                continue;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                }////Fin boucle pour l'epee


                /////Code pour si il chosie la longue épéee
                if (SharedData.SelectedArme == "longue épée")
                {
                    while (combat && SharedData.HPBoss > 0 && SharedData.HealtHero > 0)
                    {
                        Console.WriteLine($"{SharedData.PlayerName} utilise une [attaque], une [défense], l'utilisation d'un [objet] ou les compétences [spéciales]");
                        line = Console.ReadLine().ToLower();



                        switch (line)
                        {
                            case "attaque":

                                if (bruler == true)
                                { 
                                    int rdmattaque = random.Next(2);

                                    if (rdmattaque == 0)
                                    {
                                        Console.Clear();
                                        HPBoss = SharedData.HPBoss - SharedData.LongueEpee;
                                        SharedData.HPBoss = HPBoss;
                                        SharedData.HPBoss = Math.Max(HPBoss, 0);
                                        Console.WriteLine($"Avec ta longue épée tu lui a enlever {SharedData.LongueEpee} HP donc, il lui reste {HPBoss} HP ");
                                        if (SharedData.HPBoss > 0)
                                        {
                                            HPHero = SharedData.HealtHero - SharedData.AttaqueBoss;
                                            SharedData.HealtHero = HPHero;
                                            SharedData.HealtHero = Math.Max(HPHero, 0);
                                            Console.WriteLine($"La Boss a aussi attaquer il t'a enlever {SharedData.AttaqueBoss} donc il te reste {HPHero}");
                                        }
                                    }
                                    else
                                    {
                                        Console.Write("Tu n'as pas pu attaquer cette fois malheureusement.");

                                    }

                                }
                                if (bruler == false)
                                {
                                    Console.Clear();
                                    HPBoss = SharedData.HPBoss - (SharedData.LongueEpee * 2);
                                    SharedData.HPBoss = HPBoss;
                                    SharedData.HPBoss = Math.Max(HPBoss, 0);
                                    Console.WriteLine($"Avec ta épée tu lui a enlever {SharedData.LongueEpee * 2} HP donc, il lui reste {HPBoss} ");
                                    if (SharedData.HPBoss > 0)
                                    {
                                        HPHero = SharedData.HealtHero - SharedData.AttaqueBoss;
                                        SharedData.HealtHero = HPHero;
                                        SharedData.HealtHero = Math.Max(HPHero, 0);
                                        Console.WriteLine($"La Boss a aussi attaquer il t'a enlever {SharedData.AttaqueBoss} donc il te reste {HPHero}");
                                        bruler = true;
                                    }



                                }
                                break;

                            case "défense":
                            case "defense":

                                int rdmdefence = random.Next(2);

                                if (rdmdefence == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Avec la rage tu as pu te défendre même si son attaque était forte");
                                    Console.WriteLine("Grâce à ta défence tu as pu trouver une ouverture pour l'attaquer un peux");
                                    HPBoss = SharedData.HPBoss - 20;
                                    SharedData.HPBoss = HPBoss;
                                    SharedData.HPBoss = Math.Max(HPBoss, 0);
                                    Console.WriteLine($"Grâce à l'ouverture tu as pu lui enlever 20HP donc, il lui reste {HPBoss}");


                                }
                                else
                                {
                                    Console.WriteLine("Tu as éssaie de te défendre mais son attaque était trop rapide tu la bloquer mais il t'a toucher avant.");
                                    HPHero = SharedData.HealtHero - 30;
                                    SharedData.HealtHero = HPHero;
                                    HPHero = Math.Max(HPHero, 0);
                                    Console.WriteLine($"Maleureusement tu as perdu 30HP donc il te reste {HPHero}");


                                }
                                break;

                            case "objet":
                                Console.Write("Tu as ouvert ton sac et tu remarqua que tu avais:\n" +
                                $"-Potion: {SharedData.TakePotion} \n" +
                                $"-Potion Max {SharedData.TakePotionMax}\n" +
                                $"Vous voulez utiliser quoi [potion] ou [potion max]");
                                string choiceIteam = Convert.ToString(Console.ReadLine().ToLower());
                                if (choiceIteam == "potion" && SharedData.TakePotion > 0)
                                {
                                    Console.Write("Tu as pris un potion pour te soignier");
                                    SharedData.HealtHero = 300;
                                    SharedData.TakePotion -= 1;
                                    Console.WriteLine($"Tu as repris tout t'a vie tu es rendu a {SharedData.HealtHero} ");

                                }

                                else if (choiceIteam == "potion max" && SharedData.TakePotionMax > 0)
                                {
                                    Console.Write("Tu as pris un potion Max pour te soignier");
                                    SharedData.HealtHero = 300;
                                    SharedData.HPBonus = 150;
                                    SharedData.HealtHero += SharedData.HPBonus;
                                    SharedData.TakePotion -= 1;
                                    Console.WriteLine($"Tu as repris tout t'a vie tu es rendu a {SharedData.HealtHero} ");

                                }
                                else
                                {
                                    Console.WriteLine("Tu n'a pas l'iteam choisi ");

                                }
                                break;

                            case "spéciales":
                            case "speciales":
                                Console.Clear();
                                Console.Write($"Tu as {SharedData.Mana} de manas donc réflichi bien\n");
                                Console.WriteLine($"{SharedData.PlayerName} dans les chois proposer choisi le numéro de l'attaque spécial que tu veux faire\n");

                                for (int i = 0; i < attaqueepee.GetLength(0); i++)////affiher 
                                {

                                    Console.WriteLine($"Nom: [{attaqueepee[i, 0]}], Dégâts: {attaqueepee[i, 1]}, Mana requis: {attaqueepee[i, 2]}, Description: {attaqueepee[i, 3]}");

                                }


                                string input = Console.ReadLine();
                                int choix = Convert.ToInt32(input) - 1;

                                if (choix >= 0 && choix < attaqueepee.GetLength(0))
                                {
                                    Console.WriteLine($"You chose to use {attaqueepee[choix, 0]}!");


                                    switch (choix)
                                    {
                                        case 0:///Attaque Tonnerre
                                            Console.Clear();
                                            Console.WriteLine($"Vous avez choisi d'utiliser {attaqueepee[choix, 0]}!");

                                            Console.WriteLine("Avec l'attque Coup de Tonnerre  ");

                                            HPBoss = SharedData.HPBoss - 80;
                                            SharedData.HPBoss = HPBoss;
                                            SharedData.HPBoss = Math.Max(HPBoss, 0);
                                            Console.WriteLine($"Tu lui as enlever 80 HP donc, il lui reste {HPBoss} ");

                                            HPHero = SharedData.HealtHero - 10;
                                            SharedData.HealtHero = HPHero;
                                            Console.WriteLine($"Comme tu l'a étourdit il ta juste enlever 10HP il te reste {SharedData.HealtHero}\n");
                                            SharedData.Mana -= 30;
                                            SharedData.HealtHero = Math.Max(HPHero, 0);
                                            break;

                                        case 1:///Attaque feu
                                            Console.Clear();
                                            Console.WriteLine("Avec l'attque Lame de Feu  ");

                                            HPBoss = SharedData.HPBoss - 100;
                                            SharedData.HPBoss = HPBoss;
                                            SharedData.HPBoss = Math.Max(HPBoss, 0);
                                            Console.WriteLine($"Tu lui a enlever 100 HP donc, il lui reste {HPBoss} ");
                                            Console.WriteLine("Comme tu l'a enflammée ton attaque normal prochaine infligera x2 de dégas");
                                            Console.Write("Comme tu l'a brulé il n'a pas pu attaquer\n");
                                            bruler = false;
                                            SharedData.Mana -= 40;
                                            break;

                                        case 2://Attaque Votex Glacial
                                            Console.Clear();
                                            Console.WriteLine($"Vous avez choisi d'utiliser {attaqueepee[choix, 0]}!");



                                            Console.WriteLine("Avec l'attque Vortex Glacial  ");

                                            HPBoss = SharedData.HPBoss - 60;
                                            SharedData.HPBoss = HPBoss;
                                            SharedData.HPBoss = Math.Max(HPBoss, 0);
                                            Console.WriteLine($"Tu lui a enlever 60 HP donc, il lui reste {HPBoss} ");
                                            HPHero = SharedData.HealtHero - SharedData.AttaqueBoss;
                                            SharedData.HealtHero = HPHero;
                                            Console.WriteLine($"Comme il l'attaque a rien de spécial le boss ta attaquer donc, il te reste {SharedData.HealtHero} HP\n");


                                            SharedData.Mana -= 25;
                                            break;


                                        default:
                                            Console.WriteLine("Action non reconnue.");
                                            continue;
                                    }
                                }
                                break;
                        }
                    }
                }

            }
            if (SharedData.HPBoss == 0)
            {
                Console.Clear();
                Console.Write("Après cette victoire, tu t'approches de la princesse, \n" +
                    "Et vous etes resortir de la grotte ensemble\n");
                Game.Finish();




            }
            if (SharedData.HealtHero == 0)
            {
                Console.WriteLine("\nVous êtes mort après cette défaite vous décidez de retourne au village pour prendre des force");
                SharedData.HealtHero = 300;
                SharedData.HPBoss = 300;
                Game.Transition<Village>();
            }
        }
    }
}