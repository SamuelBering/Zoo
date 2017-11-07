using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL
{
    public interface IDataAccess
    {
        BindingList<ViewModels.Animal> GetAllAnimals();

        BindingList<ViewModels.Environment> GetAllEnvironments();

        BindingList<ViewModels.Animal> GetAnimals(string enviroment, string type, string spieces);

        int AddNewAnimal(ViewModels.Animal animal);

    }
}
