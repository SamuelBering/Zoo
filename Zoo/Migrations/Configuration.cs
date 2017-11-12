namespace Zoo.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Zoo.DBContext;

    internal sealed class Configuration : DbMigrationsConfiguration<Zoo.DBContext.ZooContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Zoo.DBContext.ZooContext context)
        {

            Animal elephant1 = new Animal
            {
                Name = "Benny",
                Type = "växtätare",
                Weight = 2700,
                CountryOfOrigin = new CountryOfOrigin
                {
                    Name = "Sydafrika"
                },
                Environment = new Zoo.DBContext.Environment
                {
                    Name = "mark"
                },
                Spieces = new Spieces
                {
                    Name = "elefant"
                }
            };


            context.Animals.AddOrUpdate(a => a.Name, elephant1);
            context.SaveChanges();

            var benny = (from e in context.Animals
                         where e.Name == "Benny"
                         select e).SingleOrDefault();


            Animal elephant2 = new Animal
            {
                Name = "Kickan",
                Type = "växtätare",
                Weight = 1666,
                CountryOfOrigin = benny.CountryOfOrigin,
                Environment = benny.Environment,
                Spieces = benny.Spieces,
            };

            context.Animals.AddOrUpdate(a => a.Name, elephant2);
            context.SaveChanges();

            var kickan = (from e in context.Animals
                          where e.Name == "Kickan"
                          select e).SingleOrDefault();


            Animal elephant3 = new Animal
            {
                Name = "Benjamin",
                Type = "växtätare",
                Weight = 3100,
                CountryOfOrigin = benny.CountryOfOrigin,
                Environment = benny.Environment,
                Spieces = benny.Spieces,
            };

            context.Animals.AddOrUpdate(a => a.Name, elephant3);
            context.SaveChanges();

            var benjamin = (from e in context.Animals
                            where e.Name == "Benjamin"
                            select e).SingleOrDefault();


            kickan.Parents.Add(benny);
            kickan.Parents.Add(benjamin);

            context.Environments.AddOrUpdate(e => e.Name,
                new DBContext.Environment { Name = "träd" },
                new DBContext.Environment { Name = "vatten" }
                );

            context.Veterinaries.AddOrUpdate(v => v.Name,
                new DBContext.Veterinary
                {
                    Name = "Rochi Ardulla",
                },
                 new DBContext.Veterinary
                 {
                     Name = "Henrik Claesson",
                 },
                  new DBContext.Veterinary
                  {
                      Name = "Fredrik Jönsson",
                  },
                   new DBContext.Veterinary
                   {
                       Name = "Sophia Everlin",
                   },
                    new DBContext.Veterinary
                    {
                        Name = "Göran Martinsson",
                    },
                     new DBContext.Veterinary
                     {
                         Name = "Maxime Lennestig",
                     }
            );


            context.Medicines.AddOrUpdate(m => m.Name,
                new DBContext.Medicine
                {
                    Name = "Alvedon",
                },
                new DBContext.Medicine
                {
                    Name = "Penicillin",
                },
                new DBContext.Medicine
                {
                    Name = "Microlax",
                },
                new DBContext.Medicine
                {
                    Name = "Klorhexidin",
                },
                new DBContext.Medicine
                {
                    Name = "Fästingspray",
                },
                new DBContext.Medicine
                {
                    Name = "Tassalva",
                }
                );

            context.SaveChanges();


            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data.
        }
    }
}
