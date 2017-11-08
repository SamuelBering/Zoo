using System.ComponentModel;
using Zoo.DBContext;
using System.Linq;
using Zoo.DAL;
using Zoo.BL;
using Zoo.ViewModels;

namespace Zoo.BL
{
    public class Zoo : IZoo
    {
        IDataAccess dataAccess;

        public Zoo(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public int AddOrUpdateAnimal(ViewModels.Animal animal)
        {
            return dataAccess.AddOrUpdateAnimal(animal);
        }

        public BindingList<ViewModels.Animal> GetAllAnimals()
        {
            return dataAccess.GetAllAnimals();
        }

        public BindingList<ViewModels.Environment> GetAllEnvironments()
        {
            var environments = dataAccess.GetAllEnvironments();
            environments.Insert(0, new ViewModels.Environment { Id = -1, Name = "" });
            return environments;
        }


        public BindingList<ViewModels.Animal> GetAnimals(string enviroment, string type, string spieces)
        {
            return dataAccess.GetAnimals(enviroment, type, spieces);
        }

    }
}
