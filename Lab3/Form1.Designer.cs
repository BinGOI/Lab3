namespace Lab3
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
            this.button1 = new System.Windows.Forms.Button();
            this.uiInputFileName = new System.Windows.Forms.TextBox();
            this.uiOutputFileName = new System.Windows.Forms.TextBox();
            this.uiKeyField = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.uiEncryptButton = new System.Windows.Forms.Button();
            this.uiDecryptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open file to read";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiInputFileName
            // 
            this.uiInputFileName.Location = new System.Drawing.Point(85, 83);
            this.uiInputFileName.Name = "uiInputFileName";
            this.uiInputFileName.Size = new System.Drawing.Size(228, 20);
            this.uiInputFileName.TabIndex = 1;
            // 
            // uiOutputFileName
            // 
            this.uiOutputFileName.Location = new System.Drawing.Point(85, 120);
            this.uiOutputFileName.Name = "uiOutputFileName";
            this.uiOutputFileName.Size = new System.Drawing.Size(228, 20);
            this.uiOutputFileName.TabIndex = 2;
            // 
            // uiKeyField
            // 
            this.uiKeyField.Location = new System.Drawing.Point(85, 155);
            this.uiKeyField.Name = "uiKeyField";
            this.uiKeyField.Size = new System.Drawing.Size(228, 20);
            this.uiKeyField.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(336, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Open file to write";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // uiEncryptButton
            // 
            this.uiEncryptButton.Location = new System.Drawing.Point(85, 181);
            this.uiEncryptButton.Name = "uiEncryptButton";
            this.uiEncryptButton.Size = new System.Drawing.Size(75, 23);
            this.uiEncryptButton.TabIndex = 5;
            this.uiEncryptButton.Text = "Encrypt";
            this.uiEncryptButton.UseVisualStyleBackColor = true;
            this.uiEncryptButton.Click += new System.EventHandler(this.uiEncryptButton_Click);
            // 
            // uiDecryptButton
            // 
            this.uiDecryptButton.Location = new System.Drawing.Point(167, 180);
            this.uiDecryptButton.Name = "uiDecryptButton";
            this.uiDecryptButton.Size = new System.Drawing.Size(75, 23);
            this.uiDecryptButton.TabIndex = 6;
            this.uiDecryptButton.Text = "Decrypt";
            this.uiDecryptButton.UseVisualStyleBackColor = true;
            this.uiDecryptButton.Click += new System.EventHandler(this.uiDecryptButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 307);
            this.Controls.Add(this.uiDecryptButton);
            this.Controls.Add(this.uiEncryptButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.uiKeyField);
            this.Controls.Add(this.uiOutputFileName);
            this.Controls.Add(this.uiInputFileName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox uiInputFileName;
        private System.Windows.Forms.TextBox uiOutputFileName;
        private System.Windows.Forms.TextBox uiKeyField;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button uiEncryptButton;
        private System.Windows.Forms.Button uiDecryptButton;
    }
}

