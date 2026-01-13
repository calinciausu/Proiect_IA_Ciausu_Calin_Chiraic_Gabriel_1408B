namespace BayesianNetwork
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.lblQueryNode = new System.Windows.Forms.Label();
            this.cmbQueryNode = new System.Windows.Forms.ComboBox();
            this.lblEvidence = new System.Windows.Forms.Label();
            this.dgvEvidence = new System.Windows.Forms.DataGridView();
            this.colNodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEvidenceState = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.txtResults = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblLoadedFile = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEvidence)).BeginInit();
            this.grpResults.SuspendLayout();
            this.SuspendLayout();

            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(12, 12);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(150, 30);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Load Network File...";
            this.btnLoadFile.UseVisualStyleBackColor = true;

            // 
            // lblLoadedFile
            // 
            this.lblLoadedFile.AutoSize = true;
            this.lblLoadedFile.Location = new System.Drawing.Point(170, 20);
            this.lblLoadedFile.Name = "lblLoadedFile";
            this.lblLoadedFile.Size = new System.Drawing.Size(86, 15);
            this.lblLoadedFile.TabIndex = 6;
            this.lblLoadedFile.Text = "No file loaded.";

            // 
            // lblQueryNode
            // 
            this.lblQueryNode.AutoSize = true;
            this.lblQueryNode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQueryNode.Location = new System.Drawing.Point(12, 60);
            this.lblQueryNode.Name = "lblQueryNode";
            this.lblQueryNode.Size = new System.Drawing.Size(113, 15);
            this.lblQueryNode.TabIndex = 1;
            this.lblQueryNode.Text = "1. Select Query Node:";

            // 
            // cmbQueryNode
            // 
            this.cmbQueryNode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueryNode.FormattingEnabled = true;
            this.cmbQueryNode.Location = new System.Drawing.Point(12, 80);
            this.cmbQueryNode.Name = "cmbQueryNode";
            this.cmbQueryNode.Size = new System.Drawing.Size(250, 23);
            this.cmbQueryNode.TabIndex = 2;

            // 
            // lblEvidence
            // 
            this.lblEvidence.AutoSize = true;
            this.lblEvidence.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEvidence.Location = new System.Drawing.Point(12, 120);
            this.lblEvidence.Name = "lblEvidence";
            this.lblEvidence.Size = new System.Drawing.Size(95, 15);
            this.lblEvidence.TabIndex = 3;
            this.lblEvidence.Text = "2. Set Evidence:";

            // 
            // dgvEvidence
            // 
            this.dgvEvidence.AllowUserToAddRows = false;
            this.dgvEvidence.AllowUserToDeleteRows = false;
            this.dgvEvidence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvidence.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNodeName,
            this.colEvidenceState});
            this.dgvEvidence.Location = new System.Drawing.Point(12, 140);
            this.dgvEvidence.Name = "dgvEvidence";
            this.dgvEvidence.RowHeadersVisible = false;
            this.dgvEvidence.RowTemplate.Height = 25;
            this.dgvEvidence.Size = new System.Drawing.Size(350, 290);
            this.dgvEvidence.TabIndex = 4;

            // 
            // colNodeName
            // 
            this.colNodeName.HeaderText = "Node Name";
            this.colNodeName.Name = "colNodeName";
            this.colNodeName.ReadOnly = true;
            this.colNodeName.Width = 150;

            // 
            // colEvidenceState
            // 
            this.colEvidenceState.HeaderText = "Value (State)";
            this.colEvidenceState.Items.AddRange(new object[] {
            "Unknown",
            "True",
            "False"});
            this.colEvidenceState.Name = "colEvidenceState";
            this.colEvidenceState.Width = 150;

            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCalculate.Location = new System.Drawing.Point(380, 80);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(400, 40);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "Calculate Probability";
            this.btnCalculate.UseVisualStyleBackColor = true;

            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.txtResults);
            this.grpResults.Location = new System.Drawing.Point(380, 140);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(400, 290);
            this.grpResults.TabIndex = 6;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";

            // 
            // txtResults
            // 
            this.txtResults.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResults.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtResults.Location = new System.Drawing.Point(3, 19);
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.Size = new System.Drawing.Size(394, 268);
            this.txtResults.TabIndex = 0;
            this.txtResults.Text = "";

            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblLoadedFile);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.dgvEvidence);
            this.Controls.Add(this.lblEvidence);
            this.Controls.Add(this.cmbQueryNode);
            this.Controls.Add(this.lblQueryNode);
            this.Controls.Add(this.btnLoadFile);
            this.Name = "Form1";
            this.Text = "Bayesian Inference Engine";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvidence)).EndInit();
            this.grpResults.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Label lblQueryNode;
        private System.Windows.Forms.ComboBox cmbQueryNode;
        private System.Windows.Forms.Label lblEvidence;
        private System.Windows.Forms.DataGridView dgvEvidence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNodeName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEvidenceState;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.RichTextBox txtResults;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblLoadedFile;
    }
}