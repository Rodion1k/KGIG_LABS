namespace Lp_Lab02
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.imageToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(922, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.imageToolStripMenuItem1 });
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.imageToolStripMenuItem.Text = "Test";
            // 
            // imageToolStripMenuItem1
            // 
            this.imageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addMenuItem, this.saveMenuItem });
            this.imageToolStripMenuItem1.Name = "imageToolStripMenuItem1";
            this.imageToolStripMenuItem1.Size = new System.Drawing.Size(152, 24);
            this.imageToolStripMenuItem1.Text = "Image";
            // 
            // addMenuItem
            // 
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(152, 24);
            this.addMenuItem.Text = "Save";
            this.addMenuItem.Click += new System.EventHandler(this.ClickSaveImageMenuItem);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(152, 24);
            this.saveMenuItem.Text = "Add";
            this.saveMenuItem.Click += new System.EventHandler(this.ClickAddImageMenuItem);
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainGroupBox.Location = new System.Drawing.Point(0, 28);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Size = new System.Drawing.Size(922, 517);
            this.mainGroupBox.TabIndex = 1;
            this.mainGroupBox.TabStop = false;
            this.mainGroupBox.Click += new System.EventHandler(this.ClickMainGroupBox);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(922, 546);
            this.Controls.Add(this.mainGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(940, 593);
            this.MinimumSize = new System.Drawing.Size(940, 593);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        #endregion
    }
}