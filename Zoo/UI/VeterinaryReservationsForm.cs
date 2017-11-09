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
    }
}
