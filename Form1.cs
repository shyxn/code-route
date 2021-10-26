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

        private void changeImgBtn_Click(object sender, EventArgs e)
        {
            this._controller.ChangeImage();
        }
        public void DrawImage(string filePath)
        {
            this.pictureBox1.Image = new Bitmap(filePath);
            this.pictureBox1.Visible = true;
        }
        public void ChangeLabel(string text)
        {
            this.label1.Text = text;
        }
    }
}
