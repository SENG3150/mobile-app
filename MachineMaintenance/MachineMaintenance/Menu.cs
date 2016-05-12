using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MachineMaintenance
{
    public class Menu : TabbedPage
    {
        public Menu()
        {
            BackgroundColor = Color.White;
            Title = "Main Menu";

            Children.Add(new AddMachine());
            Children.Add(new SchedulePage());
            Children.Add(new SelectMachineForInspection());
        }
    }
}
