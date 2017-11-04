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
    }
}
