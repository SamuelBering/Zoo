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
            this.resulutDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.resulutDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // resulutDataGridView
            // 
            this.resulutDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resulutDataGridView.Location = new System.Drawing.Point(104, 95);
            this.resulutDataGridView.Name = "resulutDataGridView";
            this.resulutDataGridView.RowTemplate.Height = 24;
            this.resulutDataGridView.Size = new System.Drawing.Size(804, 262);
            this.resulutDataGridView.TabIndex = 0;
            // 
            // ZooForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 468);
            this.Controls.Add(this.resulutDataGridView);
            this.Name = "ZooForm";
            this.Text = "Zoo";
            ((System.ComponentModel.ISupportInitialize)(this.resulutDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resulutDataGridView;
    }
}

