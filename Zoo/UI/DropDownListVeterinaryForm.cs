using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zoo.BL;
using Zoo.ViewModels;

namespace Zoo.UI
{
    public class DropDownListVeterinaryForm : DropDownListForm
    {
        IZoo zoo;
        VeterinaryReservation veterinaryReservation;
        int previousVeterinaryId;


        public DropDownListVeterinaryForm(VeterinaryReservation veterinaryReservation, IZoo zoo) : base()
        {
            SelectedValueChangeOn = false;
            this.zoo = zoo;
            this.veterinaryReservation = veterinaryReservation;
            previousVeterinaryId = veterinaryReservation.VeterinaryId;
            this.DropDownComboBox.SelectedValueChanged += DropDownComboBox_SelectedValueChanged;
        }

        public bool SelectedValueChangeOn { get; set; }

        private void DropDownComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!SelectedValueChangeOn)
                return;

            ComboBox cb  = (ComboBox)sender;

            if (((Veterinary)cb.SelectedItem).Id != previousVeterinaryId)
            {
                VeterinaryReservation newReservation = new VeterinaryReservation
                {
                    VeterinaryId = ((Veterinary)cb.SelectedItem).Id,
                    AnimalId = this.veterinaryReservation.AnimalId,
                    Time = this.veterinaryReservation.Time
                };

                if (zoo.VeterinaryReservationExists(newReservation))
                {
                    MessageBox.Show("A reservation with this veterinary at this exact time already exists. Please choose another time or veterinary or remove the previous reservation first.", "Reservation already exists!");
                    cb.SelectedValue = this.previousVeterinaryId;
                }
                else
                    this.previousVeterinaryId = ((Veterinary)cb.SelectedItem).Id;
            }
        }
    }
}
