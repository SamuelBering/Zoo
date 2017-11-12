using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.ViewModels
{
    public class VeterinaryReservation
    {
        [Browsable(false)]
        public int AnimalId { get; set; }
        [Browsable(false)]
        public int VeterinaryId { get; set; }

        [ReadOnly(true)]
        public DateTime Time { get; set; }

        [Browsable(false)]
        public int? DiagnosisId { get; set; }

        [ReadOnly(true)]
        public string Veterinary { get; set; }

        public string Diagnosis { get; set; }

        [DisplayName("Medicines")]
        [ReadOnly(true)]
        public string MedicineNames { get; set; }

        [Browsable(false)]
        public List<Medicine> Medicines { get; set; }

        public void Update(VeterinaryReservation r)
        {
            this.AnimalId = r.AnimalId;
            this.VeterinaryId = r.VeterinaryId;
            this.Time = r.Time;
            this.DiagnosisId = r.DiagnosisId;
            this.Veterinary = r.Veterinary;
            this.Diagnosis = r.Diagnosis;
            this.MedicineNames = r.MedicineNames;
            this.Medicines = r.Medicines;
        }
    }
}
