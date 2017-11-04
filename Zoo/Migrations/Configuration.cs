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
                Weight=2700,
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
                Weight = 1600,
                CountryOfOrigin = benny.CountryOfOrigin,
                Environment = benny.Environment,
                Spieces = benny.Spieces,
                Parents = new List<Animal> { benny }
            };


            context.Animals.AddOrUpdate(a => a.Name, elephant2);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
