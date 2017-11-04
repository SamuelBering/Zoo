using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DBContext
{
    [Table("Animals")]
    public class Animal
    {
        public Animal()
        {
            this.Parents = new HashSet<Animal>();
        }

        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
        public virtual Spieces Spieces { get; set; }
        public virtual CountryOfOrigin CountryOfOrigin { get; set; }
        public virtual Environment Environment { get; set; }

        public virtual ICollection<Animal> Parents { get; set; }

    }
}
