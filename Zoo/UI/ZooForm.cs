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
            //TestAddAnimalsToDB();
            LoadAllAnimals();
        }

        private void LoadAllAnimals()
        {


            resulutDataGridView.DataSource = zoo.GetAllAnimals();
        }

        private void TestAddAnimalsToDB()
        {
            using (var context = new ZooContext())
            {
                //var benny = (from e in context.Animals
                //             where e.Name == "Benny"
                //             select e).SingleOrDefault();

                var benjamin = (from e in context.Animals
                                where e.Name == "Benjamin"
                                select e).SingleOrDefault();
                var kickan = (from e in context.Animals
                                where e.Name == "Kickan"
                                select e).SingleOrDefault();

                kickan.Parents.Add(benjamin);

                //Animal elephant2 = new Animal
                //{
                //    Name = "Kickan",
                //    Type = "växtätare",
                //    Weight = 1888,
                //    CountryOfOrigin = benny.CountryOfOrigin,
                //    Environment = benny.Environment,
                //    Spieces = benny.Spieces,
                //    Parents = benny.Parents
                //};



                //context.Animals.AddOrUpdate(a => a.Name, elephant2);

                context.SaveChanges();

            }
        }

    }
}
