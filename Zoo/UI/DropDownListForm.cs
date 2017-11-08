using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo.UI
{
    public partial class DropDownListForm : Form
    {
        public DropDownListForm()
        {
            InitializeComponent();
        }

        public ComboBox DropDownComboBox
        {
            get
            {
                return this.dropDownComboBox;
            }

            set
            {
                this.dropDownComboBox = value;
            }
            
        }

    }
}
