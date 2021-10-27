using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace code_route
{
    public partial class MainForm : Form
    {
        private Controller _controller;

        public Controller Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        public void DrawImage(string filePath)
        {
            this.imgQuestionPB.Image = new Bitmap(filePath);
            this.imgQuestionPB.Visible = true;
        }
        public void UpdateProgressionLabel(int data, int max)
        {
            this.ProgressionLabel.Text = "Progression : " + data + " / " + max + " questions";
        }

        private void AnswerTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this._controller.CheckQuestion(this.AnswerTxtBox.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        public void ShowAnswer(string answer)
        {
            this.AnswerTxtBox.Clear();
            this.AnswerLbl.Text = answer;
        }
        public void HideAnswer()
        {
            this.AnswerTxtBox.Clear();
            this.AnswerLbl.Text = "";
        }
        public void UpdatePortionScore(int currentScore, int max)
        {
            this.PortionLabel.Text = "Portion : " + currentScore + " / " + max + " questions";
        }
        public void SwitchCorrect()
        {
            this.CheckLbl.ForeColor = Color.Green;
            this.CheckLbl.Text = "Correct";
        }
        public void SwitchIncorrect()
        {
            this.CheckLbl.ForeColor = Color.Red;
            this.CheckLbl.Text = "Incorrect";
        }
        public void SwitchErase()
        {
            this.CheckLbl.Text = "";
        }
    }
}
