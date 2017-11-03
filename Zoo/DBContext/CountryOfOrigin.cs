using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DBContext
{
    [Table("CountriesOfOrigin")]
    public class CountryOfOrigin
    {
        public int CountryOfOriginId { get; set; }


    }
}
