using System;
using System.Windows.Forms;
using Zoo.BL;
//using Zoo.DBContext;
using System.Linq;
using System.Collections.Generic;
using Zoo.ViewModels;
//using System.Data.Entity.Migrations;


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
            resultDataGridView.DataSource = zoo.GetAllAnimals();
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
            resultDataGridView.DataSource = zoo.GetAnimals(environment, type, spieces);
        }

        private void resultDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var newValue = resultDataGridView[e.ColumnIndex, e.RowIndex].Value;
            var columnName = resultDataGridView.Columns[e.ColumnIndex].HeaderText.ToLower();

            if ((int)resultDataGridView[0, e.RowIndex].Value == 0)
            {
                Animal animal = null;

                switch (columnName)
                {
                    case "name":
                        animal = new Animal
                        {
                            Name = (string)newValue
                        };
                        resultDataGridView[0, e.RowIndex].Value = zoo.AddNewAnimal(animal);
                        break;

                    case "weight":
                        animal = new Animal
                        {
                            Name = "Ny",
                            Weight = (int)newValue
                        };
                        zoo.AddNewAnimal(animal);
                        break;
                    case "spieces":
                        animal = new Animal
                        {
                            Name = "Ny",
                            Spieces = (string)newValue
                        };
                        zoo.AddNewAnimal(animal);
                        break;
                    case "countryoforigin":
                        animal = new Animal
                        {
                            Name = "Ny",
                            CountryOfOrigin = (string)newValue
                        };
                        zoo.AddNewAnimal(animal);
                        break;
                }
            }
        }

        //private void resulutDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    /*  OM current row är större än rowcount
        //     *     skapa en viewmodel.animal av aktuell row
        //     *     call AddNewAnimal(viewAnimal)
        //     *     
        //     *  
        //    */

        //   
        //}

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
