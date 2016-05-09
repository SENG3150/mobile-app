using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

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
