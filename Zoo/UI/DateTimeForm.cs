using System;
using System.Windows.Forms;
using Zoo.BL;
using Zoo.ViewModels;

namespace Zoo.UI
{
    public partial class DateTimeForm : Form
    {
        VeterinaryReservation veterinaryReservation;
        IZoo zoo;
        DateTime previousDateTime;

        public bool DateTimePickerValueChanged { get; set; }

        public DateTimeForm(VeterinaryReservation veterinaryReservation, IZoo zoo)
        {
            InitializeComponent();
            this.DateTimePickerValueChanged = false;
            this.veterinaryReservation = veterinaryReservation;
            this.zoo = zoo;

            this.previousDateTime = new DateTime
                (veterinaryReservation.Time.Year,
                veterinaryReservation.Time.Month,
                veterinaryReservation.Time.Day,
                veterinaryReservation.Time.Hour,
                veterinaryReservation.Time.Minute,
                0
                );

            this.dateTimePicker.Value = this.previousDateTime;
        }

        public DateTimePicker DateTimePicker
        {
            get
            {
                return this.dateTimePicker;
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dp = (DateTimePicker)sender;

            if (dp.Value != previousDateTime)
            {
                VeterinaryReservation newReservation = new VeterinaryReservation
                {
                    VeterinaryId = this.veterinaryReservation.VeterinaryId,
                    AnimalId = this.veterinaryReservation.AnimalId,
                    Time = dp.Value
                };

                if (zoo.VeterinaryReservationExists(newReservation))
                {
                    MessageBox.Show("A reservation with this date and time already exists. Please choose another date and time or remove the previous reservation first.", "Reservation already exists!");
                    dp.Value = this.previousDateTime;
                }
                else
                {
                    this.previousDateTime = dp.Value;
                    DateTimePickerValueChanged = true;
                }
            }

        }

        private void DateTimeForm_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(Cursor.Position.X - this.Size.Width / 2,
                Cursor.Position.Y - this.Size.Height / 2);
        }
    }
}
