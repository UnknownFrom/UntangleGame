namespace Untangle
{
    partial class RecordsForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RecordsLabel = new System.Windows.Forms.Label();
            this.RecordsTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.RecordsLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RecordsTextBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 467);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RecordsLabel
            // 
            this.RecordsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecordsLabel.AutoSize = true;
            this.RecordsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RecordsLabel.Location = new System.Drawing.Point(3, 0);
            this.RecordsLabel.Name = "RecordsLabel";
            this.RecordsLabel.Size = new System.Drawing.Size(400, 60);
            this.RecordsLabel.TabIndex = 0;
            this.RecordsLabel.Text = "Рекорды";
            this.RecordsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RecordsTextBox
            // 
            this.RecordsTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.RecordsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RecordsTextBox.Location = new System.Drawing.Point(3, 63);
            this.RecordsTextBox.Multiline = true;
            this.RecordsTextBox.Name = "RecordsTextBox";
            this.RecordsTextBox.ReadOnly = true;
            this.RecordsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.RecordsTextBox.Size = new System.Drawing.Size(400, 401);
            this.RecordsTextBox.TabIndex = 1;
            this.RecordsTextBox.TabStop = false;
            this.RecordsTextBox.Text = "Имя:\r\nХодов:\r\nРешений:\r\nУровень:\r\nВремя:";
            // 
            // RecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 467);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RecordsForm";
            this.Text = "RecordsForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label RecordsLabel;
        private System.Windows.Forms.TextBox RecordsTextBox;
    }
}