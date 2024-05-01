namespace WindowsFormsApp
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
            FirstName = new Label();
            FirstNameTextBox = new TextBox();
            LastNameLabel = new Label();
            LastNametextBox = new TextBox();
            EmailLabel = new Label();
            EmailtextBox = new TextBox();
            PhoneNumberLabel = new Label();
            PhoneNumbertextBox = new TextBox();
            Submitbutton = new Button();
            SuspendLayout();
            // 
            // FirstName
            // 
            FirstName.AutoSize = true;
            FirstName.Location = new Point(279, 94);
            FirstName.Margin = new Padding(6, 0, 6, 0);
            FirstName.Name = "FirstName";
            FirstName.Size = new Size(116, 25);
            FirstName.TabIndex = 0;
            FirstName.Text = "First Name";
            // 
            // FirstNameTextBox
            // 
            FirstNameTextBox.Location = new Point(404, 94);
            FirstNameTextBox.Name = "FirstNameTextBox";
            FirstNameTextBox.Size = new Size(308, 31);
            FirstNameTextBox.TabIndex = 1;
            FirstNameTextBox.TextChanged += FirstNameTextBox_TextChanged;
            // 
            // LastNameLabel
            // 
            LastNameLabel.AutoSize = true;
            LastNameLabel.Location = new Point(279, 171);
            LastNameLabel.Margin = new Padding(6, 0, 6, 0);
            LastNameLabel.Name = "LastNameLabel";
            LastNameLabel.Size = new Size(115, 25);
            LastNameLabel.TabIndex = 0;
            LastNameLabel.Text = "Last Name";
            // 
            // LastNametextBox
            // 
            LastNametextBox.Location = new Point(404, 165);
            LastNametextBox.Name = "LastNametextBox";
            LastNametextBox.Size = new Size(308, 31);
            LastNametextBox.TabIndex = 1;
            LastNametextBox.TextChanged += LastNametextBox_TextChanged;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(279, 244);
            EmailLabel.Margin = new Padding(6, 0, 6, 0);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(65, 25);
            EmailLabel.TabIndex = 0;
            EmailLabel.Text = "Email";
            // 
            // EmailtextBox
            // 
            EmailtextBox.Location = new Point(404, 241);
            EmailtextBox.Name = "EmailtextBox";
            EmailtextBox.Size = new Size(308, 31);
            EmailtextBox.TabIndex = 1;
            // 
            // PhoneNumberLabel
            // 
            PhoneNumberLabel.AutoSize = true;
            PhoneNumberLabel.Location = new Point(279, 326);
            PhoneNumberLabel.Margin = new Padding(6, 0, 6, 0);
            PhoneNumberLabel.Name = "PhoneNumberLabel";
            PhoneNumberLabel.Size = new Size(74, 25);
            PhoneNumberLabel.TabIndex = 0;
            PhoneNumberLabel.Text = "Phone";
            // 
            // PhoneNumbertextBox
            // 
            PhoneNumbertextBox.Location = new Point(404, 320);
            PhoneNumbertextBox.Name = "PhoneNumbertextBox";
            PhoneNumbertextBox.Size = new Size(308, 31);
            PhoneNumbertextBox.TabIndex = 1;
            // 
            // Submitbutton
            // 
            Submitbutton.Location = new Point(439, 401);
            Submitbutton.Name = "Submitbutton";
            Submitbutton.Size = new Size(156, 55);
            Submitbutton.TabIndex = 2;
            Submitbutton.Text = "Submit";
            Submitbutton.UseVisualStyleBackColor = true;
            Submitbutton.Click += Submitbutton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1104, 574);
            Controls.Add(Submitbutton);
            Controls.Add(PhoneNumbertextBox);
            Controls.Add(EmailtextBox);
            Controls.Add(LastNametextBox);
            Controls.Add(PhoneNumberLabel);
            Controls.Add(EmailLabel);
            Controls.Add(LastNameLabel);
            Controls.Add(FirstNameTextBox);
            Controls.Add(FirstName);
            Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(6);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label FirstName;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox LastNametextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailtextBox;
        private System.Windows.Forms.Label PhoneNumberLabel;
        private System.Windows.Forms.TextBox PhoneNumbertextBox;
        private System.Windows.Forms.Button Submitbutton;
    }
}

