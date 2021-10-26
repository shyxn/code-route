using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace code_route
{
    public class Controller
    {
        private Model _model;
        private Form1 _view;
        // temp
        private int _imgCount = 0;

        public Controller(Model model, Form1 view)
        {
            this._model = model;
            this._view = view;
            InitMVC();
            TestRecords();
        }
        private void InitMVC()
        {
            this._view.Controller = this;
            this._model.Controller = this;
        }
        public void ChangeImage()
        {
            //Random rnd = new Random();
            //int rndNumber = rnd.Next();
            string[] currentRow = this._model.GetCurrentRow(this._imgCount);
            string stringImgPath = currentRow[0];
            string filePath = Environment.CurrentDirectory + "\\assets\\allroadsigns\\" + stringImgPath;
            string answer = currentRow[1];
            this._imgCount++;


            this._view.DrawImage(filePath);
            this._view.ChangeLabel(answer);

        }
        
        private void TestRecords()
        {
            string[] allFiles = this._model.GetFileNames();
            List<string> allStrings = this._model.GetDBFileNames();

            // Algorithme de détection d'erreurs dans les fichiers et les enregistrements
            List<string> correctRecords = new List<string>();
            List<string> incorrectDBRecords = new List<string>();
            List<string> noPNGdbRecords = new List<string>();
            List<string> incorrectFileRecords = new List<string>();
            for (int i = 0; i < allStrings.Count; i++)
            {
                bool hasFound = false;
                foreach (string fileNameDir in allFiles)
                {
                    // l'enregistrement est correct et correspond à un fichier
                    if (fileNameDir != null && fileNameDir.EndsWith("\\" + allStrings[i]))
                    {
                        correctRecords.Add(allStrings[i]);
                        // Supprime dans la liste
                        allStrings.Remove(allStrings[i]);
                        i--;
                        // Supprime dans l'array
                        int indexOfFileNameDir = Array.IndexOf(allFiles, fileNameDir);

                        allFiles[indexOfFileNameDir] = null;
                        hasFound = true;
                        break;
                    }
                }
                // Si l'enregistrement n'a pas été trouvé dans les fichiers
                if (!hasFound)
                {

                    incorrectDBRecords.Add(allStrings[i]);
                    if (!(allStrings[i].EndsWith(".png")))
                    {
                        noPNGdbRecords.Add(allStrings[i]);
                    }
                }

            }
            // Récolter tous les noms des fichiers restants et non comptabilisés
            foreach (string fileStringLeft in allFiles)
            {
                if (fileStringLeft != null)
                {
                    incorrectFileRecords.Add(fileStringLeft);
                }
            }

            // Affichage en sortie
            Debug.WriteLine("Affichage de tous les éléments de la DB qui n'ont pas trouvé de fichier : ");
            foreach (string incorrectDB in incorrectDBRecords)
            {
                Debug.WriteLine(incorrectDB);
            }
            Debug.WriteLine("Affichage de tous les éléments de la DB qui n'ont pas de .png : ");
            foreach (string noPNGstring in noPNGdbRecords)
            {
                Debug.WriteLine(noPNGstring);
            }
            Debug.WriteLine("Affichage de tous les éléments incorrects dans les fichiers : ");
            foreach (string incorrectFile in incorrectFileRecords)
            {
                Debug.WriteLine(incorrectFile);
            }
            Debug.WriteLine("Nombre d'enregistrements corrects : " + correctRecords.Count);
            Debug.WriteLine("Nombre d'enregistrements incorrects (DB) : " + incorrectDBRecords.Count);
            Debug.WriteLine("Nombre d'enregistrements incorrects (DB no .png) : " + noPNGdbRecords.Count);
            Debug.WriteLine("Nombre d'enregistrements incorrects (Files) : " + incorrectFileRecords.Count);

        }
    }
}
