using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif.Rooms
{
    internal class Forest : Room
    {
        int essaismal = 3;
        int essaiebon = 0;
        string reponce;
        int correctionreponce = 0;
        int numeroDevinette = 1;

        string[] indices1 = { "Je peux refroidir ta boisson", "Je suis solide mais je peux fondre", "Je suis formé quand l'eau gèle" };
        string enigme1 = "Je suis d'eau, mais je meurs dans l'eau. Qui suis-je ?";
        string reponseCorrecte1 = "glace";

        string enigme2 = "Plus on en prend, plus on en laisse derrière. Qu'est-ce que c'est ?";
        string reponseCorrecte2 = "empreintes";
        string[] indices2 = { "On me trouve souvent dans le sable ou la neige.", "Je suis un signe de passage.", "Je suis unique à chaque personne." };

        string enigme3 = "Je parle toutes les langues, mais je n'ai jamais appris. Qui suis-je ?";
        string reponseCorrecte3 = "echo";
        string[] indices3 = { "Je répète ce que tu dis.", "Je suis plus fort dans les montagnes et les vallées.", "Je suis un phénomène acoustique." };

        internal override string CreateDescription()
        {
            string description = "Arivée dans la forêt tu vois un maison abendonner tu décider d'aller [cognier]";
            return description;
        }

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "cognier":
                    Console.WriteLine($"Arrivé devant la porte, {SharedData.PlayerName} décida de frapper à la porte.\n" +
                    $"Un vieil homme ouvra la porte et le regarda avec curiosité. 'Qui ose perturber ma solitude?'\ndemanda-t-il d'une voix grave.");
                    Console.WriteLine($"Je suis {SharedData.PlayerName}, un aventurier. Je cherche à explorer ces terres.");
                    Console.WriteLine($"Le vieil homme sourit malicieusement. 'Très bien, {SharedData.PlayerName}. Si tu veux passer, réponds à mon énigme. \nTu auras trois essais.'");
                    Console.WriteLine("Il pose alors sa devinette. Après chaque essai incorrect, le vieil homme donne un indice.");
                    
                    while (essaismal > 0 && numeroDevinette <= 3)
                    {
                        string enigmeActuelle = "";
                        string reponseCorrecte = "";
                        string[] indices = null;

                        if (numeroDevinette == 1)
                        {
                            Console.WriteLine("\nPremière devinette\n");
                            enigmeActuelle = enigme1;
                            reponseCorrecte = reponseCorrecte1;
                            indices = indices1;
                        }
                        else if (numeroDevinette == 2)
                        {
                            Console.WriteLine("\nDeuxième devinette\n");
                            enigmeActuelle = enigme2;
                            reponseCorrecte = reponseCorrecte2;
                            indices = indices2;
                        }
                        else if (numeroDevinette == 3)
                        {
                            Console.WriteLine("\nTroisieme devinette\n");
                            enigmeActuelle = enigme3;
                            reponseCorrecte = reponseCorrecte3;
                            indices = indices3;
                        }

                        Console.WriteLine(enigmeActuelle);
                        reponce = Console.ReadLine().ToLower();

                        if (reponce == reponseCorrecte)
                        {
                            Console.WriteLine("Correct! Vous avez trouvé la réponse!");
                            numeroDevinette++;
                            essaismal = 3;
                        }
                        else
                        {
                            essaismal--;
                            Console.WriteLine("Incorrect. Il vous reste " + essaismal + " essais.");
                            if (essaismal > 0)
                                Console.WriteLine("Indice: " + indices[3 - essaismal]);
                            else
                            {
                                Console.WriteLine("Vous n'avez pas trouvé la réponse. Le jeu est terminé.");
                                break;
                            }
                        }
                    }
                    break;
            }
        }
    }
}



