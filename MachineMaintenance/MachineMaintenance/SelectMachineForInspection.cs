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
    public class SelectMachineForInspection : ContentPage  
    {
        List<ObjectModel.Machine> machines;
        List<String> machineNames;
        //need to access machines from device
        public SelectMachineForInspection()
        {
            Title = "Inspect Machine";
            BackgroundColor = Color.White;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    new Label()
                    {
                        Text = "This is where we inspect downloaded machines!"
                    },
                }
            };
        }
    }
}
