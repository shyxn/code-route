
namespace code_route
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imgQuestionPB = new System.Windows.Forms.PictureBox();
            this.AnswerLbl = new System.Windows.Forms.Label();
            this.ProgressionLabel = new System.Windows.Forms.Label();
            this.AnswerTxtBox = new System.Windows.Forms.TextBox();
            this.PortionLabel = new System.Windows.Forms.Label();
            this.CheckLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgQuestionPB)).BeginInit();
            this.SuspendLayout();
            // 
            // imgQuestionPB
            // 
            this.imgQuestionPB.BackColor = System.Drawing.Color.Transparent;
            this.imgQuestionPB.Location = new System.Drawing.Point(32, 25);
            this.imgQuestionPB.Name = "imgQuestionPB";
            this.imgQuestionPB.Size = new System.Drawing.Size(120, 120);
            this.imgQuestionPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgQuestionPB.TabIndex = 0;
            this.imgQuestionPB.TabStop = false;
            // 
            // AnswerLbl
            // 
            this.AnswerLbl.AutoSize = true;
            this.AnswerLbl.BackColor = System.Drawing.Color.Transparent;
            this.AnswerLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerLbl.Location = new System.Drawing.Point(35, 175);
            this.AnswerLbl.Name = "AnswerLbl";
            this.AnswerLbl.Size = new System.Drawing.Size(114, 23);
            this.AnswerLbl.TabIndex = 2;
            this.AnswerLbl.Text = "AnswerLbl";
            // 
            // ProgressionLabel
            // 
            this.ProgressionLabel.AutoSize = true;
            this.ProgressionLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProgressionLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressionLabel.Location = new System.Drawing.Point(200, 28);
            this.ProgressionLabel.Name = "ProgressionLabel";
            this.ProgressionLabel.Size = new System.Drawing.Size(176, 23);
            this.ProgressionLabel.TabIndex = 3;
            this.ProgressionLabel.Text = "labelProgression";
            // 
            // AnswerTxtBox
            // 
            this.AnswerTxtBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerTxtBox.Location = new System.Drawing.Point(188, 105);
            this.AnswerTxtBox.Name = "AnswerTxtBox";
            this.AnswerTxtBox.Size = new System.Drawing.Size(314, 32);
            this.AnswerTxtBox.TabIndex = 4;
            this.AnswerTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnswerTxtBox_KeyDown);
            // 
            // PortionLabel
            // 
            this.PortionLabel.AutoSize = true;
            this.PortionLabel.BackColor = System.Drawing.Color.Transparent;
            this.PortionLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortionLabel.Location = new System.Drawing.Point(200, 63);
            this.PortionLabel.Name = "PortionLabel";
            this.PortionLabel.Size = new System.Drawing.Size(143, 23);
            this.PortionLabel.TabIndex = 5;
            this.PortionLabel.Text = "label portions";
            // 
            // CheckLbl
            // 
            this.CheckLbl.AutoSize = true;
            this.CheckLbl.BackColor = System.Drawing.Color.Transparent;
            this.CheckLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckLbl.Location = new System.Drawing.Point(508, 109);
            this.CheckLbl.Name = "CheckLbl";
            this.CheckLbl.Size = new System.Drawing.Size(102, 23);
            this.CheckLbl.TabIndex = 2;
            this.CheckLbl.Text = "CheckLbl";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1107, 269);
            this.Controls.Add(this.PortionLabel);
            this.Controls.Add(this.AnswerTxtBox);
            this.Controls.Add(this.ProgressionLabel);
            this.Controls.Add(this.CheckLbl);
            this.Controls.Add(this.AnswerLbl);
            this.Controls.Add(this.imgQuestionPB);
            this.Name = "MainForm";
            this.Text = "Code de la route Suisse";
            ((System.ComponentModel.ISupportInitialize)(this.imgQuestionPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgQuestionPB;
        private System.Windows.Forms.Label AnswerLbl;
        private System.Windows.Forms.Label ProgressionLabel;
        private System.Windows.Forms.TextBox AnswerTxtBox;
        private System.Windows.Forms.Label PortionLabel;
        private System.Windows.Forms.Label CheckLbl;
    }
}

