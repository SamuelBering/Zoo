using System.ComponentModel;
using System.Linq;
using Zoo.DBContext;

namespace Zoo.DAL
{
    public class DataAccess:IDataAccess
    {
        public BindingList<ViewModels.Animal> GetAllAnimals()
        {
            BindingList<ViewModels.Animal> animals;

            using (var db = new ZooContext())
            {
                var query = from a in db.Animals
                            select new ViewModels.Animal
                            {
                                Name = a.Name,
                                Type = a.Type,
                                Weight = a.Weight,
                                Environment = a.Environment.Name,
                                Spieces = a.Spieces.Name,
                                CountryOfOrigin = a.CountryOfOrigin.Name,
                                Parents = a.Parents.Count == 1 ? a.Parents.FirstOrDefault().Name : null
                            };
                animals = new BindingList<ViewModels.Animal>(query.ToList());
            }

            return animals;
        }
    }
}
