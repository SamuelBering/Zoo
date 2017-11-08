using System.ComponentModel;
using System.Linq;
using Zoo.DBContext;

namespace Zoo.DAL
{
    public class DataAccess : IDataAccess
    {
        public BindingList<ViewModels.Animal> GetAnimals(string enviroment, string type, string spieces)
        {
            BindingList<ViewModels.Animal> animals;
            bool environmentEmpty = (enviroment == "") ? true : false,
                 typeEmpty = (type == "") ? true : false,
                 spiecesEmpty = (spieces == "") ? true : false;

            using (var db = new ZooContext())
            {
                var animalsTemp = (from a in db.Animals
                                   where (a.Environment.Name == enviroment || environmentEmpty)
                                   && (a.Type == type || typeEmpty)
                                   && (a.Spieces.Name.Contains(spieces) || spiecesEmpty)
                                   select new
                                   {
                                       Id = a.AnimalId,
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
                    string parent1 = null, parent2 = null;
                    int? parent1Id = null, parent2Id = null;

                    if (at.Parents.Count > 0)
                    {
                        parent1Id = at.Parents.ElementAt(0).AnimalId;
                        parent1 = at.Parents.ElementAt(0).Name;
                    }
                    if (at.Parents.Count > 1)
                    {
                        parent2Id = at.Parents.ElementAt(1).AnimalId;
                        parent2 = at.Parents.ElementAt(1).Name;
                    }

                    return new ViewModels.Animal
                    {
                        Id = at.Id,
                        Parent1Id = parent1Id,
                        Parent2Id = parent2Id,
                        Name = at.Name,
                        Type = at.Type,
                        Weight = at.Weight,
                        Environment = at.Environment,
                        Spieces = at.Spieces,
                        CountryOfOrigin = at.CountryOfOrigin,
                        Parent1 = parent1,
                        Parent2 = parent2
                    };
                });


                animals = new BindingList<ViewModels.Animal>(query.ToList());
            }

            return animals;
        }

        public void RemoveAnimal(ViewModels.Animal animal)
        {
            using (var db = new ZooContext())
            {
                var animalToRemove = new Animal { AnimalId = animal.Id };
                db.Animals.Attach(animalToRemove);
                db.Animals.Remove(animalToRemove);
                db.SaveChanges();
            }
        }

        public BindingList<ViewModels.Animal> GetAllAnimals()
        {
            return GetAnimals("", "", "");
        }


        public BindingList<ViewModels.Environment> GetAllEnvironments()
        {
            BindingList<ViewModels.Environment> environments;

            using (var db = new ZooContext())
            {

                var query = from e in db.Environments
                            select new ViewModels.Environment
                            {
                                Id = e.EnvironmentId,
                                Name = e.Name
                            };

                environments = new BindingList<ViewModels.Environment>(query.ToList());
            }

            return environments;
        }

        public int AddOrUpdateAnimal(ViewModels.Animal animal)
        {
            using (var db = new ZooContext())
            {
                var spieces = db.Spieces.Where(s => s.Name.ToLower() == animal.Spieces).SingleOrDefault();
                if (spieces == null && animal.Spieces != null)
                    spieces = new Spieces
                    {
                        Name = animal.Spieces
                    };

                var countryOfOrigin = db.CountriesOfOrigin.Where(c => c.Name.ToLower() == animal.CountryOfOrigin).SingleOrDefault();
                if (countryOfOrigin == null && animal.CountryOfOrigin != null)
                    countryOfOrigin = new CountryOfOrigin
                    {
                        Name = animal.CountryOfOrigin
                    };

                var environment = db.Environments.Where(e => e.Name.ToLower() == animal.Environment).SingleOrDefault();
                if (environment == null && animal.Environment != null)
                    environment = new Environment
                    {
                        Name = animal.Environment
                    };

                var animals = db.Animals.ToList();

                var parents = animals.Where(a =>
                {
                    if (animal.Parent1Id != null && animal.Parent1Id == a.AnimalId)
                        return true;
                    if (animal.Parent2Id != null && animal.Parent2Id == a.AnimalId)
                        return true;
                    return false;
                }).ToList();

                Animal newAnimal = null;

                if (animal.Id != 0)
                {
                    newAnimal = db.Animals.Where(a => a.AnimalId == animal.Id).Single();
                    if (newAnimal.Parents != null && newAnimal.Parents.Count > 0)
                    {
                        newAnimal.Parents.Clear();
                        db.SaveChanges();
                    }

                    newAnimal.Name = animal.Name;
                    newAnimal.Type = animal.Type;
                    newAnimal.Weight = animal.Weight;
                    newAnimal.Spieces = spieces;
                    newAnimal.CountryOfOrigin = countryOfOrigin;
                    newAnimal.Environment = environment;

                    newAnimal.Parents = parents.Count > 0 ? parents : null;
                }
                else
                {
                    newAnimal = new Animal();
                    newAnimal.Name = animal.Name;
                    newAnimal.Type = animal.Type;
                    newAnimal.Weight = animal.Weight;
                    newAnimal.Spieces = spieces;
                    newAnimal.CountryOfOrigin = countryOfOrigin;
                    newAnimal.Environment = environment;
                    newAnimal.Parents = parents.Count > 0 ? parents : null;
                    db.Animals.Add(newAnimal);
                }

                db.SaveChanges();
                return newAnimal.AnimalId;
            }
        }
    }
}
