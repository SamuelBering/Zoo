using System.ComponentModel;


namespace Zoo.BL
{
    public interface IZoo
    {
        void SeedDataBase();

        BindingList<ViewModels.Animal> GetAllAnimals();

        BindingList<ViewModels.Environment> GetAllEnvironments();

        BindingList<ViewModels.Animal> GetAnimals(string enviroment, string type, string spieces);

        int AddOrUpdateAnimal(ViewModels.Animal animal);

        void AddOrUpdateVeterinaryReservation(ViewModels.VeterinaryReservation reservation);

        void RemoveAnimal(ViewModels.Animal animal);

        BindingList<ViewModels.VeterinaryReservation> GetVeterinaryReservations(int animalId);

    }
}
