﻿using System;
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
    public partial class ListBoxForm : Form
    {
        public ListBoxForm()
        {
            InitializeComponent();
        }

        public ListBox ListBox
        {
           get
            {
                return this.multipleListBox;
            }
        }

        private void ListBoxForm_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(Cursor.Position.X - this.Size.Width / 2,
                Cursor.Position.Y - this.Size.Height / 2);
        }
    }
}
