namespace Untangle
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            this.Field = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CrossingEdgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OffToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SmoothingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OnToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.OffToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Field
            // 
            this.Field.Location = new System.Drawing.Point(0, 44);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(933, 589);
            this.Field.TabIndex = 0;
            this.Field.TabStop = false;
            this.Field.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Field_MouseDown);
            this.Field.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Field_MouseMove);
            this.Field.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Field_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SolutionToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.NewGameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SolutionToolStripMenuItem
            // 
            this.SolutionToolStripMenuItem.Name = "SolutionToolStripMenuItem";
            this.SolutionToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.SolutionToolStripMenuItem.Text = "Решение";
            this.SolutionToolStripMenuItem.Click += new System.EventHandler(this.SolveToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainSettingsToolStripMenuItem,
            this.CrossingEdgesToolStripMenuItem,
            this.SmoothingToolStripMenuItem1});
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.SettingsToolStripMenuItem.Text = "Настройки";
            // 
            // MainSettingsToolStripMenuItem
            // 
            this.MainSettingsToolStripMenuItem.Name = "MainSettingsToolStripMenuItem";
            this.MainSettingsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.MainSettingsToolStripMenuItem.Text = "Основные";
            this.MainSettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // CrossingEdgesToolStripMenuItem
            // 
            this.CrossingEdgesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OnToolStripMenuItem1,
            this.OffToolStripMenuItem1});
            this.CrossingEdgesToolStripMenuItem.Name = "CrossingEdgesToolStripMenuItem";
            this.CrossingEdgesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.CrossingEdgesToolStripMenuItem.Text = "Пересечение рёбер";
            // 
            // OnToolStripMenuItem1
            // 
            this.OnToolStripMenuItem1.Name = "OnToolStripMenuItem1";
            this.OnToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.OnToolStripMenuItem1.Text = "Включить";
            this.OnToolStripMenuItem1.Click += new System.EventHandler(this.OnToolStripMenuItem1_Click);
            // 
            // OffToolStripMenuItem1
            // 
            this.OffToolStripMenuItem1.Name = "OffToolStripMenuItem1";
            this.OffToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.OffToolStripMenuItem1.Text = "Выключить";
            this.OffToolStripMenuItem1.Click += new System.EventHandler(this.OffToolStripMenuItem1_Click);
            // 
            // SmoothingToolStripMenuItem1
            // 
            this.SmoothingToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OnToolStripMenuItem2,
            this.OffToolStripMenuItem2});
            this.SmoothingToolStripMenuItem1.Name = "SmoothingToolStripMenuItem1";
            this.SmoothingToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.SmoothingToolStripMenuItem1.Text = "Сглаживание";
            // 
            // OnToolStripMenuItem2
            // 
            this.OnToolStripMenuItem2.Name = "OnToolStripMenuItem2";
            this.OnToolStripMenuItem2.Size = new System.Drawing.Size(138, 22);
            this.OnToolStripMenuItem2.Text = "Включить";
            this.OnToolStripMenuItem2.Click += new System.EventHandler(this.SmoothingOn);
            // 
            // OffToolStripMenuItem2
            // 
            this.OffToolStripMenuItem2.Name = "OffToolStripMenuItem2";
            this.OffToolStripMenuItem2.Size = new System.Drawing.Size(138, 22);
            this.OffToolStripMenuItem2.Text = "Выключить";
            this.OffToolStripMenuItem2.Click += new System.EventHandler(this.SmoothingOff);
            // 
            // NewGameToolStripMenuItem
            // 
            this.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem";
            this.NewGameToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.NewGameToolStripMenuItem.Text = "Новая игра";
            this.NewGameToolStripMenuItem.Click += new System.EventHandler(this.NewGameToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 590);
            this.Controls.Add(this.Field);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Shown += new System.EventHandler(this.GameForm_Shown);
            this.Resize += new System.EventHandler(this.GameForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Field;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SolutionToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrossingEdgesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OnToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OffToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SmoothingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OnToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem OffToolStripMenuItem2;
    }
}