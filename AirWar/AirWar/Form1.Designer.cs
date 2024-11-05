namespace AirWar
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            pistola1 = new GameObjects.Pistola();
            bala1 = new GameObjects.Bala();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.flecha;
            pictureBox1.Location = new Point(12, 338);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(753, 85);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pistola1
            // 
            pistola1.Anchor = AnchorStyles.Bottom;
            pistola1.BackColor = Color.Transparent;
            pistola1.BackgroundImage = (Image)resources.GetObject("pistola1.BackgroundImage");
            pistola1.BackgroundImageLayout = ImageLayout.None;
            pistola1.ForeColor = Color.Transparent;
            pistola1.Location = new Point(319, 337);
            pistola1.Margin = new Padding(0, 5, 0, 5);
            pistola1.Name = "pistola1";
            pistola1.Size = new Size(83, 101);
            pistola1.TabIndex = 1;
            // 
            // bala1
            // 
            bala1.BackColor = Color.Transparent;
            bala1.BackgroundImage = (Image)resources.GetObject("bala1.BackgroundImage");
            bala1.BackgroundImageLayout = ImageLayout.None;
            bala1.ForeColor = Color.Transparent;
            bala1.Location = new Point(417, 297);
            bala1.Name = "bala1";
            bala1.Size = new Size(18, 32);
            bala1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 450);
            Controls.Add(bala1);
            Controls.Add(pistola1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GameObjects.Pistola pistola1;
        private GameObjects.Bala bala1;
    }
}
