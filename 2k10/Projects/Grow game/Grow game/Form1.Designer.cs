namespace Grow_game
{
    partial class Form1
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.eau = new System.Windows.Forms.Button();
            this.feu = new System.Windows.Forms.Button();
            this.air = new System.Windows.Forms.Button();
            this.terre = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.eau);
            this.flowLayoutPanel1.Controls.Add(this.feu);
            this.flowLayoutPanel1.Controls.Add(this.air);
            this.flowLayoutPanel1.Controls.Add(this.terre);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 403);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(751, 31);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // eau
            // 
            this.eau.AutoSize = true;
            this.eau.Location = new System.Drawing.Point(3, 3);
            this.eau.Name = "eau";
            this.eau.Size = new System.Drawing.Size(181, 23);
            this.eau.TabIndex = 0;
            this.eau.Text = "Eau";
            this.eau.UseVisualStyleBackColor = true;
            this.eau.Click += new System.EventHandler(this.button4_Click);
            // 
            // feu
            // 
            this.feu.AutoSize = true;
            this.feu.Location = new System.Drawing.Point(190, 3);
            this.feu.Name = "feu";
            this.feu.Size = new System.Drawing.Size(181, 23);
            this.feu.TabIndex = 0;
            this.feu.Text = "Feu";
            this.feu.UseVisualStyleBackColor = true;
            this.feu.Click += new System.EventHandler(this.button1_Click);
            // 
            // air
            // 
            this.air.AutoSize = true;
            this.air.Location = new System.Drawing.Point(377, 3);
            this.air.Name = "air";
            this.air.Size = new System.Drawing.Size(181, 23);
            this.air.TabIndex = 0;
            this.air.Text = "Air";
            this.air.UseVisualStyleBackColor = true;
            this.air.Click += new System.EventHandler(this.button2_Click);
            // 
            // terre
            // 
            this.terre.AutoSize = true;
            this.terre.Location = new System.Drawing.Point(564, 3);
            this.terre.Name = "terre";
            this.terre.Size = new System.Drawing.Size(181, 23);
            this.terre.TabIndex = 0;
            this.terre.Text = "Terre";
            this.terre.UseVisualStyleBackColor = true;
            this.terre.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(751, 400);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "1: ";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 434);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button feu;
        private System.Windows.Forms.Button air;
        private System.Windows.Forms.Button terre;
        private System.Windows.Forms.Button eau;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

