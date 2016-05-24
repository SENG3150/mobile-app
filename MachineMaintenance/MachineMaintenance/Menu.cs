using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Xamarin.Forms;

namespace MachineMaintenance
{
    public class Menu : TabbedPage
    {
        public Menu()
        {
            BackgroundColor = Color.White;
            Title = "Main Menu";
            Style = (Style)Application.Current.Resources["tabPageStyle"];

            Children.Add(new SchedulePage());
            Children.Add(new CreateNewInspection());
            Children.Add(new AddMachine());
        }
    }
}
