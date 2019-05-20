namespace testJump
{
    partial class GameEnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameEnd));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.yourscore = new System.Windows.Forms.Label();
            this.highscore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonMenu = new System.Windows.Forms.PictureBox();
            this.buttonResume = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonScores = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonResume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonScores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(78, 612);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(3, 3);
            this.textBox1.TabIndex = 0;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::testJump.Properties.Resources.GameOver;
            this.pictureBox1.Location = new System.Drawing.Point(50, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // yourscore
            // 
            this.yourscore.AutoSize = true;
            this.yourscore.BackColor = System.Drawing.Color.Transparent;
            this.yourscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yourscore.Location = new System.Drawing.Point(26, 181);
            this.yourscore.Name = "yourscore";
            this.yourscore.Size = new System.Drawing.Size(214, 42);
            this.yourscore.TabIndex = 2;
            this.yourscore.Text = "your score:";
            // 
            // highscore
            // 
            this.highscore.AutoSize = true;
            this.highscore.BackColor = System.Drawing.Color.Transparent;
            this.highscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscore.Location = new System.Drawing.Point(26, 226);
            this.highscore.Name = "highscore";
            this.highscore.Size = new System.Drawing.Size(198, 39);
            this.highscore.TabIndex = 3;
            this.highscore.Text = "high score:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 39);
            this.label3.TabIndex = 4;
            this.label3.Text = "your name:";
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonMenu.Image = global::testJump.Properties.Resources.menu_2x;
            this.buttonMenu.Location = new System.Drawing.Point(28, 354);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(164, 69);
            this.buttonMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonMenu.TabIndex = 5;
            this.buttonMenu.TabStop = false;
            this.buttonMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonMenu_MouseClick);
            this.buttonMenu.MouseLeave += new System.EventHandler(this.buttonMenu_MouseLeave);
            this.buttonMenu.MouseHover += new System.EventHandler(this.buttonMenu_MouseHover);
            // 
            // buttonResume
            // 
            this.buttonResume.BackColor = System.Drawing.Color.Transparent;
            this.buttonResume.Image = global::testJump.Properties.Resources.play_again_2x;
            this.buttonResume.Location = new System.Drawing.Point(248, 354);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(164, 69);
            this.buttonResume.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonResume.TabIndex = 5;
            this.buttonResume.TabStop = false;
            this.buttonResume.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonResume_MouseClick);
            this.buttonResume.MouseLeave += new System.EventHandler(this.buttonResume_MouseLeave);
            this.buttonResume.MouseHover += new System.EventHandler(this.buttonResume_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(62, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 42);
            this.label1.TabIndex = 6;
            this.label1.Text = "you aren\'t in top 10";
            this.label1.Visible = false;
            // 
            // buttonScores
            // 
            this.buttonScores.BackColor = System.Drawing.Color.Transparent;
            this.buttonScores.Image = global::testJump.Properties.Resources.score2x;
            this.buttonScores.Location = new System.Drawing.Point(136, 446);
            this.buttonScores.Name = "buttonScores";
            this.buttonScores.Size = new System.Drawing.Size(164, 69);
            this.buttonScores.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonScores.TabIndex = 7;
            this.buttonScores.TabStop = false;
            this.buttonScores.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonScores_MouseClick);
            this.buttonScores.MouseLeave += new System.EventHandler(this.buttonScores_MouseLeave);
            this.buttonScores.MouseHover += new System.EventHandler(this.buttonScores_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::testJump.Properties.Resources.bck_2x;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(434, 611);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(221, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 39);
            this.label2.TabIndex = 4;
            // 
            // GameEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 611);
            this.Controls.Add(this.buttonScores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonResume);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.highscore);
            this.Controls.Add(this.yourscore);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameEnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doodle Jump";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameEnd_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonResume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonScores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label yourscore;
        private System.Windows.Forms.Label highscore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox buttonMenu;
        private System.Windows.Forms.PictureBox buttonResume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox buttonScores;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
    }
}