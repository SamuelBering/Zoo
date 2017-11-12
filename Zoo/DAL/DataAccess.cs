using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Zoo.DBContext;

namespace Zoo.DAL
{
    public class DataAccess : IDataAccess
    {
        //Just for testing purposes
        public void SeedDataBase()
        {
            using (var db = new ZooContext())
            {
                var animal = db.Animals.Where(a => a.Name.Contains("Samuel")).Single();


                animal.VeterinaryReservations = new List<VeterinaryReservation>
                {

                    new VeterinaryReservation
                    {
                        Animal=animal,

                        Veterinary=new Veterinary
                        {
                            Name="Henrik Claesson"
                        },

                        DateTime=new DateTime(2017,12,01),

                        Diagnosis=new Diagnosis
                        {
                            Description="Utslag och prickar, sannolikt vattkoppor",
                            Medicines=new List<Medicine>
                            {
                                new Medicine
                                {
                                    Name="Alvedon",
                                },
                                new Medicine
                                {
                                    Name="Penicillin"
                                }
                            },
                        }

                    }
                };

                db.SaveChanges();
            }
        }

        public BindingList<ViewModels.VeterinaryReservation> GetVeterinaryReservations(int animalId)
        {
            BindingList<ViewModels.VeterinaryReservation> reservations;

            using (var db = new ZooContext())
            {
                var reservationsTemp = (from r in db.VeterinaryReservations
                                        where r.AnimalId == animalId
                                        select new
                                        {
                                            VeterinaryReservation = new ViewModels.VeterinaryReservation
                                            {
                                                AnimalId = r.AnimalId,
                                                VeterinaryId = r.VeterinaryId,
                                                DiagnosisId = r.Diagnosis.DiagnosisId,
                                                Time = r.DateTime,
                                                Veterinary = r.Veterinary.Name,
                                                Diagnosis = r.Diagnosis.Description
                                            },

                                            Medicines = r.Diagnosis.Medicines
                                        }).ToList();

                var query = reservationsTemp.Select(r =>
                {
                    List<ViewModels.Medicine> medicines = r.Medicines.
                        Select(m => new ViewModels.Medicine { Id = m.MedicineId, Name = m.Name, }).ToList();
                    ViewModels.VeterinaryReservation veterinaryReservation = r.VeterinaryReservation;
                    veterinaryReservation.Medicines = medicines;
                    veterinaryReservation.MedicineNames =
                        string.Join(", ", medicines.Select(m => m.Name).ToList());
                    return veterinaryReservation;
                });

                reservations = new BindingList<ViewModels.VeterinaryReservation>(query.ToList());

            }

            return reservations;
        }

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

