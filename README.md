# ProjetNarratif
Isaie Bourget 
En tant que courageux h�ros, vous �tes charg� de la noble mission de sauver la princesse qui a �t� enlev�e par un m�chant. Votre chemin est sem� d'emb�ches, car des cr�atures monstrueuses sera la port vous emb�ter 
Le th�me de mon jeux est l'exploration et l'aventure dans un monde en d�tresse. 





Code du cours 420J17AS

Choix et Strat�gie : Les options d'achat (bombes, potions, am�liorations d'armes) offrent au joueur des choix strat�giques. 
Par exemple, l'achat des bombes (if (ChoixItem == "bombes")) permet au joueur de d�cider s'il souhaite d�penser son or pour cet objet, influen�ant son approche du gameplay.
Gestion des Ressources : La gestion de l'or du joueur (SharedData.Gold) et des d�cisions d'achat impacte directement la fa�on dont le joueur g�re ses ressources, 
ajoutant un �l�ment de r�flexion et de planification au jeu.

Qu�te secondaire : Exemple dans mon jeu il y a une qu�te avec Jovy o� le joueur doit collecter des poissons, 
cela cr�e une interaction engageante et encourage l'exploration puis offre une t�che sp�cifique au joueur. 
Pour cela j'ai cree un nouveau .cs appler Quest pour ajouter tout les qu�tes et pour d�bloque les qu�tes j'ai utiliser 
SharedData.QuetesDecouvert.Add(new Quest("Qu�te de Jovy", "Vous devez essayer de trouver 10 poisson pour le festin")); pour que je le joueur puisse voir sa qu�te tout le long du jeu.


