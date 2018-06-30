namespace VoiceRecognition
{
    partial class Jack
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.DisableVC_button = new System.Windows.Forms.Button();
            this.EnableVC_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(258, 280);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "- log -";
            // 
            // DisableVC_button
            // 
            this.DisableVC_button.Enabled = false;
            this.DisableVC_button.Location = new System.Drawing.Point(141, 298);
            this.DisableVC_button.Name = "DisableVC_button";
            this.DisableVC_button.Size = new System.Drawing.Size(129, 23);
            this.DisableVC_button.TabIndex = 1;
            this.DisableVC_button.Text = "Disable voice control";
            this.DisableVC_button.UseVisualStyleBackColor = true;
            this.DisableVC_button.Click += new System.EventHandler(this.DisableVC_button_Click);
            // 
            // EnableVC_button
            // 
            this.EnableVC_button.Location = new System.Drawing.Point(12, 298);
            this.EnableVC_button.Name = "EnableVC_button";
            this.EnableVC_button.Size = new System.Drawing.Size(123, 23);
            this.EnableVC_button.TabIndex = 2;
            this.EnableVC_button.Text = "Enable voic control";
            this.EnableVC_button.UseVisualStyleBackColor = true;
            this.EnableVC_button.Click += new System.EventHandler(this.EnableVC_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 333);
            this.Controls.Add(this.EnableVC_button);
            this.Controls.Add(this.DisableVC_button);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speech recogintion test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button DisableVC_button;
        private System.Windows.Forms.Button EnableVC_button;
    }
}

