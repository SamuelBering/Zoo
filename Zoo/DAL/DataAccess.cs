using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Zoo.DBContext;
using Zoo.ViewModels;

namespace Zoo.DAL
{
    public class DataAccess : IDataAccess
    {
        public BindingList<ViewModels.Animal> GetAllAnimals()
        {
            BindingList<ViewModels.Animal> animals;

            using (var db = new ZooContext())
            {

                var animalsTemp = (from a in db.Animals
                                   select new
                                   {
                                       Name = a.Name,
                                       Type = a.Type,
                                       Weight = a.Weight,
                                       Environment = a.Environment.Name,
                                       Spieces = a.Spieces.Name,
                                       CountryOfOrigin = a.CountryOfOrigin.Name,
                                       Parents = a.Parents
                                   }).ToList();

                var query = animalsTemp.Select(at =>
                 {
                     string parents = string.Join(",", at.Parents.Select(p => p.Name));

                     return new ViewModels.Animal
                     {
                         Name = at.Name,
                         Type = at.Type,
                         Weight = at.Weight,
                         Environment = at.Environment,
                         Spieces = at.Spieces,
                         CountryOfOrigin = at.CountryOfOrigin,
                         Parents = parents
                     };
                 });


                animals = new BindingList<ViewModels.Animal>(query.ToList());
            }

            return animals;
        }

        public BindingList<ViewModels.Environment> GetAllEnvironments()
        {
            BindingList<ViewModels.Environment> environments;

            using (var db = new ZooContext())
            {

                var query = from e in db.Environments
                            select new ViewModels.Environment
                            {
                                Id=e.EnvironmentId,
                                Name=e.Name
                            };

                environments = new BindingList<ViewModels.Environment>(query.ToList());
            }

            return environments;
        }
    }
}
