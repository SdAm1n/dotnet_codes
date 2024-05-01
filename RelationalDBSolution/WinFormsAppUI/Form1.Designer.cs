namespace WinFormsAppUI
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
            FirstNameLabel = new Label();
            FirstNameTextBox = new TextBox();
            LastNameLabel = new Label();
            LastNameTextBox = new TextBox();
            EmailLabel = new Label();
            EmailTextBox = new TextBox();
            PhoneLabel = new Label();
            PhoneTextBox = new TextBox();
            SubmitBtn = new Button();
            SuspendLayout();
            // 
            // FirstNameLabel
            // 
            FirstNameLabel.AutoSize = true;
            FirstNameLabel.Location = new Point(283, 98);
            FirstNameLabel.Name = "FirstNameLabel";
            FirstNameLabel.Size = new Size(102, 25);
            FirstNameLabel.TabIndex = 0;
            FirstNameLabel.Text = "First Name";
            // 
            // FirstNameTextBox
            // 
            FirstNameTextBox.Location = new Point(415, 95);
            FirstNameTextBox.Name = "FirstNameTextBox";
            FirstNameTextBox.Size = new Size(323, 33);
            FirstNameTextBox.TabIndex = 1;
            // 
            // LastNameLabel
            // 
            LastNameLabel.AutoSize = true;
            LastNameLabel.Location = new Point(283, 167);
            LastNameLabel.Name = "LastNameLabel";
            LastNameLabel.Size = new Size(100, 25);
            LastNameLabel.TabIndex = 0;
            LastNameLabel.Text = "Last Name";
            // 
            // LastNameTextBox
            // 
            LastNameTextBox.Location = new Point(415, 164);
            LastNameTextBox.Name = "LastNameTextBox";
            LastNameTextBox.Size = new Size(323, 33);
            LastNameTextBox.TabIndex = 1;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(283, 238);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(58, 25);
            EmailLabel.TabIndex = 0;
            EmailLabel.Text = "Email";
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(415, 235);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(323, 33);
            EmailTextBox.TabIndex = 1;
            // 
            // PhoneLabel
            // 
            PhoneLabel.AutoSize = true;
            PhoneLabel.Location = new Point(283, 307);
            PhoneLabel.Name = "PhoneLabel";
            PhoneLabel.Size = new Size(66, 25);
            PhoneLabel.TabIndex = 0;
            PhoneLabel.Text = "Phone";
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(415, 304);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(323, 33);
            PhoneTextBox.TabIndex = 1;
            // 
            // SubmitBtn
            // 
            SubmitBtn.Location = new Point(510, 393);
            SubmitBtn.Name = "SubmitBtn";
            SubmitBtn.Size = new Size(131, 49);
            SubmitBtn.TabIndex = 2;
            SubmitBtn.Text = "Submit";
            SubmitBtn.UseVisualStyleBackColor = true;
            SubmitBtn.Click += SubmitBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 522);
            Controls.Add(SubmitBtn);
            Controls.Add(PhoneTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(LastNameTextBox);
            Controls.Add(FirstNameTextBox);
            Controls.Add(PhoneLabel);
            Controls.Add(EmailLabel);
            Controls.Add(LastNameLabel);
            Controls.Add(FirstNameLabel);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FirstNameLabel;
        private TextBox FirstNameTextBox;
        private Label LastNameLabel;
        private TextBox LastNameTextBox;
        private Label EmailLabel;
        private TextBox EmailTextBox;
        private Label PhoneLabel;
        private TextBox PhoneTextBox;
        private Button SubmitBtn;
    }
}
