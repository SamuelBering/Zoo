using System.ComponentModel;


namespace Zoo.BL
{
    public interface IZoo
    {
        BindingList<ViewModels.Animal> GetAllAnimals();

        BindingList<ViewModels.Environment> GetAllEnvironments();

        BindingList<ViewModels.Animal> GetAnimals(string enviroment, string type, string spieces);

        int AddNewAnimal(ViewModels.Animal animal);

    }
}
