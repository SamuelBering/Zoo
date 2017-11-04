using System.ComponentModel;


namespace Zoo.BL
{
    public interface IZoo
    {
        BindingList<ViewModels.Animal> GetAllAnimals();
    }
}
