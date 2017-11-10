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
        void SeedDataBase();

        BindingList<ViewModels.Animal> GetAllAnimals();

        BindingList<ViewModels.Environment> GetAllEnvironments();

        BindingList<ViewModels.Animal> GetAnimals(string enviroment, string type, string spieces);

        int AddOrUpdateAnimal(ViewModels.Animal animal);

        ViewModels.VeterinaryReservation AddOrUpdateVeterinaryReservation(ViewModels.VeterinaryReservation reservation);

        void RemoveAnimal(ViewModels.Animal animal);

        void RemoveVeterinaryReservation(ViewModels.VeterinaryReservation veterinaryReservation);

        BindingList<ViewModels.VeterinaryReservation> GetVeterinaryReservations(int animalId);

        BindingList<ViewModels.Medicine> GetAllMedicines();

    }
}
