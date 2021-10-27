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
        private MainForm _view;
        private List<string[]> _currentPortion = new List<string[]>();
        private List<string[]> _currentPortionAnswered = new List<string[]>();
        private int _masteredAnswers = 0;
        private string[] _currentAnswer = new string[2];
        private List<string[]> _remainingquestions = new List<string[]>();
        private int _portionIndex;
        private bool _isChecking = false;
        private int _portionLength = 5;
        public Controller(Model model, MainForm view)
        {
            this._model = model;
            this._view = view;
            InitMVC();
            SetGame();
            SetPortion();
            SetQuestion();
        }
        private void InitMVC()
        {
            this._view.Controller = this;
            this._model.Controller = this;
        }
        public void ChangeImage(string stringImgPath)
        {
            string filePath = Environment.CurrentDirectory + "\\assets\\allroadsigns\\" + stringImgPath;
            this._view.DrawImage(filePath);

        }
        public void CheckQuestion(string answer)
        {
            answer = answer.ToLower();
            string expectedAnswer = this._currentAnswer[1].ToLower();
            bool partiallyMastered = false;
            // Regarder si la réponse a déjà été maîtrisée
            if (this._currentPortionAnswered.Count > 0)
            {
                foreach (string[] rowAnswered in this._currentPortionAnswered)
                {
                    // effectivement présente -> maîtrisé
                    if (rowAnswered == this._currentAnswer)
                    {
                        partiallyMastered = true;
                    }
                }
            }

            if (this._isChecking)
            {
                if (answer == expectedAnswer)
                {
                    this._view.SwitchErase();
                    SetQuestion();
                }
                else
                {
                    this._view.SwitchIncorrect();
                    this._view.ShowAnswer(this._currentAnswer[1]);
                }
            }
            else
            {
                // si la réponse est correcte
                if (answer == expectedAnswer)
                {
                    if (partiallyMastered)
                    {
                        // -> maîtrisé
                        this._currentPortion.RemoveAt(this._portionIndex);
                        this._masteredAnswers++;
                    }
                    else
                    {
                        // Si pas présente -> 1ère bonne réponse
                        this._currentPortionAnswered.Add(this._currentAnswer);
                    }
                    this._view.SwitchCorrect();
                    SetQuestion();
                }
                // si la réponse est incorrecte
                else
                {
                    if (partiallyMastered && this._currentPortionAnswered.Remove(this._currentAnswer))
                    {
                        Debug.WriteLine("La maîtrise a été perdue.");
                    }
                    this._isChecking = true;
                    this._view.ShowAnswer(this._currentAnswer[1]);
                    this._view.SwitchIncorrect();
                }
            }
        }
        // Sélection d'une question au hasard et affichage de l'image
        private void SetQuestion()
        {
            if (this._currentPortion.Count == 0)
            {
                SetPortion();
            }
            this._view.UpdatePortionScore(5 - this._currentPortion.Count, this._portionLength);
            this._view.HideAnswer();
            this._view.UpdateProgressionLabel(this._masteredAnswers, this._model.AllRoadSignsData.Count);
            this._isChecking = false;
            int newIndex = 0;
            Random rnd = new Random();

            // Ne pas permettre la même question précédente
            if (this._currentPortion.Count > 1)
            {
                do
                {
                    newIndex = rnd.Next(this._currentPortion.Count);

                } while (newIndex == this._portionIndex);
            }
            
            this._portionIndex = newIndex;
            this._currentAnswer = this._currentPortion[this._portionIndex];

            ChangeImage(this._currentAnswer[0]);
            
        }
        // Remplir currentPortion et vider currentPortionAnswered
        private void SetPortion()
        {
            Debug.WriteLine("Attribution d'une nouvelle portion...");
            this._portionIndex = 0;
            if (this._remainingquestions.Count == 0)
            {
                SetGame();
            }
            this._currentPortion.Clear();
            this._currentPortionAnswered.Clear();
            
            if (this._remainingquestions.Count < this._portionLength)
            {
                this._portionLength = this._remainingquestions.Count;
            }
            int randomizedIndex;
            Random rnd = new Random();
            for (int i = 0; i < this._portionLength; i++)
            {
                randomizedIndex = rnd.Next(this._remainingquestions.Count);
                this._currentPortion.Add(this._remainingquestions[randomizedIndex]);
                this._remainingquestions.RemoveAt(randomizedIndex);
            }
        }
        private void SetGame()
        {
            Debug.WriteLine("Attribution d'une nouvelle partie...");
            this._view.SwitchErase();
            this._masteredAnswers = 0;
            this._remainingquestions.Clear();

            foreach (string[] row in this._model.AllRoadSignsData)
            {
                this._remainingquestions.Add(row);
            }  
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
