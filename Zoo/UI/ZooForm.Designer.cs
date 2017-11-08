namespace Zoo
{
    partial class ZooForm
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
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.environmentComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.spiecesTextBox = new System.Windows.Forms.TextBox();
            this.environmentLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.spiecesLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.deleteRowButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Location = new System.Drawing.Point(104, 95);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.RowTemplate.Height = 24;
            this.resultDataGridView.Size = new System.Drawing.Size(804, 262);
            this.resultDataGridView.TabIndex = 0;
            this.resultDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultDataGridView_CellClick);
            this.resultDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultDataGridView_CellEndEdit);
            // 
            // environmentComboBox
            // 
            this.environmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.environmentComboBox.FormattingEnabled = true;
            this.environmentComboBox.Location = new System.Drawing.Point(104, 50);
            this.environmentComboBox.Name = "environmentComboBox";
            this.environmentComboBox.Size = new System.Drawing.Size(194, 24);
            this.environmentComboBox.TabIndex = 1;
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "",
            "köttätare",
            "växtätare"});
            this.typeComboBox.Location = new System.Drawing.Point(330, 50);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(164, 24);
            this.typeComboBox.TabIndex = 2;
            // 
            // spiecesTextBox
            // 
            this.spiecesTextBox.Location = new System.Drawing.Point(519, 52);
            this.spiecesTextBox.Name = "spiecesTextBox";
            this.spiecesTextBox.Size = new System.Drawing.Size(180, 22);
            this.spiecesTextBox.TabIndex = 3;
            // 
            // environmentLabel
            // 
            this.environmentLabel.AutoSize = true;
            this.environmentLabel.Location = new System.Drawing.Point(101, 27);
            this.environmentLabel.Name = "environmentLabel";
            this.environmentLabel.Size = new System.Drawing.Size(79, 17);
            this.environmentLabel.TabIndex = 4;
            this.environmentLabel.Text = "Enviroment";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(327, 27);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(40, 17);
            this.typeLabel.TabIndex = 5;
            this.typeLabel.Text = "Type";
            // 
            // spiecesLabel
            // 
            this.spiecesLabel.AutoSize = true;
            this.spiecesLabel.Location = new System.Drawing.Point(516, 27);
            this.spiecesLabel.Name = "spiecesLabel";
            this.spiecesLabel.Size = new System.Drawing.Size(58, 17);
            this.spiecesLabel.TabIndex = 6;
            this.spiecesLabel.Text = "Spieces";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(769, 44);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(139, 39);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.Location = new System.Drawing.Point(914, 95);
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(102, 43);
            this.deleteRowButton.TabIndex = 8;
            this.deleteRowButton.Text = "Delete row";
            this.deleteRowButton.UseVisualStyleBackColor = true;
            this.deleteRowButton.Click += new System.EventHandler(this.deleteRowButton_Click);
            // 
            // ZooForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 468);
            this.Controls.Add(this.deleteRowButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.spiecesLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.environmentLabel);
            this.Controls.Add(this.spiecesTextBox);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.environmentComboBox);
            this.Controls.Add(this.resultDataGridView);
            this.Name = "ZooForm";
            this.Text = "Zoo";
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.ComboBox environmentComboBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.TextBox spiecesTextBox;
        private System.Windows.Forms.Label environmentLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label spiecesLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button deleteRowButton;
    }
}

