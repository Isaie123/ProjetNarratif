# ProjetNarratif
Isaie Bourget 
En tant que courageux héros, vous êtes chargé de la noble mission de sauver la princesse qui a été enlevée par un méchant. Votre chemin est semé d'embûches, car des créatures monstrueuses sera la port vous embéter 
Le thème de mon jeux est l'exploration et l'aventure dans un monde en détresse. 





Code du cours 420J17AS

Choix et Stratégie : Les options d'achat (bombes, potions, améliorations d'armes) offrent au joueur des choix stratégiques. 
Par exemple, l'achat des bombes (if (ChoixItem == "bombes")) permet au joueur de décider s'il souhaite dépenser son or pour cet objet, influençant son approche du gameplay.
Gestion des Ressources : La gestion de l'or du joueur (SharedData.Gold) et des décisions d'achat impacte directement la façon dont le joueur gère ses ressources, 
ajoutant un élément de réflexion et de planification au jeu.

Quête secondaire : Exemple dans mon jeu il y a une quête avec Jovy où le joueur doit collecter des poissons, 
cela crée une interaction engageante et encourage l'exploration puis offre une tâche spécifique au joueur. 
Pour cela j'ai cree un nouveau .cs appler Quest pour ajouter tout les quêtes et pour débloque les quêtes j'ai utiliser 
SharedData.QuetesDecouvert.Add(new Quest("Quête de Jovy", "Vous devez essayer de trouver 10 poisson pour le festin")); pour que je le joueur puisse voir sa quête tout le long du jeu.


