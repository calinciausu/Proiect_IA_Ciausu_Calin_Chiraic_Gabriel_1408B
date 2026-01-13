using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BayesianInference; 

namespace BayesianNetwork
{
    public partial class Form1 : Form
    {
        private BayesianInference.BayesianNet bn;

        public Form1()
        {
            InitializeComponent();
            bn = new BayesianInference.BayesianNet();

            this.btnLoadFile.Click += new EventHandler(this.btnLoadFile_Click);
            this.btnCalculate.Click += new EventHandler(this.btnCalculate_Click);

            this.cmbQueryNode.SelectedIndexChanged += new EventHandler(this.cmbQueryNode_SelectedIndexChanged);
        }
        private void cmbQueryNode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQueryNode.SelectedItem == null) return;

            string selectedQueryNode = cmbQueryNode.SelectedItem.ToString();

            foreach (DataGridViewRow row in dgvEvidence.Rows)
            {
                string rowNodeName = row.Cells["colNodeName"].Value.ToString();

                var cell = row.Cells["colEvidenceState"];

                if (rowNodeName == selectedQueryNode)
                {
                    cell.Value = "Unknown";

                    cell.ReadOnly = true;

                    cell.Style.BackColor = System.Drawing.Color.LightGray;
                    cell.Style.ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    cell.ReadOnly = false;
                    cell.Style.BackColor = System.Drawing.Color.White;
                    cell.Style.ForeColor = System.Drawing.Color.Black;
                }
            }
        }



        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName;
                    bn.LoadFromFile(filePath);

                    lblLoadedFile.Text = $"Loaded: {System.IO.Path.GetFileName(filePath)}";

                    cmbQueryNode.Items.Clear();
                    foreach (var node in bn.VariableNames)
                    {
                        cmbQueryNode.Items.Add(node);
                    }
                    if (cmbQueryNode.Items.Count > 0) cmbQueryNode.SelectedIndex = 0;

                    dgvEvidence.Rows.Clear();
                    foreach (var node in bn.VariableNames)
                    {
                        int rowId = dgvEvidence.Rows.Add();
                        DataGridViewRow row = dgvEvidence.Rows[rowId];
                        row.Cells["colNodeName"].Value = node;
                        row.Cells["colEvidenceState"].Value = "Unknown"; // Default
                    }

                    if (cmbQueryNode.Items.Count > 0)
                    {
                        cmbQueryNode.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (bn.Nodes.Count == 0)
            {
                MessageBox.Show("Please load a network file first.");
                return;
            }

            string queryVar = cmbQueryNode.SelectedItem.ToString();
            var evidence = new Dictionary<string, bool>();

            foreach (DataGridViewRow row in dgvEvidence.Rows)
            {
                string nodeName = row.Cells["colNodeName"].Value.ToString();
                string state = row.Cells["colEvidenceState"].Value?.ToString();

                if (nodeName == queryVar) continue;

                if (state == "True") evidence[nodeName] = true;
                else if (state == "False") evidence[nodeName] = false;
            }

            try
            {
                double[] result = BayesianNet.EnumerationAsk(queryVar, evidence, bn);

                txtResults.Text = $"Query: P({queryVar} | Evidence)\n";
                txtResults.Text += "---------------------------------\n";
                txtResults.Text += $"TRUE  (Yes): {result[0]:P4}\n";
                txtResults.Text += $"FALSE (No) : {result[1]:P4}\n";
            }
            catch (Exception ex)
            {
                txtResults.Text = $"Error during calculation: {ex.Message}";
            }
        }
    }
}
