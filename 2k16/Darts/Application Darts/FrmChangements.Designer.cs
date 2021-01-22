namespace Application_Darts
{
    partial class FrmChangements
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstJoueurs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAjout = new System.Windows.Forms.Button();
            this.txtAjout = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSauvQuit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSupp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstJoueurs
            // 
            this.lstJoueurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstJoueurs.FormattingEnabled = true;
            this.lstJoueurs.ItemHeight = 20;
            this.lstJoueurs.Location = new System.Drawing.Point(228, 58);
            this.lstJoueurs.Name = "lstJoueurs";
            this.lstJoueurs.Size = new System.Drawing.Size(239, 284);
            this.lstJoueurs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Liste des joueurs";
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(35, 124);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(124, 32);
            this.btnAjout.TabIndex = 2;
            this.btnAjout.Text = "Ajouter";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // txtAjout
            // 
            this.txtAjout.Location = new System.Drawing.Point(35, 66);
            this.txtAjout.Name = "txtAjout";
            this.txtAjout.Size = new System.Drawing.Size(124, 32);
            this.txtAjout.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAjout);
            this.groupBox1.Controls.Add(this.btnAjout);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 222);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ajouter un joueur";
            // 
            // btnSauvQuit
            // 
            this.btnSauvQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSauvQuit.Location = new System.Drawing.Point(228, 348);
            this.btnSauvQuit.Name = "btnSauvQuit";
            this.btnSauvQuit.Size = new System.Drawing.Size(239, 42);
            this.btnSauvQuit.TabIndex = 10;
            this.btnSauvQuit.Text = "Sauvegarder et quitter";
            this.btnSauvQuit.UseVisualStyleBackColor = true;
            this.btnSauvQuit.Click += new System.EventHandler(this.btnSauvQuit_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(228, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 37);
            this.button1.TabIndex = 11;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSupp
            // 
            this.btnSupp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupp.Location = new System.Drawing.Point(473, 223);
            this.btnSupp.Name = "btnSupp";
            this.btnSupp.Size = new System.Drawing.Size(124, 42);
            this.btnSupp.TabIndex = 3;
            this.btnSupp.Text = "Supprimer";
            this.btnSupp.UseVisualStyleBackColor = true;
            this.btnSupp.Click += new System.EventHandler(this.btnSupp_Click);
            // 
            // FrmChangements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 445);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSupp);
            this.Controls.Add(this.btnSauvQuit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstJoueurs);
            this.Name = "FrmChangements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifications de joueurs";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstJoueurs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.TextBox txtAjout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSauvQuit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSupp;
    }
}