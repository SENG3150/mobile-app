﻿using System;
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
        List<ObjectModel.Machine> machines;
        List<String> machineNames;

        public AddMachine()
        {
            Title = "Add Machine";
            BackgroundColor = Color.White;

            getMachines();
        }

        private async void getMachines()
        {
            await viewMachines();
            machineNames = new List<String>();
            foreach (ObjectModel.Machine m in machines)
            {
                if (m != null /*&& machines isn't on device already*/)
                {
                    machineNames.Add(m.id.ToString() + "\n" + m.model.name);
                }
            }

            var machineList = new ListView();
            machineList.Header = "Add a Machine to Device";
            machineList.ItemsSource = machineNames;

            machineList.IsPullToRefreshEnabled = true;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    machineList
                }
            };
        }

        private async Task viewMachines()
        {
            try
            {
                using (var c = new HttpClient())
                {
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9zZW5nMzE1MC53aW5nbWFud2ViZGVzaWduLmNvbS5hdVwvYXV0aFwvYXV0aGVudGljYXRlIiwiaWF0IjoxNDYyODUyNDIyLCJleHAiOjE0NjI4NTYwMjIsIm5iZiI6MTQ2Mjg1MjQyMiwianRpIjoiOWI1NTc4ZjU1MTdlMTJiNzM2YTVmNDk1MTU1ZWMwYzAiLCJzdWIiOiJhZG1pbmlzdHJhdG9yLWFkbWluaXN0cmF0b3IifQ.uzip-_BqEkHvxUD2cxlBrXnVnSYMPyucsBMYc83Tf68");
                    Uri apiSite = new Uri("http://seng3150.wingmanwebdesign.com.au/machines");

                    var response = await client.GetAsync(apiSite);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        machines = JsonConvert.DeserializeObject<List<ObjectModel.Machine>>(content);
                    }
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
