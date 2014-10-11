namespace GUI
{
    partial class FrmBusca
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
            this.txtCardName = new System.Windows.Forms.TextBox();
            this.lblCardName = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.lstEditions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtCardName
            // 
            this.txtCardName.Location = new System.Drawing.Point(15, 25);
            this.txtCardName.Name = "txtCardName";
            this.txtCardName.Size = new System.Drawing.Size(226, 20);
            this.txtCardName.TabIndex = 0;
            // 
            // lblCardName
            // 
            this.lblCardName.AutoSize = true;
            this.lblCardName.Location = new System.Drawing.Point(12, 9);
            this.lblCardName.Name = "lblCardName";
            this.lblCardName.Size = new System.Drawing.Size(80, 13);
            this.lblCardName.TabIndex = 1;
            this.lblCardName.Text = "Nome da carta:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(247, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(15, 82);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(226, 186);
            this.lstResults.TabIndex = 3;
            this.lstResults.SelectedIndexChanged += new System.EventHandler(this.lstResults_SelectedIndexChanged);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 66);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(63, 13);
            this.lblResults.TabIndex = 4;
            this.lblResults.Text = "Resultados:";
            // 
            // lstEditions
            // 
            this.lstEditions.FormattingEnabled = true;
            this.lstEditions.Location = new System.Drawing.Point(247, 82);
            this.lstEditions.Name = "lstEditions";
            this.lstEditions.Size = new System.Drawing.Size(226, 186);
            this.lstEditions.TabIndex = 5;
            // 
            // FrmBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 289);
            this.Controls.Add(this.lstEditions);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblCardName);
            this.Controls.Add(this.txtCardName);
            this.MaximizeBox = false;
            this.Name = "FrmBusca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCardName;
        private System.Windows.Forms.Label lblCardName;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.ListBox lstEditions;
    }
}