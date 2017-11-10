namespace Zoo.UI
{
    partial class veterinaryReservationsForm
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
            this.reservationsDataGridView = new System.Windows.Forms.DataGridView();
            this.removeReservationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reservationsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // reservationsDataGridView
            // 
            this.reservationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reservationsDataGridView.Location = new System.Drawing.Point(48, 120);
            this.reservationsDataGridView.Name = "reservationsDataGridView";
            this.reservationsDataGridView.RowTemplate.Height = 24;
            this.reservationsDataGridView.Size = new System.Drawing.Size(870, 297);
            this.reservationsDataGridView.TabIndex = 0;
            this.reservationsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.reservationsDataGridView_CellClick);
            this.reservationsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.reservationsDataGridView_CellEndEdit);
            // 
            // removeReservationButton
            // 
            this.removeReservationButton.Location = new System.Drawing.Point(924, 120);
            this.removeReservationButton.Name = "removeReservationButton";
            this.removeReservationButton.Size = new System.Drawing.Size(99, 56);
            this.removeReservationButton.TabIndex = 1;
            this.removeReservationButton.Text = "Delete Reservation";
            this.removeReservationButton.UseVisualStyleBackColor = true;
            this.removeReservationButton.Click += new System.EventHandler(this.removeReservationButton_Click);
            // 
            // veterinaryReservationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 488);
            this.Controls.Add(this.removeReservationButton);
            this.Controls.Add(this.reservationsDataGridView);
            this.Name = "veterinaryReservationsForm";
            this.Text = "Veterinary Reservations";
            ((System.ComponentModel.ISupportInitialize)(this.reservationsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView reservationsDataGridView;
        private System.Windows.Forms.Button removeReservationButton;
    }
}