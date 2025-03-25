namespace BvNugetPreviewGenerator.Generate
{
    partial class GeneratedMessage
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
            this.picMainIcon = new System.Windows.Forms.PictureBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblMainText = new System.Windows.Forms.Label();
            this.txtLogOutput = new System.Windows.Forms.TextBox();
            this.txtExceptionDetails = new System.Windows.Forms.TextBox();
            this.lblLogOutput = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblExceptionDetails = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMainIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picMainIcon
            // 
            this.picMainIcon.Location = new System.Drawing.Point(12, 12);
            this.picMainIcon.Name = "picMainIcon";
            this.picMainIcon.Size = new System.Drawing.Size(50, 50);
            this.picMainIcon.TabIndex = 0;
            this.picMainIcon.TabStop = false;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(68, 9);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(336, 17);
            this.lblHeading.TabIndex = 1;
            this.lblHeading.Text = "Nuget Preview Package Created Successfully";
            // 
            // lblMainText
            // 
            this.lblMainText.Location = new System.Drawing.Point(68, 36);
            this.lblMainText.Name = "lblMainText";
            this.lblMainText.Size = new System.Drawing.Size(402, 33);
            this.lblMainText.TabIndex = 2;
            this.lblMainText.Text = "lblMainText";
            // 
            // txtLogOutput
            // 
            this.txtLogOutput.Location = new System.Drawing.Point(12, 94);
            this.txtLogOutput.Multiline = true;
            this.txtLogOutput.Name = "txtLogOutput";
            this.txtLogOutput.ReadOnly = true;
            this.txtLogOutput.Size = new System.Drawing.Size(508, 86);
            this.txtLogOutput.TabIndex = 3;
            this.txtLogOutput.WordWrap = false;
            // 
            // txtExceptionDetails
            // 
            this.txtExceptionDetails.Location = new System.Drawing.Point(12, 211);
            this.txtExceptionDetails.Multiline = true;
            this.txtExceptionDetails.Name = "txtExceptionDetails";
            this.txtExceptionDetails.ReadOnly = true;
            this.txtExceptionDetails.Size = new System.Drawing.Size(508, 86);
            this.txtExceptionDetails.TabIndex = 4;
            this.txtExceptionDetails.WordWrap = false;
            // 
            // lblLogOutput
            // 
            this.lblLogOutput.AutoSize = true;
            this.lblLogOutput.Location = new System.Drawing.Point(13, 73);
            this.lblLogOutput.Name = "lblLogOutput";
            this.lblLogOutput.Size = new System.Drawing.Size(60, 13);
            this.lblLogOutput.TabIndex = 5;
            this.lblLogOutput.Text = "Log Output";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(216, 308);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(109, 27);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblExceptionDetails
            // 
            this.lblExceptionDetails.AutoSize = true;
            this.lblExceptionDetails.Location = new System.Drawing.Point(13, 190);
            this.lblExceptionDetails.Name = "lblExceptionDetails";
            this.lblExceptionDetails.Size = new System.Drawing.Size(89, 13);
            this.lblExceptionDetails.TabIndex = 7;
            this.lblExceptionDetails.Text = "Exception Details";
            // 
            // GeneratedMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 347);
            this.ControlBox = false;
            this.Controls.Add(this.lblExceptionDetails);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblLogOutput);
            this.Controls.Add(this.txtExceptionDetails);
            this.Controls.Add(this.txtLogOutput);
            this.Controls.Add(this.lblMainText);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.picMainIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneratedMessage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Generate Preview Nuget Package";
            ((System.ComponentModel.ISupportInitialize)(this.picMainIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMainIcon;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblMainText;
        private System.Windows.Forms.TextBox txtLogOutput;
        private System.Windows.Forms.TextBox txtExceptionDetails;
        private System.Windows.Forms.Label lblLogOutput;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblExceptionDetails;
    }
}