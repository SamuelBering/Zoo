using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DBContext
{
    [Table("Diagnoses")]
    public class Diagnosis
    {
        public Diagnosis()
        {
            this.VeterinaryReservations = new HashSet<VeterinaryReservation>();
        }

        public int DiagnosisId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<VeterinaryReservation> VeterinaryReservations { get; set; }
    }
}
