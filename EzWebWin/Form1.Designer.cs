namespace EzWebWin
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
            numericUpDown2 = new NumericUpDown();
            groupBox1 = new GroupBox();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            textBox2 = new TextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            basicTutorialToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(6, 26);
            numericUpDown2.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(183, 27);
            numericUpDown2.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDown2);
            groupBox1.Location = new Point(12, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(195, 64);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Port";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(18, 367);
            button1.Name = "button1";
            button1.Size = new Size(183, 29);
            button1.TabIndex = 4;
            button1.Text = "Start server";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.ControlLight;
            textBox1.Location = new Point(213, 34);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(307, 397);
            textBox1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(18, 104);
            button2.Name = "button2";
            button2.Size = new Size(183, 29);
            button2.TabIndex = 6;
            button2.Text = "Choose path";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Enabled = false;
            textBox2.Location = new Point(12, 139);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(195, 103);
            textBox2.TabIndex = 7;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.Enabled = false;
            button3.Location = new Point(18, 402);
            button3.Name = "button3";
            button3.Size = new Size(183, 29);
            button3.TabIndex = 8;
            button3.Text = "Stop";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.Image = Properties.Resources.EzWeb;
            pictureBox1.Location = new Point(18, 248);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(183, 113);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { basicTutorialToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(532, 28);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // basicTutorialToolStripMenuItem
            // 
            basicTutorialToolStripMenuItem.Name = "basicTutorialToolStripMenuItem";
            basicTutorialToolStripMenuItem.Size = new Size(109, 24);
            basicTutorialToolStripMenuItem.Text = "Basic tutorial";
            basicTutorialToolStripMenuItem.Click += basicTutorialToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(64, 24);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(532, 443);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(textBox2);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(550, 490);
            Name = "Form1";
            Text = "EzWeb";
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDown2;
        private GroupBox groupBox1;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private TextBox textBox2;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button3;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem basicTutorialToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}
