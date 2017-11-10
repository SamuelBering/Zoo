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
    public partial class VeterinaryReservationsForm : Form
    {
        private int animalId;
        private IZoo zoo;

        public VeterinaryReservationsForm(int animalId, IZoo zoo)
        {
            InitializeComponent();
            this.animalId = animalId;
            this.zoo = zoo;
            LoadAllReservations();
        }

        private void LoadAllReservations()
        {
            reservationsDataGridView.DataSource = zoo.GetVeterinaryReservations(animalId);
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


                reservation.Update(zoo.AddOrUpdateVeterinaryReservation(reservation));
                dataGridView.Refresh();
                //if ((int)dataGridView[0, e.RowIndex].Value == 0)


                //if ((int)dataGridView[0, e.RowIndex].Value == 0)
                //{
                //    //if (columnName == "name" || columnName == "weight" || columnName == "spieces" ||
                //    //    columnName == "countryoforigin")
                //    //    AddNewAnimalFromNameWeightSpiecesOrCountry(dataGridView, e, columnName, newValue);
                //}
                //else
                //{
                //    if (columnName == "name" || columnName == "weight" || columnName == "spieces" ||
                //        columnName == "countryoforigin")
                //        UpdateAnimalFromNameWeightSpiecesOrCountry(dataGridView, e, columnName, newValue);

                //}
            }
        }
    }
}
