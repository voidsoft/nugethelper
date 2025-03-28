namespace BvNugetPreviewGenerator.Generate
{
    partial class GenerateForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.flpLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.picMainIcon = new System.Windows.Forms.PictureBox();
            this.lblMainText = new System.Windows.Forms.Label();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblProgressUpdate = new System.Windows.Forms.Label();
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.lblLogOutput = new System.Windows.Forms.Label();
            this.txtLogOutput = new System.Windows.Forms.TextBox();
            this.flpLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMainIcon)).BeginInit();
            this.pnlProgress.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(263, 283);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(109, 27);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // flpLayout
            // 
            this.flpLayout.AutoSize = true;
            this.flpLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpLayout.Controls.Add(this.panel1);
            this.flpLayout.Controls.Add(this.pnlProgress);
            this.flpLayout.Controls.Add(this.pnlLog);
            this.flpLayout.Controls.Add(this.btnOk);
            this.flpLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpLayout.Location = new System.Drawing.Point(0, 0);
            this.flpLayout.Name = "flpLayout";
            this.flpLayout.Size = new System.Drawing.Size(636, 313);
            this.flpLayout.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblHeading);
            this.panel1.Controls.Add(this.picMainIcon);
            this.panel1.Controls.Add(this.lblMainText);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 84);
            this.panel1.TabIndex = 10;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(73, 16);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(336, 17);
            this.lblHeading.TabIndex = 1;
            this.lblHeading.Text = "Nuget Preview Package Created Successfully";
            // 
            // picMainIcon
            // 
            this.picMainIcon.BackColor = System.Drawing.Color.Transparent;
            this.picMainIcon.Image = global::BvNugetPreviewGenerator.Properties.Resources.windowicon32;
            this.picMainIcon.Location = new System.Drawing.Point(20, 16);
            this.picMainIcon.Name = "picMainIcon";
            this.picMainIcon.Size = new System.Drawing.Size(34, 34);
            this.picMainIcon.TabIndex = 0;
            this.picMainIcon.TabStop = false;
            // 
            // lblMainText
            // 
            this.lblMainText.Location = new System.Drawing.Point(73, 33);
            this.lblMainText.Name = "lblMainText";
            this.lblMainText.Size = new System.Drawing.Size(402, 33);
            this.lblMainText.TabIndex = 2;
            this.lblMainText.Text = "lblMainText";
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.lblProgressUpdate);
            this.pnlProgress.Controls.Add(this.prgProgress);
            this.pnlProgress.Location = new System.Drawing.Point(3, 93);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(630, 60);
            this.pnlProgress.TabIndex = 14;
            // 
            // lblProgressUpdate
            // 
            this.lblProgressUpdate.AutoSize = true;
            this.lblProgressUpdate.Location = new System.Drawing.Point(10, 39);
            this.lblProgressUpdate.Name = "lblProgressUpdate";
            this.lblProgressUpdate.Size = new System.Drawing.Size(0, 13);
            this.lblProgressUpdate.TabIndex = 14;
            // 
            // prgProgress
            // 
            this.prgProgress.Location = new System.Drawing.Point(12, 13);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(598, 20);
            this.prgProgress.TabIndex = 13;
            // 
            // pnlLog
            // 
            this.pnlLog.Controls.Add(this.lblLogOutput);
            this.pnlLog.Controls.Add(this.txtLogOutput);
            this.pnlLog.Location = new System.Drawing.Point(3, 159);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(630, 118);
            this.pnlLog.TabIndex = 11;
            // 
            // lblLogOutput
            // 
            this.lblLogOutput.AutoSize = true;
            this.lblLogOutput.Location = new System.Drawing.Point(9, 10);
            this.lblLogOutput.Name = "lblLogOutput";
            this.lblLogOutput.Size = new System.Drawing.Size(60, 13);
            this.lblLogOutput.TabIndex = 5;
            this.lblLogOutput.Text = "Log Output";
            // 
            // txtLogOutput
            // 
            this.txtLogOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogOutput.Location = new System.Drawing.Point(12, 26);
            this.txtLogOutput.Multiline = true;
            this.txtLogOutput.Name = "txtLogOutput";
            this.txtLogOutput.ReadOnly = true;
            this.txtLogOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogOutput.Size = new System.Drawing.Size(610, 78);
            this.txtLogOutput.TabIndex = 3;
            this.txtLogOutput.WordWrap = false;
            // 
            // GenerateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(637, 319);
            this.ControlBox = false;
            this.Controls.Add(this.flpLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GenerateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Generate Preview Nuget Package";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GenerateForm_FormClosing);
            this.flpLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMainIcon)).EndInit();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.FlowLayoutPanel flpLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.PictureBox picMainIcon;
        private System.Windows.Forms.Label lblMainText;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Label lblLogOutput;
        private System.Windows.Forms.TextBox txtLogOutput;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar prgProgress;
        private System.Windows.Forms.Label lblProgressUpdate;
    }
}