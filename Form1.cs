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
    public partial class Form1 : Form
    {
        private Controller _controller;

        public Controller Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void DrawImage(string filePath)
        {
            this.pictureBox1.Image = new Bitmap(filePath);
            this.pictureBox1.Visible = true;
        }
        public void UpdateProgressionLabel(int data, int max)
        {
            this.progressionLabel.Text = "Progression : " + data + " / " + max + " questions";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this._controller.CheckQuestion(this.textBox1.Text);
            }
        }
        public void ShowAnswer(string answer)
        {
            this.textBox1.Clear();
            this.label1.Text = answer;
        }
        public void HideAnswer()
        {
            this.textBox1.Clear();
            this.label1.Text = "";
        }
        public void UpdatePortionScore(int currentScore, int max)
        {
            this.PortionLabel.Text = "Portion : " + currentScore + " / " + max + " questions";
        }
    }
}
