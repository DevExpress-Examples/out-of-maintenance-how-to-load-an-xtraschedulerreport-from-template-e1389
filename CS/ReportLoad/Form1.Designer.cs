namespace ReportLoad {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnReportLoad = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnReportLoad
            // 
            this.btnReportLoad.Location = new System.Drawing.Point(70, 25);
            this.btnReportLoad.Name = "btnReportLoad";
            this.btnReportLoad.Size = new System.Drawing.Size(153, 23);
            this.btnReportLoad.TabIndex = 0;
            this.btnReportLoad.Text = "Load Report from Template";
            this.btnReportLoad.Click += new System.EventHandler(this.btnReportLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 72);
            this.Controls.Add(this.btnReportLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnReportLoad;
    }
}

