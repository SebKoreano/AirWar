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
            label1 = new Label();
            label2 = new Label();
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
            pictureBox1.MouseDown += btn1_MouseDown;
            pictureBox1.MouseUp += btn1_MouseUp;
            // 
            // pistola1
            // 
            pistola1.Anchor = AnchorStyles.Bottom;
            pistola1.BackColor = Color.Transparent;
            pistola1.BackgroundImage = (Image)resources.GetObject("pistola1.BackgroundImage");
            pistola1.BackgroundImageLayout = ImageLayout.None;
            pistola1.ForeColor = Color.Transparent;
            pistola1.Location = new Point(425, 337);
            pistola1.Margin = new Padding(0, 5, 0, 5);
            pistola1.Name = "pistola1";
            pistola1.Size = new Size(83, 101);
            pistola1.TabIndex = 1;
            pistola1.MouseDown += btn1_MouseDown;
            pistola1.MouseUp += btn1_MouseUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(727, 9);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 4;
            label2.Text = "label2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pistola1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            MouseClick += btn1_MouseClick;
            MouseDown += btn1_MouseDown;
            MouseUp += btn1_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private GameObjects.Pistola pistola1;
        private Label label1;
        private Label label2;
    }
}
