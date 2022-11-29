// Classe Joueur
//
// Le joueur principal
//
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
    public class Joueur
    {
        // attributs (public)
        public string nom; // un nom 
        public int att; // att
        public int matt; // matt
        public int def; // def
        public int mdef; // mdef
        public int hp; // hp des entiers
        public Habilete competence; // habilete un attribut du type Habilete


        // Constructeur
        //
        // reçoit tous les attributs en paramètre sauf l'habilete
        // assigne les paramètres aux attributs correspondants
        public Joueur(string nom, int att, int matt, int def, int mdef, int hp)
        {
            this.nom = nom;
            this.att = att;
            this.matt = matt;
            this.def = def;
            this.mdef = mdef;
            this.hp = hp;
        }

        // enumererActions
        //
        // renvoie un string contenant les actions possibles, séparées par des virgules
        // exemple : "attaquer,boule de feu"
        // "Attaquer" est TOUJOURS la première action possible
        // Ajouter l'habileté seulement si l'attribut tour de l'habileté est à 0
        //
        // @return string une chaîne de caractères contenant les actions possibles séparées par des virgules

        public string enumererActions()
        {
            string actions = "Attaquer";
            if (this.habilete.tour <= 0)
            {
                actions += "," + this.habilete.nom;
            }

            return actions;
        }

        // attaquer
        //
        // renvoie la statistique d'attaque
        public int attaquer()
        {
            int attaque = this.att;
            return attaque;
        }

        // defendre
        //
        // selon l'attaque, magique ou non, diminue les points de dommage du nombre de points de défense
        // diminiue les points de vie selon les dommages finaux, les dommages finaux ne peuvent pas être sous 0
        //
        // @param bool magique vrai pour une attaque magique, faux sinon
        // @param int dmg      le nombre de point de dommage avant la réduction par la défense
        public void defendre(bool magique, int dmg)
        {
            int dmgFinaux = 0;
            // si l'attaque est magique
            if (magique)
            {
                // les dommages finaux sont le dommage - la défense magique
                dmgFinaux = dmg - this.mdef;
            }

            else
            {
                // les dommages finaux sont le dommage - la défense
                dmgFinaux = dmg - this.def;
            }

            // si les dommages finaux sont plus grands que 0
            if (dmgFinaux > 0)
            {
                // diminuer les points de vie du nombre de points de dommage final
                this.hp = this.hp - dmgFinaux;
            }      

        }
        // estVivant
        public bool estVivant()
        {
            bool vivant = true;
            // détermine s'il reste des points de vie
            if (this.hp > 0)
            {
                vivant = false;
            }
            // @return bool vrai s'il reste des points de vie, faux sinon
            return vivant;
        }

        // enumererStats
        public string enumererStats()
        {
            string stats = "";
            // envoie un string contenant le nom et les points de vie
            // "Nom : {0}, Hp : {1}"
            stats = string.Format("Nom : {0}, Hp : {1}", this.nom, this.hp);
            //@return string des statistiques avec le format établi
            return stats;

        }   

    }
}
