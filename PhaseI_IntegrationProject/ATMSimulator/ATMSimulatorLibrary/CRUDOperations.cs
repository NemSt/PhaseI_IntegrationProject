using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ATMSimulatorLibrary
{
    class CRUDOperations
    {
    {
        private static ATMBoss galerie = ATMBoss.Instance;


        //public static bool CheckFile(string path)                       // pour vérifier si le path mène à un fichier existant, jugée
        //{                                                               // non nécessaire
        //    bool check = false;                                           
        //    if (File.Exists(path))
        //    {
        //        check = true;
        //    }
        //    return check;
        //}   


        public static void CreateFile(string path)                      // pour créer un répertoire et un fichier s'ils n'existent pas
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }


        // vérification : si le dossier existe, et qu'il n'est pas vide, confirmer que l'usager souhaite bien écraser
        // les données du fichier... offrir la possibilité d'annuler.
        public static bool CheckContent(string path)
        {
            bool empty = true;
            if (File.Exists(path))
            {
                List<string> fileContent = File.ReadAllLines(path).ToList();
                if (fileContent.Count > 0)
                {
                    empty = false;
                }
            }
            return empty;
        }


        // Méthode pour ajouter les données provenant d'une liste représentant la totalité d'une collection à un fichier .txt

        //***REMARQUE***    La section placée en commentaires correspond à ma première version (qui recevait un string de "CreateString" 
        //                  de la classe Boss) que j'ai changée pour recevoir une liste... aussi, pour l'écriture en tant que telle, 
        //                  j'ai découvert File.WriteAllLines qui m'a semblée plus optimale que le StreamWriter... 

        public static string WriteCollection(bool erase, string path, List<string> objectsFromCollection)     // (de CreateList(path) de la classe Boss)
        {
            string message = "Aucune valeur à ajouter au fichier : veuillez vous assurer que la collection n’est pas vide.";

            //string[] text = new string[10];
            //if (!string.IsNullOrEmpty(s))
            //{
            //StreamWriter sw = new StreamWriter(path);
            //message = "Votre collection a été ajoutée au fichier.";
            //text = s.Split(';');
            //for (int i = 0; i < text.Length; i++)
            //{
            //    if (i < (text.Length - 1))
            //    {
            //        sw.WriteLine(text[i]);
            //    }
            //    else
            //    {
            //        sw.Write(text[i]);
            //    }
            //}
            //sw.Close();
            
            if (erase)
            {
                if (objectsFromCollection.Count > 0)
                {
                    if (!File.Exists(path))
                    {
                        CreateFile(path);
                    }
                    File.WriteAllLines(path, objectsFromCollection);
                    message = "Votre collection a été ajoutée au fichier.";
                }
            }
            else
            {
                message = "Ouf! Il s'en est fallu de peu! N'ayez crainte, tout est resté exactement comme avant! \r\n" +
                    "\r\nSi vous ne souhaitez pas écraser les données de votre fichier, vous devez d'abord sélectionner l'option « Ouvrir ».";
            }
            return message;
        }

        // Méthode pour lire le contenu d'un fichier .txt dont le texte représente une collection d'objets

        //***REMARQUE***    La section placée en commentaires correspond ici aussi à ma première version... J'avais pensé faire afficher un 
        //                  message pour indiquer l'ordre de récupération des données des fichiers, mais en limitant tout simplement l'accès en 
        //                  désactivant le choix du formulaire ça me semblait plus efficace... aussi, pour la lecture en tant que telle, 
        //                  j'ai découvert File.ReadAllLines qui m'a semblée plus optimale que le StreamReader...


        


        public static string ReadCollection(string path)
        {
            //string collectionData = null;
            //string[] objects = new string[10];

            string message = "Ce fichier n'existe pas.";
            
            if (File.Exists(path))
            {
                //if ((path.Contains("Artists")) && (galerie.ListeConservateurs.Count <= 0))
                //{
                //    message = "Vous ne pouvez pas ajouter d'artistes avant d'avoir ajouter les conservateurs.";
                //}
                //else if (path.Contains("Pieces") && ((galerie.ListeConservateurs.Count <= 0) || (galerie.ListeArtistes.Count <= 0)))
                //{
                //    message = "Vous ne pouvez pas ajouter d'oeuvres avant d'avoir ajouter les conservateurs et les artistes.";
                //}
                //else
                //{
                //StreamReader sr = new StreamReader(path);
                //collectionData = sr.ReadToEnd();
                //collectionData = collectionData.Replace("\r\n", ";");
                //collectionData = collectionData.TrimEnd(';');


                //if (!string.IsNullOrEmpty(collectionData))
                //    {
                //        objects = collectionData.Split(';');
                //        message = galerie.AddObjects(path, objects);
                //    }
                //    else
                //    {
                //        message = "Le fichier ne contient pas de données.";
                //    }
                //    sr.Close();
                //}

                List<string> objectsFromFile = File.ReadAllLines(path).ToList();
                if (objectsFromFile.Count > 0)
                {
                    message = galerie.AddObjects(path, objectsFromFile);
                }
            }
            return message;
        }
    }
}