        public void RemoveVeterinaryReservation(ViewModels.VeterinaryReservation veterinaryReservation)
        {
            using (var db = new ZooContext())
            {
                var reservationToRemove =
                    new VeterinaryReservation
                    {
                        AnimalId = veterinaryReservation.AnimalId,
                        VeterinaryId = veterinaryReservation.VeterinaryId,
                        DateTime = veterinaryReservation.Time
                    };
                db.VeterinaryReservations.Attach(reservationToRemove);
                db.VeterinaryReservations.Remove(reservationToRemove);
                db.SaveChanges();

                if (veterinaryReservation.DiagnosisId != null)
                {
                    var diagnosisToRemove =
                        new Diagnosis { DiagnosisId = veterinaryReservation.DiagnosisId.Value };
                    db.Diagnoses.Attach(diagnosisToRemove);
                    db.Diagnoses.Remove(diagnosisToRemove);
                    db.SaveChanges();
                }
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

        public BindingList<ViewModels.Medicine> GetAllMedicines()
        {
            BindingList<ViewModels.Medicine> medicines;

            using (var db = new ZooContext())
            {

                var query = from m in db.Medicines
                            select new ViewModels.Medicine
                            {
                                Id = m.MedicineId,
                                Name = m.Name
                            };

                medicines = new BindingList<ViewModels.Medicine>(query.ToList());
            }

            return medicines;
        }


        public bool VeterinaryReservationExists(ViewModels.VeterinaryReservation reservationViewModel)
        {
            using (var db = new ZooContext())
            {
                VeterinaryReservation veterinaryReservation = db.VeterinaryReservations
                      .SingleOrDefault(r => r.AnimalId == reservationViewModel.AnimalId
                      && r.VeterinaryId == reservationViewModel.VeterinaryId
                      && r.DateTime == reservationViewModel.Time);

                if (veterinaryReservation != null)
                    return true;
                else
                    return false;
            }
        }

        public BindingList<ViewModels.Veterinary> GetAllVeterinaries()
        {
            BindingList<ViewModels.Veterinary> veterinaries;

            using (var db = new ZooContext())
            {

                var query = from v in db.Veterinaries
                            select new ViewModels.Veterinary
                            {
                                Id = v.VeterinaryId,
                                Name = v.Name
                            };

                veterinaries = new BindingList<ViewModels.Veterinary>(query.ToList());
            }

            return veterinaries;
        }

        public ViewModels.VeterinaryReservation
                     AddOrUpdateVeterinaryReservation(ViewModels.VeterinaryReservation prevReservation,
                                                      ViewModels.VeterinaryReservation reservation)
        {
            using (var db = new ZooContext())
            {
                var animal = db.Animals.Where(a => a.AnimalId == reservation.AnimalId).Single();

                var diagnosis = db.Diagnoses.Where(d => d.DiagnosisId == reservation.DiagnosisId).SingleOrDefault();
                if (diagnosis == null)
                {
                    if (reservation.Diagnosis != null)
                    {
                        diagnosis = new Diagnosis
                        {
                            Description = reservation.Diagnosis,
                        };
                    }
                }
                else
                {
                    diagnosis.Description = reservation.Diagnosis;
                }

                var veterinary = db.Veterinaries.Where
                    (v => v.VeterinaryId == reservation.VeterinaryId).SingleOrDefault();
                if (veterinary == null)
                    veterinary = new Veterinary
                    {
                        Name = reservation.Veterinary,
                    };


                List<Medicine> medicines = new List<Medicine>();
                if (reservation.Medicines != null)
                    foreach (ViewModels.Medicine medicine in reservation.Medicines)
                    {
                        var newMedicine = db.Medicines.Where(m => m.MedicineId == medicine.Id).SingleOrDefault();

                        if (newMedicine != null)
                            medicines.Add(newMedicine);
                    }


                if (diagnosis != null && diagnosis.Medicines != null && diagnosis.Medicines.Count > 0)
                {
                    diagnosis.Medicines.Clear();
                    db.SaveChanges();
                }

                if (diagnosis != null && medicines.Count > 0)
                    diagnosis.Medicines = medicines;


                var veterinaryReservation = db.VeterinaryReservations
                    .Where(r => r.VeterinaryId == prevReservation.VeterinaryId
                                && r.AnimalId == prevReservation.AnimalId
                                && r.DateTime == prevReservation.Time).SingleOrDefault();

                if (veterinaryReservation != null)
                {
                    db.VeterinaryReservations.Remove(veterinaryReservation);
                    db.SaveChanges();
                    veterinaryReservation = null;
                }

                veterinaryReservation = new VeterinaryReservation
                {
                    Veterinary = veterinary,
                    Animal = animal,
                    DateTime = reservation.Time,
                    Diagnosis = diagnosis,
                };

                db.VeterinaryReservations.Add(veterinaryReservation);

                db.SaveChanges();

                List<ViewModels.Medicine> viewMedicines = null;

                var viewReservation = new ViewModels.VeterinaryReservation
                {
                    AnimalId = veterinaryReservation.AnimalId,
                    VeterinaryId = veterinaryReservation.VeterinaryId,
                    Time = veterinaryReservation.DateTime,
                    Veterinary = veterinaryReservation.Veterinary.Name,
                };

                if (veterinaryReservation.Diagnosis != null)
                {
                    viewMedicines = veterinaryReservation.Diagnosis.Medicines.
                         Select(m => new ViewModels.Medicine { Id = m.MedicineId, Name = m.Name, }).ToList();


                    viewReservation.Medicines = viewMedicines;
                    viewReservation.MedicineNames = string.Join(", ", viewMedicines.Select(m => m.Name).ToList());


                    viewReservation.DiagnosisId = veterinaryReservation.Diagnosis.DiagnosisId;
                    viewReservation.Diagnosis = veterinaryReservation.Diagnosis.Description;
                }

                return viewReservation;
            }
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
                    environment = new DBContext.Environment
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
