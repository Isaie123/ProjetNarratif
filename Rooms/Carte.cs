using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace ProjetNarratif.Rooms
{
    internal class Carte
    {
        public Carte()
        {
            Console.WriteLine("Bienvenu à la carte\n" +
                "ici vous pouvez voir les quêtes secondaire que vous avez, vous téléporter au place que vous avez découvert et voir votre inventaire\n" +
                "Pour la téléportation vous avez just à indique le nombre à coté du la place\n" +
                "Vous voulez vous allez au chois de [téléportation], ou voir vos [quête], ou voir votre [inventaire]");
            string line = Console.ReadLine();
            switch (line)
            {
                case "teleportation":
                case "téléportation":
                    {
                        Console.WriteLine($"\n-1- {SharedData.Village1}"); ///village du commencement 
                        Console.WriteLine($"-2- {SharedData.Village2}");///village lac
                        int choices = Convert.ToInt32(Console.ReadLine());

                        if (choices == 1)
                        {
                            Console.WriteLine("Vous aller vous téléportater au village du début...");
                            Console.WriteLine("Préparation de la téléportation...");
                            Thread.Sleep(1000); 
                            AnimerRayon();
                            Console.WriteLine("Téléportation réussie!");
                            Game.Transition<Village>();

                        }
                        if (choices == 2 && SharedData.Village2 == "Village lac")
                        {
                            Console.WriteLine("Vous aller vous téléportater au village du Lac");
                            Console.WriteLine("Préparation de la téléportation...");
                            Thread.Sleep(1000);
                            AnimerRayon();
                            Console.WriteLine("Téléportation réussie!");
                            Game.Transition<VillageLac>();

                        }
                        if (choices == 2 && SharedData.Village2 == "???")
                        {
                            Console.WriteLine("Vous n'avez pas découvert ces lieux\n" +
                                "donc parter à l'aventure pour découvir le lieux");

                        }
                    }
                    break;
                case "quete":
                case "quête":
                    Console.WriteLine("Voici la liste de vos quêtes :");
                   
                    foreach (var quete in SharedData.QuetesDecouvert)
                    {
                        Console.WriteLine($"{quete.Nom}: {quete.Description}");
                    }
                    break;
            }

        }
        private void AnimerRayon()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan; // Choisissez une couleur vive

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2, i);
                Console.WriteLine("|");
                Thread.Sleep(50);
                Console.Clear();
            }

            Console.ResetColor(); // Réinitialisez la couleur après l'animation
        }
        

    
    }
    
}
