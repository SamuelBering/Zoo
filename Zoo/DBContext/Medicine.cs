using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DBContext
{
    [Table("Medicines")]
    public class Medicine
    {
        public Medicine()
        {
            this.Diagnoses = new HashSet<Diagnosis>();
        }

        public int MedicineId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Diagnosis> Diagnoses { get; set; }

    }
}
