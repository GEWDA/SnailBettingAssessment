namespace SnailBettingAssessment
{
    partial class Form2
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
            this.bntStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSnails = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxBetters = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bntStart
            // 
            this.bntStart.Font = new System.Drawing.Font("DrippyPlums", 9.749999F, System.Drawing.FontStyle.Bold);
            this.bntStart.Location = new System.Drawing.Point(71, 86);
            this.bntStart.Name = "bntStart";
            this.bntStart.Size = new System.Drawing.Size(75, 23);
            this.bntStart.TabIndex = 0;
            this.bntStart.Text = "Start";
            this.bntStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("DrippyPlums", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Snails";
            // 
            // cbxSnails
            // 
            this.cbxSnails.FormattingEnabled = true;
            this.cbxSnails.Location = new System.Drawing.Point(81, 9);
            this.cbxSnails.Name = "cbxSnails";
            this.cbxSnails.Size = new System.Drawing.Size(121, 21);
            this.cbxSnails.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("DrippyPlums", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Betters";
            // 
            // cbxBetters
            // 
            this.cbxBetters.FormattingEnabled = true;
            this.cbxBetters.Location = new System.Drawing.Point(81, 59);
            this.cbxBetters.Name = "cbxBetters";
            this.cbxBetters.Size = new System.Drawing.Size(121, 21);
            this.cbxBetters.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 115);
            this.Controls.Add(this.cbxBetters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxSnails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bntStart);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSnails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxBetters;
    }
}