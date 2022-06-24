
namespace Сапёр
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ControlFormButtonsPanel = new System.Windows.Forms.Panel();
            this.ControlButtonsPanel = new System.Windows.Forms.Panel();
            this.MinimizeFormButton = new System.Windows.Forms.Button();
            this.CloseFormButton = new System.Windows.Forms.Button();
            this.GamePictureBoxPanel = new System.Windows.Forms.Panel();
            this.GamePictureBox = new System.Windows.Forms.PictureBox();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.BombsLeftLabel = new System.Windows.Forms.Label();
            this.SmileButton = new System.Windows.Forms.Button();
            this.PaddingPanel = new System.Windows.Forms.Panel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.ControlFormButtonsPanel.SuspendLayout();
            this.ControlButtonsPanel.SuspendLayout();
            this.GamePictureBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamePictureBox)).BeginInit();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlFormButtonsPanel
            // 
            this.ControlFormButtonsPanel.Controls.Add(this.ControlButtonsPanel);
            this.ControlFormButtonsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ControlFormButtonsPanel.Location = new System.Drawing.Point(252, 0);
            this.ControlFormButtonsPanel.Name = "ControlFormButtonsPanel";
            this.ControlFormButtonsPanel.Size = new System.Drawing.Size(88, 419);
            this.ControlFormButtonsPanel.TabIndex = 0;
            // 
            // ControlButtonsPanel
            // 
            this.ControlButtonsPanel.Controls.Add(this.MinimizeFormButton);
            this.ControlButtonsPanel.Controls.Add(this.CloseFormButton);
            this.ControlButtonsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlButtonsPanel.Name = "ControlButtonsPanel";
            this.ControlButtonsPanel.Size = new System.Drawing.Size(88, 29);
            this.ControlButtonsPanel.TabIndex = 0;
            // 
            // MinimizeFormButton
            // 
            this.MinimizeFormButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeFormButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.MinimizeFormButton.FlatAppearance.BorderSize = 0;
            this.MinimizeFormButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.MinimizeFormButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.MinimizeFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeFormButton.Image = global::Сапёр.Properties.Resources.minimize_button;
            this.MinimizeFormButton.Location = new System.Drawing.Point(0, 0);
            this.MinimizeFormButton.Name = "MinimizeFormButton";
            this.MinimizeFormButton.Size = new System.Drawing.Size(44, 29);
            this.MinimizeFormButton.TabIndex = 1;
            this.MinimizeFormButton.TabStop = false;
            this.MinimizeFormButton.UseVisualStyleBackColor = true;
            this.MinimizeFormButton.Click += new System.EventHandler(this.MinimizeFormButton_Click);
            this.MinimizeFormButton.MouseEnter += new System.EventHandler(this.MinimizeFormButton_MouseEnter);
            this.MinimizeFormButton.MouseLeave += new System.EventHandler(this.MinimizeFormButton_MouseLeave);
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseFormButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.CloseFormButton.FlatAppearance.BorderSize = 0;
            this.CloseFormButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.CloseFormButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.CloseFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseFormButton.Image = global::Сапёр.Properties.Resources.close_button;
            this.CloseFormButton.Location = new System.Drawing.Point(44, 0);
            this.CloseFormButton.Name = "CloseFormButton";
            this.CloseFormButton.Size = new System.Drawing.Size(44, 29);
            this.CloseFormButton.TabIndex = 0;
            this.CloseFormButton.TabStop = false;
            this.CloseFormButton.UseVisualStyleBackColor = true;
            this.CloseFormButton.Click += new System.EventHandler(this.CloseFormButton_Click);
            this.CloseFormButton.MouseEnter += new System.EventHandler(this.CloseFormButton_MouseEnter);
            this.CloseFormButton.MouseLeave += new System.EventHandler(this.CloseFormButton_MouseLeave);
            // 
            // GamePictureBoxPanel
            // 
            this.GamePictureBoxPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.GamePictureBoxPanel.Controls.Add(this.GamePictureBox);
            this.GamePictureBoxPanel.Location = new System.Drawing.Point(0, 79);
            this.GamePictureBoxPanel.Name = "GamePictureBoxPanel";
            this.GamePictureBoxPanel.Padding = new System.Windows.Forms.Padding(10);
            this.GamePictureBoxPanel.Size = new System.Drawing.Size(340, 340);
            this.GamePictureBoxPanel.TabIndex = 2;
            // 
            // GamePictureBox
            // 
            this.GamePictureBox.BackColor = System.Drawing.Color.Black;
            this.GamePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GamePictureBox.Location = new System.Drawing.Point(10, 10);
            this.GamePictureBox.Name = "GamePictureBox";
            this.GamePictureBox.Size = new System.Drawing.Size(320, 320);
            this.GamePictureBox.TabIndex = 1;
            this.GamePictureBox.TabStop = false;
            this.GamePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GamePictureBox_MouseDown);
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.MenuPanel.Controls.Add(this.TimerLabel);
            this.MenuPanel.Controls.Add(this.BombsLeftLabel);
            this.MenuPanel.Controls.Add(this.SmileButton);
            this.MenuPanel.Controls.Add(this.PaddingPanel);
            this.MenuPanel.Controls.Add(this.SettingsButton);
            this.MenuPanel.Location = new System.Drawing.Point(0, 29);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(340, 50);
            this.MenuPanel.TabIndex = 3;
            // 
            // TimerLabel
            // 
            this.TimerLabel.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimerLabel.Location = new System.Drawing.Point(209, 14);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(76, 35);
            this.TimerLabel.TabIndex = 4;
            this.TimerLabel.Text = "000";
            this.TimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TimerLabel.UseCompatibleTextRendering = true;
            // 
            // BombsLeftLabel
            // 
            this.BombsLeftLabel.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BombsLeftLabel.Location = new System.Drawing.Point(64, 14);
            this.BombsLeftLabel.Name = "BombsLeftLabel";
            this.BombsLeftLabel.Size = new System.Drawing.Size(76, 35);
            this.BombsLeftLabel.TabIndex = 3;
            this.BombsLeftLabel.Text = "000";
            this.BombsLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BombsLeftLabel.UseCompatibleTextRendering = true;
            // 
            // SmileButton
            // 
            this.SmileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.SmileButton.FlatAppearance.BorderSize = 0;
            this.SmileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.SmileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.SmileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SmileButton.Image = ((System.Drawing.Image)(resources.GetObject("SmileButton.Image")));
            this.SmileButton.Location = new System.Drawing.Point(150, 10);
            this.SmileButton.Name = "SmileButton";
            this.SmileButton.Size = new System.Drawing.Size(40, 40);
            this.SmileButton.TabIndex = 2;
            this.SmileButton.TabStop = false;
            this.SmileButton.UseVisualStyleBackColor = true;
            this.SmileButton.Click += new System.EventHandler(this.SmileButton_Click);
            // 
            // PaddingPanel
            // 
            this.PaddingPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaddingPanel.Location = new System.Drawing.Point(0, 0);
            this.PaddingPanel.Name = "PaddingPanel";
            this.PaddingPanel.Size = new System.Drawing.Size(340, 9);
            this.PaddingPanel.TabIndex = 1;
            // 
            // SettingsButton
            // 
            this.SettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.SettingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingsButton.Image")));
            this.SettingsButton.Location = new System.Drawing.Point(10, 9);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(40, 40);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.TabStop = false;
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            this.SettingsButton.MouseEnter += new System.EventHandler(this.SettingsButton_MouseEnter);
            this.SettingsButton.MouseLeave += new System.EventHandler(this.SettingsButton_MouseLeave);
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(340, 419);
            this.ControlBox = false;
            this.Controls.Add(this.GamePictureBoxPanel);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.ControlFormButtonsPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сапёр";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ControlFormButtonsPanel.ResumeLayout(false);
            this.ControlButtonsPanel.ResumeLayout(false);
            this.GamePictureBoxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GamePictureBox)).EndInit();
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlFormButtonsPanel;
        private System.Windows.Forms.Panel ControlButtonsPanel;
        private System.Windows.Forms.Button MinimizeFormButton;
        private System.Windows.Forms.Button CloseFormButton;
        private System.Windows.Forms.Panel GamePictureBoxPanel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Panel PaddingPanel;
        private System.Windows.Forms.Button SmileButton;
        public System.Windows.Forms.PictureBox GamePictureBox;
        private System.Windows.Forms.Label BombsLeftLabel;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Timer GameTimer;
    }
}

