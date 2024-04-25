namespace MessageWall
{
    partial class Dashboard
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
            this.MessageLabel = new System.Windows.Forms.Label();
            this.MessageBoxText = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.MessageListBox = new System.Windows.Forms.ListBox();
            this.MessageListLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(247, 121);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(99, 25);
            this.MessageLabel.TabIndex = 0;
            this.MessageLabel.Text = "message";
            // 
            // MessageBoxText
            // 
            this.MessageBoxText.Location = new System.Drawing.Point(352, 118);
            this.MessageBoxText.Name = "MessageBoxText";
            this.MessageBoxText.Size = new System.Drawing.Size(396, 31);
            this.MessageBoxText.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(754, 118);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(93, 31);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton);
            // 
            // MessageListBox
            // 
            this.MessageListBox.FormattingEnabled = true;
            this.MessageListBox.ItemHeight = 25;
            this.MessageListBox.Location = new System.Drawing.Point(281, 241);
            this.MessageListBox.Name = "MessageListBox";
            this.MessageListBox.Size = new System.Drawing.Size(467, 254);
            this.MessageListBox.TabIndex = 3;
            // 
            // MessageListLabel
            // 
            this.MessageListLabel.AutoSize = true;
            this.MessageListLabel.Location = new System.Drawing.Point(276, 213);
            this.MessageListLabel.Name = "MessageListLabel";
            this.MessageListLabel.Size = new System.Drawing.Size(143, 25);
            this.MessageListLabel.TabIndex = 4;
            this.MessageListLabel.Text = "Message Box";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 604);
            this.Controls.Add(this.MessageListLabel);
            this.Controls.Add(this.MessageListBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.MessageBoxText);
            this.Controls.Add(this.MessageLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Dashboard";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.TextBox MessageBoxText;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox MessageListBox;
        private System.Windows.Forms.Label MessageListLabel;
    }
}

