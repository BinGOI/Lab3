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
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(167, 393);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Decrypt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(85, 393);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Encrypt";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(336, 294);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(127, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Open file to write";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 332);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 20);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(85, 297);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(228, 20);
            this.textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(85, 260);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(228, 20);
            this.textBox3.TabIndex = 8;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(336, 260);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(127, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Open file to read";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "RSA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "RC5";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(85, 367);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(228, 20);
            this.textBox4.TabIndex = 16;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(336, 329);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(127, 23);
            this.button7.TabIndex = 17;
            this.button7.Text = "Open public key";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(336, 365);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(127, 23);
            this.button8.TabIndex = 18;
            this.button8.Text = "Open private key";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(494, 314);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(127, 23);
            this.button9.TabIndex = 19;
            this.button9.Text = "Generate keys";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(500, 180);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(121, 20);
            this.textBox5.TabIndex = 20;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(500, 393);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(121, 20);
            this.textBox6.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 490);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.uiDecryptButton);
            this.Controls.Add(this.uiEncryptButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.uiKeyField);
            this.Controls.Add(this.uiOutputFileName);
            this.Controls.Add(this.uiInputFileName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
    }
}

