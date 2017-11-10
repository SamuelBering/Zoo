using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zoo.BL;
using Zoo.ViewModels;

namespace Zoo.UI
{
    public partial class veterinaryReservationsForm : Form
    {
        private int animalId;
        private IZoo zoo;

        public veterinaryReservationsForm(int animalId, IZoo zoo)
        {
            InitializeComponent();
            this.animalId = animalId;
            this.zoo = zoo;
            LoadAllReservations();
        }

        private void InitializeReservationsDataGridColumns()
        {
            //reservationsDataGridView.Columns["Type"].ReadOnly = true;
            //resultDataGridView.Columns["Environment"].ReadOnly = true;
            //resultDataGridView.Columns["Parent1"].ReadOnly = true;
            //resultDataGridView.Columns["Parent2"].ReadOnly = true;
            ////resultDataGridView.Columns["Id"].Visible = false;
            //resultDataGridView.Columns["Parent1Id"].Visible = false;
            //resultDataGridView.Columns["Parent2Id"].Visible = false;
        }

        private void LoadAllReservations()
        {
            reservationsDataGridView.DataSource = zoo.GetVeterinaryReservations(animalId);
            InitializeReservationsDataGridColumns();
        }

        private void reservationsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            var newValue = dataGridView[e.ColumnIndex, e.RowIndex].Value;
            var columnName = dataGridView.Columns[e.ColumnIndex].HeaderText.ToLower();

            VeterinaryReservation reservation =
                (VeterinaryReservation)dataGridView.Rows[e.RowIndex].DataBoundItem;

            if (columnName == "diagnosis" && reservation != null)
            {

                if (reservation.AnimalId == 0)
                {
                    reservation.AnimalId = this.animalId;
                    reservation.VeterinaryId = 1;
                    reservation.Time = DateTime.Now;
                }


                reservation.Update(zoo.AddOrUpdateVeterinaryReservation(reservation, reservation));
                dataGridView.Refresh();
                
            }
        }

        private void removeReservationButton_Click(object sender, EventArgs e)
        {
            if (reservationsDataGridView.SelectedRows.Count > 0)
            {
                for (int i = 0; i < reservationsDataGridView.Rows.Count; i++)
                {
                    if (reservationsDataGridView.Rows[i].Selected)
                    {

                        VeterinaryReservation reservation =
                            (VeterinaryReservation)reservationsDataGridView.Rows[i].DataBoundItem;
                        if (reservation != null)
                            zoo.RemoveVeterinaryReservation(reservation);

                    }
                }
                LoadAllReservations();
            }
        }

        private void GetMedicinesAndUpdateReservation(DataGridView dataGridView, DataGridViewCellEventArgs e,
                                                      VeterinaryReservation reservation)
        {
            ListBoxForm listBoxForm = new ListBoxForm();

            listBoxForm.ListBox.DataSource = zoo.GetAllMedicines();
            listBoxForm.ListBox.DisplayMember = "Name";
            listBoxForm.ListBox.ValueMember = "Id";

            for (int i = 0; i < listBoxForm.ListBox.Items.Count; i++)
            {
                var item = listBoxForm.ListBox.Items[i];
                if (reservation.Medicines != null && reservation.Medicines.Exists(m => m.Id == ((Medicine)item).Id))
                    listBoxForm.ListBox.SetSelected(i, true);
                else
                    listBoxForm.ListBox.SetSelected(i, false);
            }

            if (listBoxForm.ShowDialog(this) == DialogResult.OK)
            {
                reservation.Medicines = new List<Medicine>();

                if (reservation.Diagnosis == null)
                    reservation.Diagnosis = "(Ny diagnos)";

                foreach (Medicine m in listBoxForm.ListBox.SelectedItems)
                {
                    reservation.Medicines.Add(m);
                }
            }

            listBoxForm.Dispose();
        }


        private void GetVeterinaryAndUpdateReservation(DataGridView dataGridView, DataGridViewCellEventArgs e,
                                         VeterinaryReservation reservation)
        {
            DropDownListForm dropDownListForm = new DropDownListForm();

            dropDownListForm.DropDownComboBox.DataSource = zoo.GetAllVeterinaries();
            dropDownListForm.DropDownComboBox.DisplayMember = "Name";
            dropDownListForm.DropDownComboBox.ValueMember = "Id";

            dropDownListForm.DropDownComboBox.SelectedValue = reservation.VeterinaryId;

            //dropDownListForm.DropDownComboBox.Text = (string)dataGridView[e.ColumnIndex, e.RowIndex].Value;
            if (dropDownListForm.ShowDialog(this) == DialogResult.OK)
            {
                Veterinary selectedVeterinary =
                    (Veterinary)dropDownListForm.DropDownComboBox.SelectedItem;

                reservation.Veterinary = selectedVeterinary.Name;
                reservation.VeterinaryId = selectedVeterinary.Id;
            }

            dropDownListForm.Dispose();
        }

        private void reservationsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            DataGridView dataGridView = (DataGridView)sender;

            var columnName = dataGridView.Columns[e.ColumnIndex].HeaderText.ToLower();

            if (columnName == "time" || columnName == "veterinary" ||
                columnName == "medicines")
            {
                if (e.RowIndex == dataGridView.Rows.Count - 1)
                {

                    BindingList<VeterinaryReservation> reservations =
                        (BindingList<VeterinaryReservation>)dataGridView.DataSource;

                    dataGridView.DataSource = null;
                    reservations.Add(new VeterinaryReservation
                    {
                        AnimalId = this.animalId,
                        VeterinaryId = 1,
                        Time = DateTime.Now
                    });

                    dataGridView.DataSource = reservations;
                    InitializeReservationsDataGridColumns();

                    dataGridView.ClearSelection();
                    dataGridView[e.ColumnIndex, e.RowIndex].Selected = true;
                }

                VeterinaryReservation previousReservation = new VeterinaryReservation();
                
                VeterinaryReservation reservation =
                    (VeterinaryReservation)dataGridView.Rows[e.RowIndex].DataBoundItem;

                previousReservation.Update(reservation);

                if (columnName == "medicines")
                    GetMedicinesAndUpdateReservation(dataGridView, e, reservation);
                else if (columnName == "veterinary")
                    GetVeterinaryAndUpdateReservation(dataGridView, e, reservation);

                reservation.Update(zoo.AddOrUpdateVeterinaryReservation(previousReservation, reservation));
                dataGridView.Refresh();
                //LoadAllReservations();
            }
        }
    }
}
