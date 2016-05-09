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
    public class SelectMachineForInspection : ContentPage   //will probably become a carouselpage/navigation page.
    {
        List<ObjectModel.Machine> machines;
        List<String> machineNames;

        public SelectMachineForInspection()
        {
            Title = "Inspect Machine";
            BackgroundColor = Color.White;

            getMachines(); 
        }

        private async void getMachines()
        {
            await viewMachines();
            machineNames = new List<String>();
            foreach (ObjectModel.Machine m in machines)
            {
                if (m != null)
                {
                    machineNames.Add(m.id.ToString() + "\n" + m.model.name);
                }
            }

            var machineList = new ListView();
            machineList.ItemsSource = machineNames;

            machineList.IsPullToRefreshEnabled = true;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    new Label()
                    {
                        Text = "This is where we inspect machines!"
                    },

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
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9zZW5nMzE1MC53aW5nbWFud2ViZGVzaWduLmNvbS5hdVwvYXV0aFwvYXV0aGVudGljYXRlIiwiaWF0IjoxNDYyNzkyMjQxLCJleHAiOjE0NjI3OTU4NDEsIm5iZiI6MTQ2Mjc5MjI0MSwianRpIjoiODU5Mjg4NTA0NzM1Y2Y5ZjczYzI2NGQyM2EyNWQ5YjciLCJzdWIiOiJhZG1pbmlzdHJhdG9yLWFkbWluaXN0cmF0b3IifQ.ZNnhSlEvc8WocF - s0cVvPDZ46ao5XtiLJLWAg5IOlnE");
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
