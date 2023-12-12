using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Lac : Room
    {
        bool pngIle = true;
        bool threepng = true;
        bool pngeau = true ;
        bool decisioneau=true ;
        bool decisionile = false;
        bool decisionthree = false;

        internal override string CreateDescription()
        {
            string description = $"Après votre discution, vous vous décidez de vos mettre en route vers cette aventure.\n";
            description += $"{SharedData.PlayerName} pouvant maintenant traverser le [mer] avec les nageoirs que Élénore lui avait donné\n";
            description += $"Sinon {SharedData.PlayerName} avait toujour le choit de faire demi-[tour]";
            return description;
        }

        internal override void ReceiveChoice(string choice)
        {
            
            switch (choice)
            {
                case "tour":
                    Game.Transition<RoadCaveAndLac>();
                    break;

                case "mer":
                    Console.WriteLine($"En traversant la mer {SharedData.PlayerName} remarqua des choses qui [bougent], ou {SharedData.PlayerName} continua sa [nage].");
                    string line = Console.ReadLine();
                    switch (line)
                    {
                        case "bougent":
                            Console.WriteLine($"En avançant de plus en plus {SharedData.PlayerName} remaqua un troupeau d'homme poisson\n" +
                                $"{SharedData.PlayerName} décida d'aller les voir");

                            Console.WriteLine($"{SharedData.PlayerName} avança vers eu ils avait plusieur homme poisson un proche d'une [île]\n" +
                                $"trois qui [regarda] {SharedData.PlayerName} et un autre dans l'[eau].");
                            string line2 = Console.ReadLine();

                            switch (line2)
                            {
                                case "ile":
                                case "île":
                                    string discussion;
                                    if (pngIle)
                                    {

                                        Console.Clear();
                                        Console.WriteLine($"{SharedData.PlayerName} avança vers l'homme poisson");
                                        discussion = "Bonjour, mon nom est Jovy. Je suis ravi de vous rencontrer.\n";
                                        foreach (char c in discussion)
                                        {
                                            Console.Write($"{c}");
                                            Thread.Sleep(40);
                                        }
                                        Console.WriteLine($"\n{SharedData.PlayerName} \"Bonjour mon est {SharedData.PlayerName}\"");
                                        Thread.Sleep(1000);
                                        discussion = $"\nJovy \"J'ai une tâche pour vous, {SharedData.PlayerName}. \nNous avons besoin de 10 poissons pour le festin de ce soir.\n";
                                        discussion += "Comme on dit les poissons frais sont essentiels pour impressionner nos invités.\n";
                                        discussion += "Acceptez-vous cette quête de pêche ?\"\n";
                                        foreach (char c in discussion)
                                        {
                                            Console.Write($"{c}");
                                            Thread.Sleep(40);
                                        }

                                        Console.WriteLine("1. [Oui], je vais chercher les poissons.");
                                        Console.WriteLine("2. [Non], je ne peux pas le faire pour le moment.\n");
                                        string line3 = Console.ReadLine();


                                        if (line3 == "oui")
                                        {
                                            Console.WriteLine("La quête a été ajoutée à votre journal");
                                            SharedData.QuetesDecouvert.Add(new Quest("Quête de Jovy", "Vous devez essayer de trouver 10 poisson pour le festin"));
                                            Console.WriteLine("Jovy \"Merci beaucoup !\"");
                                            pngIle = false;
                                            break;
                                        }
                                        if (line3 == "non")
                                        {
                                            discussion = "Jovy \"Bon pas grave peut-être la prochain fois.\"";

                                            foreach (char c in discussion)
                                            {
                                                Console.Write($"{c}");
                                                Thread.Sleep(40);
                                            }
                                            pngIle = false;
                                            decisionile = true;
                                            break;

                                        }
                                    }
                                    if (!pngIle)
                                    {
                                        if (SharedData.poisson == 10)
                                        {

                                            discussion = "Jovy \" À tu m'a trouvé mes 10 poissons pour le festin de se soire.\n" +
                                                "Je suis vraiment reconnaissant pour cela je t'offre une potion max que j'ai trouvé\"";
                                            foreach (char c in discussion)
                                            {
                                                Console.Write($"{c}");
                                                Thread.Sleep(40);
                                            }
                                            SharedData.TakePotionMax++;
                                            break;

                                        }
                                        else if (SharedData.poisson < 10 && decisionile == false)
                                        {
                                            int poisson = 10 - SharedData.poisson;
                                            discussion = $"Jovy \"{SharedData.PlayerName} tu n'a juste {SharedData.poisson} poisson il t'en manque {poisson} encore\"";
                                            foreach (char c in discussion)
                                            {
                                                Console.Write($"{c}");
                                                Thread.Sleep(40);
                                            }
                                            break;
                                        }
                                        else if (decisionile)
                                        {
                                            discussion = $"Jovy \" Tu as changer d'avis comme je peux voir Hahaha\"\n";
                                            foreach (char c in discussion)
                                            {
                                                Console.Write($"{c}");
                                                Thread.Sleep(40);

                                            }
                                            decisionile = false;
                                            Console.WriteLine("La quête a été ajoutée à votre journal");
                                            SharedData.QuetesDecouvert.Add(new Quest("Quête de Jovy", "Vous devez essayer de trouver 10 poisson pour le festin"));
                                            break;
                                        }

                                    }
                                    break;

                                case "regarda":
                                    while (threepng)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"{SharedData.PlayerName} avança vers les trois homme qui le regardais");
                                        Console.WriteLine("Arrivée devant eu le premier ce présanta\n");
                                        discussion = "Bonjour mon est est Murph";
                                        foreach (char c in discussion)
                                        {
                                            Console.Write($"{c}");
                                            Thread.Sleep(40);
                                        }
                                        Console.WriteLine($"\nBonjour Murph moi ces {SharedData.PlayerName}");
                                        Thread.Sleep(1000);
                                        Console.WriteLine("\nLe deuxième se présenta et le troisième");
                                        discussion = $"\nBonjour mon ces Lalena contente de te rencontrer {SharedData.PlayerName}\n" +
                                            $"Puis, moi ces Jay";
                                        foreach (char c in discussion)
                                        {
                                            Console.Write($"{c}");
                                            Thread.Sleep(60);
                                        }
                                        discussion = $"\nMurph \"On aimerait que tu nous aides dans notre quête épique, {SharedData.PlayerName}. \n" +
                                            $"Nous avons besoin de trois objets cruciaux : une lance, un bouclier et une épée.\"\n" +
                                            $"Lalena \"Tu aimerais tu nous aider {SharedData.PlayerName}?\n";
                                        foreach (char c in discussion)
                                        {
                                            Console.Write($"{c}");
                                            Thread.Sleep(40);
                                        }
                                        Console.WriteLine("1. [Oui], je vais vous aider.");
                                        Console.WriteLine("2. [Non], je ne peux pas le faire pour le moment.");
                                        string line4 = Console.ReadLine();
                                        if (line4 == "oui")
                                        {
                                            Console.WriteLine("La quête a été ajoutée à votre journal");
                                            SharedData.QuetesDecouvert.Add(new Quest("Quête de Murph et ses amis", "Vous devez essayer de fabriquer:\n" +
                                                "-Lance\n" +
                                                "-Épée\n" +
                                                "-Bouclier"));
                                            Console.WriteLine("Murph, Lalena et Jovy \"Merci beaucoup !\"");
                                            threepng = false;
                                            break; 
                                        }
                                        else if (line4 == "non")
                                        {
                                            discussion = "Murph \"Bon pas grave peut-être la prochain fois alors.\"";

                                            foreach (char c in discussion)
                                            {
                                                Console.Write($"{c}");
                                                Thread.Sleep(40);
                                            }
                                            threepng = false;
                                            decisionthree = true;

                                        }
                                        break;
                                    }
                                   

                                    if (!threepng)
                                    {
                                        if (Game.lance == false && Game.lance == false && Game.epee == false && decisionthree == false)
                                        {
                                            discussion = $"Lalena \" {SharedData.PlayerName} Tu nous a fabriqué nos arme !!!!\n" +
                                                $"Tu es trop cool {SharedData.PlayerName}\"\n\n" +
                                                $"Jovy  \"Pour cela on t'offre 150 gold pour ta gentille Hahah.\n" +
                                                $"Voici se qui te revient.\"";
                                            SharedData.Gold = +150;
                                            foreach (char c in discussion)
                                            {
                                                Console.Write($"{c}");
                                                Thread.Sleep(40);
                                            }
                                        }
                                        else if (Game.lance | !Game.epee | !Game.bouclier | !Game.lance && decisionthree == false)
                                        {
                                            Console.WriteLine($"Il vous manque des armes: \n" +
                                                $"-{(Game.lance ? "Non Fait" : "Fait")}\n" +
                                                $"-{(Game.epee ? "Non Fait" : "Fait")}\n" +
                                                $"-{(Game.bouclier ? "Non Fait" : "Fait")}");
                                        }


                                        if (decisionthree)
                                        {
                                            Console.Clear();
                                            discussion = $"Jay \"Comme je peux voir {SharedData.PlayerName} tu as changer d'avis.\n" +
                                                $"Tien voici la quête\"\n";
                                            foreach (char c in discussion)
                                            {
                                                Console.Write($"{c}");
                                                Thread.Sleep(40);
                                            }
                                            Console.WriteLine("La quête a été ajoutée à votre journal");
                                            SharedData.QuetesDecouvert.Add(new Quest("Quête de Murph et ses amis", "Vous devez essayer de fabriquer:\n" +
                                                "-Lance\n" +
                                                "-Épée\n" +
                                                "-Bouclier"));
                                            Console.WriteLine("Murph, Lalena et Jovy \"Merci beaucoup !\"");
                                            decisionthree = false;
                                            break;
                                        }
                                    }
                                    break;

                                case "eau":
                                    while (pngeau)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"{SharedData.PlayerName} avança vers l'homme qui avait la tête dans l'eau");
                                        Console.WriteLine("Arrivée devant lui il sorta la tête de l'eau\n");
                                        discussion = "Bonjour mon est est Simon";
                                        foreach (char c in discussion)
                                        {
                                            Console.Write($"{c}");
                                            Thread.Sleep(40);
                                        }
                                        Console.WriteLine($"\nBonjour Simon moi ces {SharedData.PlayerName}");
                                        Thread.Sleep(1000);
                                        discussion = $"\nSimon \"Tu te demandes sûrement pourquoi j'avais la tête dans l'eau, n'est-ce pas ?" +
                                        $"J'essayais de trouver un moyen de sauver mon ami, qui est coincé dans une cage, tout en évitant de me noyer.\"";
                                        foreach (char c in discussion)
                                        {
                                            Console.Write($"{c}");
                                            Thread.Sleep(40);
                                        }
                                        discussion = $"Peut-être que tu pourrais y aller, toi, car tu es plus mince que moi.\n" +
                                        $"Mais avant, il faudrait que tu trouves quelque chose pour éviter de te noyer.\n" +
                                         $"Je sais qu'il y a une boutique proche, peut-être devrions-nous y jeter un coup d'œil ?";
                                        foreach (char c in discussion)
                                        {
                                            Console.Write($"{c}");
                                            Thread.Sleep(40);
                                        }
                                        Console.WriteLine($"{SharedData.PlayerName} \"Parfait je vais aller faire un tour.\"");
                                        pngeau = false;
                                        break;
                                    }

                                    if (!pngeau)
                                    {
                                        if (Game.lance == false && Game.lance == false && Game.epee == false && decisionthree == false)
                                        {
                                            discussion = $"Lalena \" {SharedData.PlayerName} Tu nous a fabriqué nos arme !!!!\n" +
                                                $"Tu es trop cool {SharedData.PlayerName}\"\n\n" +
                                                $"Jovy  \"Pour cela on t'offre 150 gold pour ta gentille Hahah.\n" +
                                                $"Voici se qui te revient.\"";
                                            SharedData.Gold = +150;
                                            foreach (char c in discussion)
                                            {
                                                Console.Write($"{c}");
                                                Thread.Sleep(40);
                                            }
                                        }
                                        else if (Game.lance | !Game.epee | !Game.bouclier | !Game.lance && decisionthree == false)
                                        {
                                            Console.WriteLine($"Il vous manque des armes: \n" +
                                                $"-{(Game.lance ? "Non Fait" : "Fait")}\n" +
                                                $"-{(Game.epee ? "Non Fait" : "Fait")}\n" +
                                                $"-{(Game.bouclier ? "Non Fait" : "Fait")}");
                                        }


                                        if (decisionthree)
                                        {
                                            Console.Clear();
                                            discussion = $"Jay \"Comme je peux voir {SharedData.PlayerName} tu as changer d'avis.\n" +
                                                $"Tien voici la quête\"\n";
                                            foreach (char c in discussion)
                                            {
                                                Console.Write($"{c}");
                                                Thread.Sleep(40);
                                            }
                                            Console.WriteLine("La quête a été ajoutée à votre journal");
                                            SharedData.QuetesDecouvert.Add(new Quest("Quête de Murph et ses amis", "Vous devez essayer de fabriquer:\n" +
                                                "-Lance\n" +
                                                "-Épée\n" +
                                                "-Bouclier"));
                                            Console.WriteLine("Murph, Lalena et Jovy \"Merci beaucoup !\"");
                                            decisionthree = false;
                                            break;
                                        }
                                    }

                                    break;
                                    
                                    
                            }


























                            break;

                        case "carte":
                            new Carte();
                            break;
                    }
                    break;
                                

            }
        }
    }
}
            
        
           
    

                         





                        
                    
            
