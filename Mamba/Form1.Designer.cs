namespace Mamba
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
            components = new System.ComponentModel.Container();
            startButton = new Button();
            snapButton = new Button();
            picCanvas = new PictureBox();
            txtScore = new Label();
            txtHighScore = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            NvDif = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.Blue;
            startButton.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            startButton.ForeColor = SystemColors.Desktop;
            startButton.Location = new Point(755, 21);
            startButton.Name = "startButton";
            startButton.Size = new Size(161, 75);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += StartGame;
            // 
            // snapButton
            // 
            snapButton.BackColor = Color.Lime;
            snapButton.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            snapButton.ForeColor = SystemColors.Desktop;
            snapButton.Location = new Point(755, 102);
            snapButton.Name = "snapButton";
            snapButton.Size = new Size(161, 86);
            snapButton.TabIndex = 1;
            snapButton.Text = "Snap";
            snapButton.UseVisualStyleBackColor = false;
            snapButton.Click += TakeSnapShot;
            // 
            // picCanvas
            // 
            picCanvas.BackColor = SystemColors.ActiveBorder;
            picCanvas.BackgroundImage = Properties.Resources.desktop_wallpaper_snake_game_cool_green_gaming1;
            picCanvas.Location = new Point(21, 21);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(717, 553);
            picCanvas.TabIndex = 2;
            picCanvas.TabStop = false;
            picCanvas.Paint += UpdatePictureBoxGraphics;
            // 
            // txtScore
            // 
            txtScore.AutoSize = true;
            txtScore.Font = new Font("Gill Sans Ultra Bold", 12F, FontStyle.Italic, GraphicsUnit.Point);
            txtScore.Location = new Point(774, 248);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(114, 29);
            txtScore.TabIndex = 3;
            txtScore.Text = "Score: 0";
            // 
            // txtHighScore
            // 
            txtHighScore.AutoSize = true;
            txtHighScore.Font = new Font("Gill Sans Ultra Bold", 12F, FontStyle.Italic, GraphicsUnit.Point);
            txtHighScore.Location = new Point(755, 368);
            txtHighScore.Name = "txtHighScore";
            txtHighScore.Size = new Size(147, 29);
            txtHighScore.TabIndex = 4;
            txtHighScore.Text = "High Score";
            // 
            // gameTimer
            // 
            gameTimer.Interval = 40;
            gameTimer.Tick += GameTimerEvents;
            // 
            // NvDif
            // 
            NvDif.DropDownStyle = ComboBoxStyle.DropDownList;
            NvDif.FormattingEnabled = true;
            NvDif.Items.AddRange(new object[] { "EAZY", "MEDIUM", "HARD" });
            NvDif.Location = new Point(755, 304);
            NvDif.Name = "NvDif";
            NvDif.Size = new Size(151, 28);
            NvDif.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 608);
            Controls.Add(NvDif);
            Controls.Add(txtHighScore);
            Controls.Add(txtScore);
            Controls.Add(picCanvas);
            Controls.Add(snapButton);
            Controls.Add(startButton);
            Name = "Form1";
            Text = "Snake Game";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Button snapButton;
        private PictureBox picCanvas;
        private Label txtScore;
        private Label txtHighScore;
        private System.Windows.Forms.Timer gameTimer;
        private ComboBox NiveauxDeDifficulté;
        private ComboBox NvDif;
    }
}