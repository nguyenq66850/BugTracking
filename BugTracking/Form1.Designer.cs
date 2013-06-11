namespace BugTracking
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
            this.bugnumLabel = new System.Windows.Forms.Label();
            this.bugnumTBox = new System.Windows.Forms.TextBox();
            this.previewPanel = new System.Windows.Forms.RichTextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.blockLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bugnumLabel
            // 
            this.bugnumLabel.AutoSize = true;
            this.bugnumLabel.Location = new System.Drawing.Point(30, 30);
            this.bugnumLabel.Name = "bugnumLabel";
            this.bugnumLabel.Size = new System.Drawing.Size(66, 13);
            this.bugnumLabel.TabIndex = 0;
            this.bugnumLabel.Text = "Bug Number";
            // 
            // bugnumTBox
            // 
            this.bugnumTBox.Location = new System.Drawing.Point(100, 27);
            this.bugnumTBox.Name = "bugnumTBox";
            this.bugnumTBox.Size = new System.Drawing.Size(100, 20);
            this.bugnumTBox.TabIndex = 1;
            this.bugnumTBox.Text = "38868";
            // 
            // previewPanel
            // 
            this.previewPanel.Location = new System.Drawing.Point(450, 20);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(550, 700);
            this.previewPanel.TabIndex = 2;
            this.previewPanel.Text = "";
            this.previewPanel.WordWrap = false;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(270, 25);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(350, 25);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "File";
            // 
            // blockLabel
            // 
            this.blockLabel.AutoSize = true;
            this.blockLabel.Location = new System.Drawing.Point(150, 60);
            this.blockLabel.Name = "blockLabel";
            this.blockLabel.Size = new System.Drawing.Size(75, 13);
            this.blockLabel.TabIndex = 6;
            this.blockLabel.Text = "Blocks of lines";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this.blockLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.bugnumTBox);
            this.Controls.Add(this.bugnumLabel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bug Tracking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bugnumLabel;
        private System.Windows.Forms.TextBox bugnumTBox;
        private System.Windows.Forms.RichTextBox previewPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label blockLabel;
    }
}

