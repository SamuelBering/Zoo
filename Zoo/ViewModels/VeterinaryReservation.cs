using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.ViewModels
{
    public class VeterinaryReservation
    {
        public int AnimalId { get; set; }
        public int VeterinaryId { get; set; }
        public DateTime Time { get; set; }
        public int? DiagnosisId { get; set; }
        public string Veterinary { get; set; }
        public string Diagnosis { get; set; }
        public string MedicineNames { get; set; }
        public List<Medicine> Medicines { get; set; }
    }
}
