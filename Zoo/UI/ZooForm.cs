using System;
using System.Windows.Forms;
using Zoo.BL;
using Zoo.DBContext;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Migrations;


namespace Zoo
{
    public partial class ZooForm : Form
    {
        IZoo zoo;

        public ZooForm(IZoo zoo)
        {
            this.zoo = zoo;
            InitializeComponent();
            LoadAllEnvironments();
            LoadAllAnimals();
        }

        private void LoadAllAnimals()
        {
            resulutDataGridView.DataSource = zoo.GetAllAnimals();
        }

        private void LoadAllEnvironments()
        {
            environmentComboBox.DataSource = zoo.GetAllEnvironments();
            environmentComboBox.DisplayMember = "Name";
            environmentComboBox.ValueMember = "Name";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string environment = (string)environmentComboBox.SelectedValue;
            string type = typeComboBox.Text;
            string spieces = spiecesTextBox.Text;
            resulutDataGridView.DataSource = zoo.GetAnimals(environment, type, spieces);
        }

        //private void TestAddAnimalsToDB()
        //{
        //    using (var context = new ZooContext())
        //    {
        //        //var benny = (from e in context.Animals
        //        //             where e.Name == "Benny"
        //        //             select e).SingleOrDefault();

        //        var benjamin = (from e in context.Animals
        //                        where e.Name == "Benjamin"
        //                        select e).SingleOrDefault();
        //        var kickan = (from e in context.Animals
        //                        where e.Name == "Kickan"
        //                        select e).SingleOrDefault();

        //        kickan.Parents.Add(benjamin);

        //        //Animal elephant2 = new Animal
        //        //{
        //        //    Name = "Kickan",
        //        //    Type = "växtätare",
        //        //    Weight = 1888,
        //        //    CountryOfOrigin = benny.CountryOfOrigin,
        //        //    Environment = benny.Environment,
        //        //    Spieces = benny.Spieces,
        //        //    Parents = benny.Parents
        //        //};



        //        //context.Animals.AddOrUpdate(a => a.Name, elephant2);

        //        context.SaveChanges();

        //    }
        //}

    }
}
