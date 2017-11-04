using System.ComponentModel;
using Zoo.DBContext;
using System.Linq;
using Zoo.DAL;
using Zoo.BL;

namespace Zoo.BL
{
    public class Zoo : IZoo
    {
        IDataAccess dataAccess;

        public Zoo(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public BindingList<ViewModels.Animal> GetAllAnimals()
        {
            return dataAccess.GetAllAnimals();
        }
    }
}
