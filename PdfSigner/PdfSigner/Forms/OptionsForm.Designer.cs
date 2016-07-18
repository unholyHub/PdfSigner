namespace PdfSigner
{
    partial class OptionsForm
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
            this.btnTextFileLocation = new System.Windows.Forms.Button();
            this.txtTextFileLocation = new System.Windows.Forms.TextBox();
            this.btnOkay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPdfFileNameFormat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTextFileLocation
            // 
            this.btnTextFileLocation.Location = new System.Drawing.Point(432, 19);
            this.btnTextFileLocation.Name = "btnTextFileLocation";
            this.btnTextFileLocation.Size = new System.Drawing.Size(75, 23);
            this.btnTextFileLocation.TabIndex = 0;
            this.btnTextFileLocation.Text = "Browse";
            this.btnTextFileLocation.UseVisualStyleBackColor = true;
            this.btnTextFileLocation.Click += new System.EventHandler(this.btnTextFileLocation_Click);
            // 
            // txtTextFileLocation
            // 
            this.txtTextFileLocation.Location = new System.Drawing.Point(12, 21);
            this.txtTextFileLocation.Name = "txtTextFileLocation";
            this.txtTextFileLocation.Size = new System.Drawing.Size(414, 20);
            this.txtTextFileLocation.TabIndex = 1;
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(483, 75);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 2;
            this.btnOkay.Text = "OK";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Guest TXT file location";
            // 
            // txtPdfFileNameFormat
            // 
            this.txtPdfFileNameFormat.Location = new System.Drawing.Point(13, 75);
            this.txtPdfFileNameFormat.Name = "txtPdfFileNameFormat";
            this.txtPdfFileNameFormat.Size = new System.Drawing.Size(201, 20);
            this.txtPdfFileNameFormat.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pdf Filename format";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 110);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPdfFileNameFormat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.txtTextFileLocation);
            this.Controls.Add(this.btnTextFileLocation);
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.Shown += new System.EventHandler(this.OptionsForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTextFileLocation;
        private System.Windows.Forms.TextBox txtTextFileLocation;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPdfFileNameFormat;
        private System.Windows.Forms.Label label2;
    }
}