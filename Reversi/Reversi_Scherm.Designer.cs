namespace Reversi
{
    partial class reversi_scherm
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
            this.nieuw_spel = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.panel_speelveld = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // nieuw_spel
            // 
            this.nieuw_spel.Location = new System.Drawing.Point(542, 74);
            this.nieuw_spel.Name = "nieuw_spel";
            this.nieuw_spel.Size = new System.Drawing.Size(177, 32);
            this.nieuw_spel.TabIndex = 0;
            this.nieuw_spel.Text = "Nieuw Spel";
            this.nieuw_spel.UseVisualStyleBackColor = true;
            this.nieuw_spel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nieuw_spel_MouseClick);
            // 
            // help
            // 
            this.help.Location = new System.Drawing.Point(542, 126);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(177, 35);
            this.help.TabIndex = 1;
            this.help.Text = "Ik heb hulp nodig!";
            this.help.UseVisualStyleBackColor = true;
            this.help.MouseClick += new System.Windows.Forms.MouseEventHandler(this.help_MouseClick);
            // 
            // panel_speelveld
            // 
            this.panel_speelveld.Location = new System.Drawing.Point(57, 74);
            this.panel_speelveld.Name = "panel_speelveld";
            this.panel_speelveld.Size = new System.Drawing.Size(401, 401);
            this.panel_speelveld.TabIndex = 2;
            this.panel_speelveld.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_speelveld_Paint);
            this.panel_speelveld.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_speelveld_MouseClick);
            // 
            // reversi_scherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 539);
            this.Controls.Add(this.panel_speelveld);
            this.Controls.Add(this.help);
            this.Controls.Add(this.nieuw_spel);
            this.Name = "reversi_scherm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nieuw_spel;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Panel panel_speelveld;
    }
}