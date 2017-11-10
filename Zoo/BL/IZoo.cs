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

        ViewModels.VeterinaryReservation
                     AddOrUpdateVeterinaryReservation(ViewModels.VeterinaryReservation prevReservation,
                                                      ViewModels.VeterinaryReservation reservation);

        void RemoveAnimal(ViewModels.Animal animal);

        void RemoveVeterinaryReservation(ViewModels.VeterinaryReservation veterinaryReservation);

        BindingList<ViewModels.VeterinaryReservation> GetVeterinaryReservations(int animalId);

        BindingList<ViewModels.Medicine> GetAllMedicines();

        BindingList<ViewModels.Veterinary> GetAllVeterinaries();

    }
}
