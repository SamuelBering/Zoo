using System;
using System.Windows.Forms;
using Zoo.DAL;

namespace Zoo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataAccess dataAcces = new DataAccess();
            Zoo.BL.Zoo zoo = new Zoo.BL.Zoo(dataAcces);            
            Application.Run(new ZooForm(zoo));
        }
    }
}
