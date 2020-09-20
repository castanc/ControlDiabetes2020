namespace DiabetesControl
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
            this.btnLoadResumen = new System.Windows.Forms.Button();
            this.btnSplitData = new System.Windows.Forms.Button();
            this.btnLoadGlucoseData = new System.Windows.Forms.Button();
            this.btnLoadCesarRegs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txFileName = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadResumen
            // 
            this.btnLoadResumen.Enabled = false;
            this.btnLoadResumen.Location = new System.Drawing.Point(113, 72);
            this.btnLoadResumen.Name = "btnLoadResumen";
            this.btnLoadResumen.Size = new System.Drawing.Size(143, 23);
            this.btnLoadResumen.TabIndex = 0;
            this.btnLoadResumen.Text = "Load Resumen";
            this.btnLoadResumen.UseVisualStyleBackColor = true;
            // 
            // btnSplitData
            // 
            this.btnSplitData.Location = new System.Drawing.Point(113, 183);
            this.btnSplitData.Name = "btnSplitData";
            this.btnSplitData.Size = new System.Drawing.Size(143, 23);
            this.btnSplitData.TabIndex = 1;
            this.btnSplitData.Text = "Split Data";
            this.btnSplitData.UseVisualStyleBackColor = true;
            this.btnSplitData.Click += new System.EventHandler(this.btnSplitData_Click);
            // 
            // btnLoadGlucoseData
            // 
            this.btnLoadGlucoseData.Location = new System.Drawing.Point(113, 130);
            this.btnLoadGlucoseData.Name = "btnLoadGlucoseData";
            this.btnLoadGlucoseData.Size = new System.Drawing.Size(143, 23);
            this.btnLoadGlucoseData.TabIndex = 2;
            this.btnLoadGlucoseData.Text = "Load Glucose Data";
            this.btnLoadGlucoseData.UseVisualStyleBackColor = true;
            this.btnLoadGlucoseData.Click += new System.EventHandler(this.btnLoadGlucoseData_Click);
            // 
            // btnLoadCesarRegs
            // 
            this.btnLoadCesarRegs.Location = new System.Drawing.Point(113, 101);
            this.btnLoadCesarRegs.Name = "btnLoadCesarRegs";
            this.btnLoadCesarRegs.Size = new System.Drawing.Size(143, 23);
            this.btnLoadCesarRegs.TabIndex = 3;
            this.btnLoadCesarRegs.Text = "Load CesarRegs";
            this.btnLoadCesarRegs.UseVisualStyleBackColor = true;
            this.btnLoadCesarRegs.Click += new System.EventHandler(this.btnLoadCesarRegs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source File:";
            // 
            // txFileName
            // 
            this.txFileName.Location = new System.Drawing.Point(113, 29);
            this.txFileName.Name = "txFileName";
            this.txFileName.Size = new System.Drawing.Size(500, 20);
            this.txFileName.TabIndex = 5;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(619, 29);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(80, 23);
            this.btnSelectFile.TabIndex = 6;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadCesarRegs);
            this.Controls.Add(this.btnLoadGlucoseData);
            this.Controls.Add(this.btnSplitData);
            this.Controls.Add(this.btnLoadResumen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadResumen;
        private System.Windows.Forms.Button btnSplitData;
        private System.Windows.Forms.Button btnLoadGlucoseData;
        private System.Windows.Forms.Button btnLoadCesarRegs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txFileName;
        private System.Windows.Forms.Button btnSelectFile;
    }
}

