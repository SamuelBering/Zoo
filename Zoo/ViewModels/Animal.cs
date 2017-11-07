using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.ViewModels
{
    public class Animal
    {
        public int Id { get; set; }
        public int? Parent1Id { get; set; }
        public int? Parent2Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
        public string Environment { get; set; }
        public string Spieces { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Parent1 { get; set; }
        public string Parent2 { get; set; }
    }
}
