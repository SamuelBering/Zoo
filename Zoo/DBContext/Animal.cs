﻿using System;
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
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}