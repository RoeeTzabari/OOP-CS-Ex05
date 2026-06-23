namespace Ex05.GameGUI
{
    partial class FormGame
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
            this.m_LabelScoreBoard = new System.Windows.Forms.Label();
            this.m_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // m_LabelScoreBoard
            // 
            this.m_LabelScoreBoard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_LabelScoreBoard.Location = new System.Drawing.Point(0, 753);
            this.m_LabelScoreBoard.Name = "m_LabelScoreBoard";
            this.m_LabelScoreBoard.Size = new System.Drawing.Size(926, 32);
            this.m_LabelScoreBoard.TabIndex = 1;
            this.m_LabelScoreBoard.Text = "[Score Board]";
            this.m_LabelScoreBoard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_TableLayoutPanel
            // 
            this.m_TableLayoutPanel.ColumnCount = 2;
            this.m_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.m_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_TableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.m_TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.m_TableLayoutPanel.Name = "m_TableLayoutPanel";
            this.m_TableLayoutPanel.RowCount = 2;
            this.m_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.m_TableLayoutPanel.Size = new System.Drawing.Size(926, 700);
            this.m_TableLayoutPanel.TabIndex = 2;
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 785);
            this.Controls.Add(this.m_LabelScoreBoard);
            this.Controls.Add(this.m_TableLayoutPanel);
            this.Name = "FormGame";
            this.Text = "FormGame";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label m_LabelScoreBoard;
        private System.Windows.Forms.TableLayoutPanel m_TableLayoutPanel;
    }
}