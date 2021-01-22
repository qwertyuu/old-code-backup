using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raphael_Cote_Interfaces_Lab3_Pt4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Créez un tableau contenant les jours de la semaine.
            string[] jours = new string[]{
                "Lundi",
                "Mardi",
                "Mercredi",
                "Jeudi",
                "Vendredi",
                "Samedi",
                "Dimanche"
            };

            //Affichez chaque jour en utilisant une boucle foreach.
            AfficherCollection(jours);

            //Créez une collection de type ArrayList.
            ArrayList joursAList = new ArrayList(jours);

            //Recopiez le contenu en ordre inverse du tableau précédent dans la collection.
            joursAList.Reverse();

            //Affichez la collection.
            AfficherCollection(joursAList);

            //Effacez de la collection les entrées contenant "Mardi" et "Jeudi" (utilisez LastIndexOf etRemoveAt).
            joursAList.RemoveAt(joursAList.LastIndexOf("Mardi"));
            joursAList.RemoveAt(joursAList.LastIndexOf("Jeudi"));

            //Affichez la collection.
            AfficherCollection(joursAList);

            //Créez une collection fortement typée string (System.Collections.Generic.List<string>).
            //Recopiez le contenu du tableau dans cette collection de string.
            List<string> joursList = jours.ToList();

            //Affichez la collection.
            AfficherCollection(joursList);

            //Créez un dictionnaire avec des clés de type string et des valeurs de type int(System.Collections.Generic.Dictionary<string, int>).
            //Recopiez le contenu du tableau des jours dans ce dictionnaire en donnant pour valeurs le numéro du jour (1 pour Lundi, etc.).
            Dictionary<string, int> joursDict = new Dictionary<string, int>();
            for (int i = 0; i < jours.Length; i++)
            {
                joursDict.Add(jours[i], i + 1);
            }

            //Utilisez la méthode ContainsKey pour vérifier la présence de Mercredi puis affichez sa valeur en utilisant la syntaxe ["Mercredi"] sur le dictionnaire.
            if (joursDict.ContainsKey("Mercredi"))
            {
                Console.WriteLine("Mercredi: " + joursDict["Mercredi"]);
            }

            Console.ReadKey(true);
        }

        public static void AfficherCollection(ICollection c)
        {
            foreach (var item in c)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}