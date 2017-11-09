using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DBContext
{
    [Table("VeterinaryReservations")]
    public class VeterinaryReservation
    {
        [Key,Column(Order=0)]
        public int VeterinaryId { get; set; }
        [Key, Column(Order = 1)]
        public int AnimalId { get; set; }
        [Key, Column(Order = 2)]
        public DateTime DateTime { get; set; }

        public virtual Veterinary Veterinary { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }

    }
}
