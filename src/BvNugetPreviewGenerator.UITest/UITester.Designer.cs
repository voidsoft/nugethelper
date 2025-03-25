namespace BvNugetPreviewGenerator.UITest
{
    partial class UITester
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
            this.btnSuccessResult = new System.Windows.Forms.Button();
            this.btnFail = new System.Windows.Forms.Button();
            this.btnExpectedFailureResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSuccessResult
            // 
            this.btnSuccessResult.Location = new System.Drawing.Point(13, 13);
            this.btnSuccessResult.Name = "btnSuccessResult";
            this.btnSuccessResult.Size = new System.Drawing.Size(160, 23);
            this.btnSuccessResult.TabIndex = 0;
            this.btnSuccessResult.Text = "Success Result";
            this.btnSuccessResult.UseVisualStyleBackColor = true;
            this.btnSuccessResult.Click += new System.EventHandler(this.btnSuccessResult_Click);
            // 
            // btnFail
            // 
            this.btnFail.Location = new System.Drawing.Point(13, 42);
            this.btnFail.Name = "btnFail";
            this.btnFail.Size = new System.Drawing.Size(160, 23);
            this.btnFail.TabIndex = 1;
            this.btnFail.Text = "Failure Result";
            this.btnFail.UseVisualStyleBackColor = true;
            this.btnFail.Click += new System.EventHandler(this.btnFail_Click);
            // 
            // btnExpectedFailureResult
            // 
            this.btnExpectedFailureResult.Location = new System.Drawing.Point(12, 71);
            this.btnExpectedFailureResult.Name = "btnExpectedFailureResult";
            this.btnExpectedFailureResult.Size = new System.Drawing.Size(160, 23);
            this.btnExpectedFailureResult.TabIndex = 2;
            this.btnExpectedFailureResult.Text = "Expected Failure Result";
            this.btnExpectedFailureResult.UseVisualStyleBackColor = true;
            this.btnExpectedFailureResult.Click += new System.EventHandler(this.btnExpectedFailureResult_Click);
            // 
            // UITester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExpectedFailureResult);
            this.Controls.Add(this.btnFail);
            this.Controls.Add(this.btnSuccessResult);
            this.Name = "UITester";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSuccessResult;
        private System.Windows.Forms.Button btnFail;
        private System.Windows.Forms.Button btnExpectedFailureResult;
    }
}

