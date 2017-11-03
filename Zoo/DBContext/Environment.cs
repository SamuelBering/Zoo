using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DBContext
{
    [Table("Environments")]
    public class Environment
    {
        public int EnvironmentId { get; set; }

    }
}
