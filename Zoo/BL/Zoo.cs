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

        public void SeedDataBase()
        {
            this.dataAccess.SeedDataBase();
        }

        public int AddOrUpdateAnimal(ViewModels.Animal animal)
        {
            return dataAccess.AddOrUpdateAnimal(animal);
        }

        public ViewModels.VeterinaryReservation
                     AddOrUpdateVeterinaryReservation(ViewModels.VeterinaryReservation prevReservation,
                                                      ViewModels.VeterinaryReservation reservation)
        {
            return dataAccess.AddOrUpdateVeterinaryReservation(prevReservation, reservation);

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

        public void RemoveAnimal(ViewModels.Animal animal)
        {
            dataAccess.RemoveAnimal(animal);
        }

        public void RemoveVeterinaryReservation(ViewModels.VeterinaryReservation veterinaryReservation)
        {
            dataAccess.RemoveVeterinaryReservation(veterinaryReservation);
        }

        public BindingList<ViewModels.VeterinaryReservation> GetVeterinaryReservations(int animalId)
        {
            return dataAccess.GetVeterinaryReservations(animalId);
        }

        public BindingList<ViewModels.Medicine> GetAllMedicines()
        {
            return dataAccess.GetAllMedicines();
        }

        public BindingList<ViewModels.Veterinary> GetAllVeterinaries()
        {
            return dataAccess.GetAllVeterinaries();
        }

        public bool VeterinaryReservationExists(ViewModels.VeterinaryReservation reservationViewModel)
        {
            return dataAccess.VeterinaryReservationExists(reservationViewModel);
        }

    }
}
