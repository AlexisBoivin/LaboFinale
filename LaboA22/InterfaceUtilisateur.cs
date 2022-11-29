// Classe Interface utilisateur
//
// Affichage et interactions avec l'utilisateur
//
// Selon l'état du jeu, affiche
// 1. Message (et/ou graphique) d'accueil, menu de démarrage (Jouer - Quitter)
// 2. Affichage de haut en bas : Entête du jeu (Le nom entouré de # par exempele, carte avec position du personnage et de la sortie, instructions pour se déplacer
// 3. Affichage de haut en bas : Le même entête, dessin de la zone de combat, stats du joueur et de ennemis en bas
// 4. Menu de fin (Rejouer - Quitter)
//
// La carte a un contour en #, il peut y avoir des obstacles au travers (encore des #)
// Le joueur est représenté par un J et la sortie par un S
// La sortie est déjà placée dans la carte
// Le joueur commence toujours à la première case libre en haut à gauche de la carte
//
// Création : 2022/11/19
// Par : Frédérik Taleb
// Modification : 2022/11/24
// Par : Frédérik Taleb

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LaboFinal_A22
{
    public class InterfaceUtilisateur
    {
        public string entete;
        public string intro;
        public string menuIntro;
        public string menuCreation;
        public string menuFin;
        public string instructions;
        public List<string> carte;
        public int largeur;
        public int hauteur;
        public string[] arene;
        
        // Constructeur
        // Initialise les attributs
        public InterfaceUtilisateur()
        {
            // initialiser les attributs
            this.entete = "\r\n  (`-')                (`-') <-.(`-')              \r\n  ( OO).->    .->   <-.(OO )  __( OO)              \r\n,(_/----.(`-')----. ,------,)'-'. ,--.     .----.  \r\n|__,    |( OO).-.  '|   /`. '|  .'   /    \\_,-.  | \r\n (_/   / ( _) | |  ||  |_.' ||      /)       .' .' \r\n .'  .'_  \\|  |)|  ||  .   .'|  .   '      .'  /_  \r\n|       |  '  '-'  '|  |\\  \\ |  |\\   \\    |      | \r\n`-------'   `-----' `--' '--'`--' '--'    `------' \r\n";
            this.intro = "Zork a été ressucité! Tous les aventuriers sont sollicités pour débarasser Azerim de cette menace!";
            this.menuIntro = "1. Jouer\n2.Quitter";
            this.menuCreation = "1. Guerrier\n2. Roublard\n3. Magicien";
            this.menuFin = "1. Rejouer\n2.Quitter";
            this.instructions = "W : Haut, A : Gauche, S : Bas, D : Droite";
            this.arene = new string[] {
                "###################",
                "                   ",
                "     {0}           ",
                "                   ",
                " J   {0}           ",
                "                   ",
                "     {0}           ",
                "                   ",
                "###################"
            };

            // utiliser la méthode chargerCarte pour initialiser la carte et ses dimensions
            chargerCarte();
        }

        // chargerCarte
        //
        // lit la carte dans le fichier du même nom et la place dans l'attribut carte
        // quand on lit la première ligne on initialise l'attribut largeur
        // quand on a fini de lire tout le fichier on initialise l'attribut hauteur
        public void chargerCarte()
        {
            // initialiser la liste des cases de la carte
           List<string> carte = new List<string>();
            // initialiser un lecteur de fichier texte pour lire le fichier carte.txt
            StreamReader lecteur = new StreamReader("carte.txt");
            // lire la première ligne de la carte. NE PAS METTRE CETTE LIGNE DANS LA LISTE
            // initialiser la largeur de la carte en prenant la longueur de la première ligne
            // les string sont des tableau, on a accès à la propriété .Lenght
            this.largeur = lecteur.ReadLine().Length;
           

            // au moyen d'une boucle while remplir la liste de la carte avec chacun des symboles du fichier texte
            while (!lecteur.EndOfStream)
            {
                // lire une ligne et la placer dans une variable temporairement
                string ligne = lecteur.ReadLine();
                // pour chaque lettre de la ligne
                for (int i =0; i < this.largeur; i++)
                {
                    // ajouter le caractère à la liste
                    carte.Add(ligne[i].ToString());
                   
                }


            }
            // fermer le lecteur pour libérer le fichier 
            lecteur.Close();
            // Une fois le tableau de la carte rempli, initialiser la hauteur de la carte
            // la hauteur est le nombre d'éléments de la liste / la largeur de la carte
            this.hauteur = carte.Count() / this.largeur;

            // placer le joueur à la position de départ, la première case libre en haut à gauche
            

        }


        // afficherMenuCreation
        //
        // affiche le menu de création du joueur 
        // retourne le choix de la classe : 0  pour guerrier, 1 pour magicien ou 2 pour roublard
        //
        // @return int le nombre correspondant à la classe choisie
        public int afficherMenuCreation()
        {
            int choix = 0;
            Console.WriteLine(this.menuCreation);
            int.TryParse(Console.ReadLine(), out choix);
            return choix;
            
        }


        // demanderNom
        //
        // demande le nom du personnage à la console et retourne la réponse
        // 
        // @return string le nom choisi pour le personnage
        public string demanderNom()
        {
            Console.WriteLine("Quel est le nom du héros ?");
            string nom = "";
            nom = Console.ReadLine();
            return nom;
        }


        // afficherCarte
        //
        // Affiche la carte à la console 
        public void afficherCarte()
        {
            // pour chaque unité de hauteur de la carte
            for (int i = 0; i < this.hauteur; i++)
            {
                // pour chaque unité de largeur de la carte
                for (int j = 0; j < this.largeur; j++)
                {
                    // afficher sur la même ligne de console
                    // le symbole de la liste à la position : j + (i * largeur)
                    Console.Write(carte[j + (i* this.largeur)]);
                }

                // sauter une ligne
                Console.Write("\n");
            }


        }

        // afficherMenuExploration
        //
        // affiche le menu d'exploration et retourne le choix de l'utilisateur
        //
        // @ return un nombre entier pour le choix de l'utilisateur
        //          - 0 : haut
        //          - 1 : bas
        //          - 2 : gauche
        //          - 3 : droite
        public int afficherMenuExploration()
        {

            // afficher les instructions
            Console.WriteLine(this.instructions);
            // récupérer la réponse de l'utilisateur
            string choix = Console.ReadLine();
            // selon la réponse W (haut),S(bas),A(gauche) ou D(droite)
            // assigner 0,1,2 ou 3 à une variable pour le résultat
            int direction = 0;
            if (choix == "w" ||choix == "W")
            {
                direction = 0;
            }
            else if (choix == "s" || choix == "S")
            {
                direction = 1;
            }
            else if (choix == "a" || choix == "A")
            {
                direction=2;
            }
            else if (choix == "d" || choix == "D")
            {
                direction = 3;
            }
            // retourner la variable contentant le résultat du choix
            return direction;

        }

        // afficherArene
        // 
        // affiche la zone où le joueur affronte les ennemis
        //  - le joueur (J) est toujours à gauche et au centre sur l'axe vertical
        //  - le joueur est déjà placé dans le tableau pour afficher l'arène
        //  - les ennemis sont à droite à trois positions : haut, centre, bas
        //  - les {0} sont remplacés par un vide quand il n'y a pas d'ennemi à la position
        //  - sinon on écrit le nom de l'ennemi en commençant à la case où il y a le {0}
        //
        // @param string[] ennemis un tableau de string avec le nom des ennemis ou une case vide
        //                  la case 0 est pour l'ennemi du haut
        //                  la case 1 est pour l'ennemi du milieu
        //                  la case 2 est pour l'ennemi du bas
        public void afficherArene(string[] ennemis)
        {
            // variable pour savoir quel ennemi on affiche, le premier est 0
            int ennemiAfficher = 0;
            // pour chaque case du tableau this.arene (chaque ligne d'affichage)
            for (int i =0; i < this.arene.Length; i++)
            {
                // initialiser une variable string ligne
                // et lui assigner la valeur de la ligne actuelle : i
                string ligne = this.arene[i];

                // si on est à la 3ème ligne
                if (i == 3)
                {
                    // remplacer le marqueur {0} par le nom du premier ennemi
                    this.arene[i] += ennemis[ennemiAfficher];
                    ennemiAfficher++;
                    
                }


                // sinon si on est à la 5 ème ligne 
                else if (i == 5)
                {
                    // remplacer le marqueur {0} par le nom du deuxième ennemi
                    this.arene[i] = this.arene[i] + ennemis[ennemiAfficher];
                }

                
                // sinon si on est à la 7 ème ligne
                else if (i == 7)
                {
                    // remplacer le marqueur {0} par le nom du troisième ennemi
                    this.arene[i] += ennemis[ennemiAfficher];
                }


                // sinon
                else
                {
                    // pour chaque case du string dans this.arene à la position actuelle (i)
                    for (int j = 0; j < this.arene[i].Length; j++)
                    {
                        // afficher le symbole actuel : this.arene[i][j] , sans sauter de ligne
                        Console.Write(this.arene[i][j]);
                    }

                }
                // sauter une ligne
                Console.WriteLine();
            }

        }

        // afficherStats
        // 
        // affiche les stats reçues en paramètre ligne par ligne
        //
        // @param string[] stats un tableau de string contenant les stats
        public void afficherStats(string[] stats)
        {
            for (int i = 0; i < stats.Length; i++)
            {
                Console.WriteLine(stats[i]);
            }
        }


        // afficherEntete
        //
        // affiche l'entête du jeu
        public void afficherEntete()
        {
            Console.WriteLine(this.entete);
        }

        // afficherMenuCombat
        //
        // affiche une menu pour les action possibles au combat
        // renvoie le choix de l'utilisateur.
        // Le choix correspond à la position de l'action dans le tableau reçu en paramètre
        //
        // @param string[] actions un tableau de string avec le nom des actions
        // @return un nombre entier correspondant à la position de l'action choisi dans le tableau en entrée
        public int afficherMenuCombat(string[] actions)
        {
            // initialiser une variable pour le choix de l'action avec l'action 0
            int choixAction = 0;
            // pour tous les éléments du tableau des actions
            for (int i = 0; i < actions.Length; i++)
            {
                // afficher i + 1 suivi du nom de l'action
                Console.WriteLine(i+1 + ". " + actions[i]);
            }

            // lire la réponse de l'utilisateur
            int.TryParse(Console.ReadLine(), out choixAction);
            // retourne la position de l'action dans le tableau reçu en paramètre
            return choixAction - 1;

        }

        // afficherMenuCible
        // 
        // affiche un menu pour choisir la cible d'une action
        // renvoie le choix de l'utilisateur
        // la méthode est déjà complétée
        // 
        // @param string[] ennemis un tableau de noms d'ennemis
        // @return un nombre entier correspondant à la position de l'ennemi dans le tableau reçu en paramètre 
        public int afficherMenuCible(string[] ennemis)
        {
            int choix = 0;
            for (int i = 0; i < ennemis.Length; i++)
            { 
                Console.WriteLine((i+1) + ". " + ennemis[i]);
            }
            int.TryParse(Console.ReadLine(), out choix);

            return choix - 1;
        }

        // afficherMenuIntro
        //
        // affiche l'intro et le menu du début, ensuite retourne le choix de l'utilisateur : 1 pour jouer, 2 pour quitter
        public int afficherMenuIntro()
        {
            int choix = 0;
            Console.WriteLine(this.intro);
            Console.WriteLine(this.menuIntro);
            int.TryParse(Console.ReadLine(), out choix);
            return choix;
        }

        // afficherMenuFin
        //
        // affiche le menu de fin et retourne le choix de l'utilisateur : 1 pour rejouer, 2 pour quitter
        public int afficherMenuFin()
        {
            int choix = 0;
            Console.WriteLine(this.menuFin);
            int.TryParse(Console.ReadLine(), out choix);
            return choix;
        }


        // demanderPositionJoueur
        // 
        // renvoie le # de la case dans this.carte où il y a un J
        // les x commencent à 0 et sont positifs vers la droite
        // les y commencent à 0 et sont positifs vers le bas
        //
        // @return int le numéro de la case où le joueur est
        public int demanderPosition()
        {
            // initialiser une variable pour la position du joueur dans la liste this.carte
            int position = 0;
            // tant que le compteur position est plus petit que la longueur de la liste
            // et que le contenu de la carte à la position du compteur est différente de J
            while (position < carte.Count() && carte[position] != "J")
            {
                // augmenter le compteur position
                position++;
            }

            // renvoyer la position dujoueur
            return position;

        }

        // deplacerJoueur
        //
        // essaie de déplacer le joueur selon la direction envoyée en paramètre
        // 0 : haut
        // 1 : bas
        // 2 : gauche
        // 3 : droite
        // 
        // @return bool vrai si on a atteint la sortie
        public bool deplacerJoueur(int direction)
        {
            // initialiser une variable pour dire si le joueur est arrivé à la sortie
            bool sortieAtteinte = false;
            // initialiser une variable (compteur) pour le numéro de la case où le joueur est placé
            int numeroCase = 0;
            // initialiser une variable pour le numéro de la case de destination
            int numeroDestination = 0;
            // trouver la case dans laquelle le joueur est avec la méthode demanderPosition()
            numeroCase = demanderPosition();
            // selon la direction
            // si le joueur va vers le haut
            if (direction == 0)
            {
                // la case de destination est la case du joueur - la largeur de la carte
                numeroDestination = numeroCase - this.largeur;
            }
            // vers le bas
            else if (direction == 1)
            {
                // la case de destination est la case du joueur + la largeur de la carte
                numeroDestination = numeroCase + this.largeur;
            }
            // vers la gauche
            else if (direction ==2 )
            {
                // la case de destination est la case du joueur - 1
                numeroDestination = numeroCase - 1;
            }
            // vers la droite
            else if (direction == 3)
            {
                // la case de destination est la case du joueur + 1
                numeroDestination = numeroCase + 1;
            }

            // si la position de destination est dans la carte
            // >= 0 et < le nombre d'éléments de la carte
            if (numeroDestination >=0 && numeroDestination < carte.Count())
            // si le contenu de la carte à la position de destination est la sortie (un S)

            // changer la valeur de la variable de retour à true

            // si le contenu de la carte à la position de destination est différente de # (un mur)

            // remplacer le joueur (la lettre J) de sa position dans la carte par un vide: " "

            // placer le joueur (le symbole J) dans la carte, à la destination

            // retourner la variable de retour, qui détermine si on a atteint la sortie ou non

        }
    }
}
