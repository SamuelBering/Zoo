using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DBContext
{
    [Table("Veterinaries")]
    public class Veterinary
    {
        public Veterinary()
        {
            this.VeterinaryReservations = new HashSet<VeterinaryReservation>();
        }

        public int VeterinaryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VeterinaryReservation> VeterinaryReservations { get; set; }
    }
}
