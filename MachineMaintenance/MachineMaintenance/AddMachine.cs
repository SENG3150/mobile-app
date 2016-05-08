using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MachineMaintenance
{
    public class AddMachine : ContentPage
    {
        //download machine and store it on device
        public AddMachine()
        {
            Title = "Add Machine";
            BackgroundColor = Color.White;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    new Label()
                    {
                        Text = "This is where we add a machine!"
                    }
                }
            };
        }
    }
}
