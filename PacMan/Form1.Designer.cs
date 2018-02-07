namespace PacMan
{
    partial class Pacman
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
            this.commandLabel = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.RichTextBox();
            this.fileBrowse = new System.Windows.Forms.Button();
            this.inputTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // commandLabel
            // 
            this.commandLabel.AutoSize = true;
            this.commandLabel.Location = new System.Drawing.Point(12, 9);
            this.commandLabel.Name = "commandLabel";
            this.commandLabel.Size = new System.Drawing.Size(133, 13);
            this.commandLabel.TabIndex = 0;
            this.commandLabel.Text = "Please select an input file :";
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(12, 60);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(43, 13);
            this.result.TabIndex = 2;
            this.result.Text = "Result :";
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 87);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(389, 189);
            this.output.TabIndex = 4;
            this.output.Text = "";
            // 
            // fileBrowse
            // 
            this.fileBrowse.Location = new System.Drawing.Point(326, 28);
            this.fileBrowse.Name = "fileBrowse";
            this.fileBrowse.Size = new System.Drawing.Size(75, 23);
            this.fileBrowse.TabIndex = 5;
            this.fileBrowse.Text = "Browse";
            this.fileBrowse.UseVisualStyleBackColor = true;
            this.fileBrowse.Click += new System.EventHandler(this.fileBrowse_Click);
            // 
            // inputTextbox
            // 
            this.inputTextbox.Location = new System.Drawing.Point(12, 28);
            this.inputTextbox.Name = "inputTextbox";
            this.inputTextbox.ReadOnly = true;
            this.inputTextbox.Size = new System.Drawing.Size(308, 20);
            this.inputTextbox.TabIndex = 6;
            // 
            // Pacman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 306);
            this.Controls.Add(this.inputTextbox);
            this.Controls.Add(this.fileBrowse);
            this.Controls.Add(this.output);
            this.Controls.Add(this.result);
            this.Controls.Add(this.commandLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Pacman";
            this.Text = "Pacman";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label commandLabel;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button fileBrowse;
        private System.Windows.Forms.TextBox inputTextbox;
    }
}

