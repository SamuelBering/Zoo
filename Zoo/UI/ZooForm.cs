using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zoo.BL;

namespace Zoo
{
    public partial class ZooForm : Form
    {
        IZoo zoo;

        public ZooForm(IZoo zoo)
        {
            this.zoo = zoo;
            InitializeComponent();
            LoadAllAnimals();
        }

        private void LoadAllAnimals()
        {
            resulutDataGridView.DataSource = zoo.GetAllAnimals();
        }
    }
}
