namespace PdfSigner.Forms
{
    partial class SignForm
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
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnAddName = new System.Windows.Forms.Button();
            this.btnOpenPdf = new System.Windows.Forms.Button();
            this.gbxPdfOperations = new System.Windows.Forms.GroupBox();
            this.btnTelephone = new System.Windows.Forms.Button();
            this.btnAddress = new System.Windows.Forms.Button();
            this.btnCity = new System.Windows.Forms.Button();
            this.btnStateProv = new System.Windows.Forms.Button();
            this.btnZipCode = new System.Windows.Forms.Button();
            this.btnSignature = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnDateOfBirth = new System.Windows.Forms.Button();
            this.btnPassportIdCard = new System.Windows.Forms.Button();
            this.btnCountry = new System.Windows.Forms.Button();
            this.gbxPdfFields = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxPdfOperations.SuspendLayout();
            this.gbxPdfFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(6, 51);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(58, 23);
            this.btnZoomIn.TabIndex = 1;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(70, 51);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(70, 23);
            this.btnZoomOut.TabIndex = 3;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnAddName
            // 
            this.btnAddName.Location = new System.Drawing.Point(6, 19);
            this.btnAddName.Name = "btnAddName";
            this.btnAddName.Size = new System.Drawing.Size(140, 34);
            this.btnAddName.TabIndex = 4;
            this.btnAddName.Text = "Name";
            this.btnAddName.UseVisualStyleBackColor = true;
            this.btnAddName.Click += new System.EventHandler(this.AddNameBtnClick);
            // 
            // btnOpenPdf
            // 
            this.btnOpenPdf.Location = new System.Drawing.Point(6, 22);
            this.btnOpenPdf.Name = "btnOpenPdf";
            this.btnOpenPdf.Size = new System.Drawing.Size(134, 23);
            this.btnOpenPdf.TabIndex = 6;
            this.btnOpenPdf.Text = "Open PDF";
            this.btnOpenPdf.UseVisualStyleBackColor = true;
            this.btnOpenPdf.Click += new System.EventHandler(this.btnOpenPdf_Click);
            // 
            // gbxPdfOperations
            // 
            this.gbxPdfOperations.Controls.Add(this.btnZoomOut);
            this.gbxPdfOperations.Controls.Add(this.btnOpenPdf);
            this.gbxPdfOperations.Controls.Add(this.btnZoomIn);
            this.gbxPdfOperations.Location = new System.Drawing.Point(637, 17);
            this.gbxPdfOperations.Name = "gbxPdfOperations";
            this.gbxPdfOperations.Size = new System.Drawing.Size(156, 89);
            this.gbxPdfOperations.TabIndex = 7;
            this.gbxPdfOperations.TabStop = false;
            this.gbxPdfOperations.Text = "Pdf Operations";
            // 
            // btnTelephone
            // 
            this.btnTelephone.Location = new System.Drawing.Point(6, 59);
            this.btnTelephone.Name = "btnTelephone";
            this.btnTelephone.Size = new System.Drawing.Size(140, 34);
            this.btnTelephone.TabIndex = 8;
            this.btnTelephone.Text = "Telephone";
            this.btnTelephone.UseVisualStyleBackColor = true;
            this.btnTelephone.Click += new System.EventHandler(this.btnTelephone_Click);
            // 
            // btnAddress
            // 
            this.btnAddress.Location = new System.Drawing.Point(6, 99);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(140, 34);
            this.btnAddress.TabIndex = 9;
            this.btnAddress.Text = "Address";
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // btnCity
            // 
            this.btnCity.Location = new System.Drawing.Point(152, 19);
            this.btnCity.Name = "btnCity";
            this.btnCity.Size = new System.Drawing.Size(140, 34);
            this.btnCity.TabIndex = 10;
            this.btnCity.Text = "City";
            this.btnCity.UseVisualStyleBackColor = true;
            this.btnCity.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnStateProv
            // 
            this.btnStateProv.Location = new System.Drawing.Point(152, 59);
            this.btnStateProv.Name = "btnStateProv";
            this.btnStateProv.Size = new System.Drawing.Size(140, 34);
            this.btnStateProv.TabIndex = 11;
            this.btnStateProv.Text = "State/Prov";
            this.btnStateProv.UseVisualStyleBackColor = true;
            this.btnStateProv.Click += new System.EventHandler(this.btnStateProv_Click);
            // 
            // btnZipCode
            // 
            this.btnZipCode.Location = new System.Drawing.Point(152, 99);
            this.btnZipCode.Name = "btnZipCode";
            this.btnZipCode.Size = new System.Drawing.Size(140, 34);
            this.btnZipCode.TabIndex = 12;
            this.btnZipCode.Text = "Zip Code";
            this.btnZipCode.UseVisualStyleBackColor = true;
            this.btnZipCode.Click += new System.EventHandler(this.btnZipCode_Click);
            // 
            // btnSignature
            // 
            this.btnSignature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSignature.Location = new System.Drawing.Point(444, 60);
            this.btnSignature.Name = "btnSignature";
            this.btnSignature.Size = new System.Drawing.Size(140, 34);
            this.btnSignature.TabIndex = 20;
            this.btnSignature.Text = "Signature";
            this.btnSignature.UseVisualStyleBackColor = true;
            this.btnSignature.Click += new System.EventHandler(this.btnSignature_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(444, 20);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(140, 34);
            this.btnEmail.TabIndex = 21;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnDateOfBirth
            // 
            this.btnDateOfBirth.Location = new System.Drawing.Point(298, 100);
            this.btnDateOfBirth.Name = "btnDateOfBirth";
            this.btnDateOfBirth.Size = new System.Drawing.Size(140, 34);
            this.btnDateOfBirth.TabIndex = 22;
            this.btnDateOfBirth.Text = "Date of Birth";
            this.btnDateOfBirth.UseVisualStyleBackColor = true;
            this.btnDateOfBirth.Click += new System.EventHandler(this.button15_Click);
            // 
            // btnPassportIdCard
            // 
            this.btnPassportIdCard.Location = new System.Drawing.Point(298, 60);
            this.btnPassportIdCard.Name = "btnPassportIdCard";
            this.btnPassportIdCard.Size = new System.Drawing.Size(140, 34);
            this.btnPassportIdCard.TabIndex = 23;
            this.btnPassportIdCard.Text = "Passport / Id Card";
            this.btnPassportIdCard.UseVisualStyleBackColor = true;
            this.btnPassportIdCard.Click += new System.EventHandler(this.btnPassportIdCard_Click);
            // 
            // btnCountry
            // 
            this.btnCountry.Location = new System.Drawing.Point(298, 20);
            this.btnCountry.Name = "btnCountry";
            this.btnCountry.Size = new System.Drawing.Size(140, 34);
            this.btnCountry.TabIndex = 24;
            this.btnCountry.Text = "Country";
            this.btnCountry.UseVisualStyleBackColor = true;
            this.btnCountry.Click += new System.EventHandler(this.btnCountry_Click);
            // 
            // gbxPdfFields
            // 
            this.gbxPdfFields.Controls.Add(this.btnCountry);
            this.gbxPdfFields.Controls.Add(this.btnSignature);
            this.gbxPdfFields.Controls.Add(this.btnPassportIdCard);
            this.gbxPdfFields.Controls.Add(this.btnAddName);
            this.gbxPdfFields.Controls.Add(this.btnDateOfBirth);
            this.gbxPdfFields.Controls.Add(this.btnTelephone);
            this.gbxPdfFields.Controls.Add(this.btnEmail);
            this.gbxPdfFields.Controls.Add(this.btnAddress);
            this.gbxPdfFields.Controls.Add(this.btnCity);
            this.gbxPdfFields.Controls.Add(this.btnZipCode);
            this.gbxPdfFields.Controls.Add(this.btnStateProv);
            this.gbxPdfFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxPdfFields.Location = new System.Drawing.Point(12, 12);
            this.gbxPdfFields.Name = "gbxPdfFields";
            this.gbxPdfFields.Size = new System.Drawing.Size(591, 144);
            this.gbxPdfFields.TabIndex = 25;
            this.gbxPdfFields.TabStop = false;
            this.gbxPdfFields.Text = "Pdf Fields";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(637, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 42);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save PDF";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.SaveBtnClick);
            // 
            // SignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 520);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbxPdfOperations);
            this.Controls.Add(this.gbxPdfFields);
            this.Name = "SignForm";
            this.Text = "SignForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignForm_FormClosing);
            this.Load += new System.EventHandler(this.SignForm_Load);
            this.gbxPdfOperations.ResumeLayout(false);
            this.gbxPdfFields.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnAddName;
        private System.Windows.Forms.Button btnOpenPdf;
        private System.Windows.Forms.GroupBox gbxPdfOperations;
        private System.Windows.Forms.Button btnTelephone;
        private System.Windows.Forms.Button btnAddress;
        private System.Windows.Forms.Button btnCity;
        private System.Windows.Forms.Button btnStateProv;
        private System.Windows.Forms.Button btnZipCode;
        private System.Windows.Forms.Button btnSignature;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnDateOfBirth;
        private System.Windows.Forms.Button btnPassportIdCard;
        private System.Windows.Forms.Button btnCountry;
        private System.Windows.Forms.GroupBox gbxPdfFields;
        private System.Windows.Forms.Button btnSave;
    }
}