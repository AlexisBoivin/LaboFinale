// Classe Modele
//
// Usine qui génère des joueurs et des ennemis à partir des fichiers texte
//
// Les habiletés sont fixées dans le constructeur par simplicité, il serait possible 
// de les générer en ajoutant des fichiers qui contiennent leur définition
//
// Création : 2022/11/19
// Par : Frédérik Taleb
// Modification : 2022/11/24
// Par : Frédérik Taleb

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboFinal_A22
{
    public class Modele
    {
        // attributs
        // une liste ou un tableau d'habiletes, le type est donc la classe Habilete

        // Consturcteur
        // 
        // initialise le contenant pour les habiletés
        // il n'y a que 3 habiletés
        // initialise chacune des habiletés et assigne chacune à une case de l'attribut habiletes
        public Modele()
        {
            //initialiser l'attribut habiletes
            this.habiletes = new List<Habilete>();
            //crée une instance de l'habilete : 
            // Coup Héroïque
            // dmg : 25
            // recup : 4
            // id : 0
            Habilete coup = new Habilete("Coup Héroïque", 25, 4, 0);
            //crée une instance de l'habilete : 
            // Attaque Surprise
            // dmg : 40
            // recup : 6
            // id : 1
            Habilete attaque = new Habilete("Attaque Surprise", 40, 6, 1);
            //crée une instance de l'habilete : 
            // Boule De Feu
            // dmg : 50
            // recup : 2
            // id : 2
            Habilete boule = new Habilete("Boule De Feu", 25, 4, 2);
            // ajoute toues les habiletés à l'attribut habiletes
            this.habiletes.Add(coup);
            this.habiletes.Add(attaque);
            this.habiletes.Add(boule);
        }

        // genererJoueur
        //
        // configure une instance de la classe joueur selon le nom du fichier et le nom passé en paramètre
        // la première ligne du fichier donne l'ordre des attributs nécessaires pour la classe
        //
        // retourne l'instance de la classe joueur initialisée avec l'habileté ajoutée
        // car l'habileté n'est pas dans le constructeur de la classe joueur
        //
        // @param string fichier le nom de la profession choisie, il faudra ajouter .txt à la fin du string
        // @param string nom     le nom choisi par le joueur
        // @return une instance de la classe joueur
        public Joueur genererJoueur(string fichier, string nom)
        {
            // Déclarer une variable de type Joueur, nous allons créer l'instance plus tard

            // Initialiser la classe pour lire le fichier

            // Lire la première ligne dans le vide ( on a besoin seulement des stats)

            // Lire la deuxième ligne et la garder en mémoire

            // Transformer la ligne en tableau de string, en utilisant la virgule comme séparateur

            // utiliser le tableau afin d'obtenir les informations désirées pour utiliser le constructeur de la classe Joueur
            // et finir de créer l'instance du joueur avec ces informations

            // ne pas oublier d'assigner l'habilete au joueur selon le id après la construction

            // retourner le joueur configuré

        }

        // genererEnnemi
        //
        // configure une instance de la classe ennemi selon le nom du fichier passé en paramètre
        // la première ligne du fichier donne l'ordre des attributs nécessaires pour l'ennemi
        //
        // retourne l'instance de la classe ennemi initialisée 
        //
        // @param string fichier le nom de l'ennemi choisi, il faudra ajouter .txt à la fin du string
        // @return une instance de la classe ennemi
        public Ennemi genererEnnemi(string fichier)
        {
            // Déclarer une variable de type Ennemi, nous allons créer l'instance plus tard

            // Initialiser la classe pour lire le fichier

            // Lire la première ligne dans le vide ( on a besoin seulement des stats)

            // Lire la deuxième ligne et la garder en mémoire

            // Transformer la ligne en tableau de string, en utilisant la virgule comme séparateur

            // utiliser le tableau afin d'obtenir les informations désirées pour utiliser le constructeur de la classe Joueur
            // et finir de créer l'instance du joueur avec ces informations

            // retourner le joueur configuré

        }
    }
}
