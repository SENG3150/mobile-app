using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PCLStorage;

using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

namespace MachineMaintenance
{
    public class AddMachine : ContentPage
    {
        ObservableCollection<ObjectModel.Machine> machines;
        List<String> machineNames;

        public AddMachine()
        {
            Title = "Add Machine";
            BackgroundColor = Color.White;

            displayMachines();
        }

        private async void displayMachines()
        {
            await getMachines();

            machineNames = new List<String>();
            foreach (ObjectModel.Machine m in machines)
            {
                if (m != null /*&& machines isn't on device already*/)
                {
                    machineNames.Add(m.model.name);
                }
            }

            var machineList = new ListView();
            machineList.Header = "Add a Machine to Device";
            machineList.ItemsSource = machineNames;

            machineList.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                {
                    return;
                }
                else
                {
                    String id = e.SelectedItem.ToString();

                    foreach (ObjectModel.Machine m in machines)
                    {

                        if (m.model.name.Equals(id))
                        {
                            ObjectModel.Machine selection = m;
                        }
                    }
                    machineList.SelectedItem = null;
                    //need to save machine to file HERE
                    await Navigation.PushAsync(new ViewMachine());
                }
            };

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

        private async Task getMachines()
        {
            try
            {
                using (var c = new HttpClient())
                {

                    IFile file = await FileSystem.Current.LocalStorage.GetFileAsync("Token.txt");

                    var stream = await file.OpenAsync(FileAccess.Read);
                    var reader = new StreamReader(stream);
                    String token = await reader.ReadToEndAsync();
                    


                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    Uri apiSite = new Uri("http://seng3150.wingmanwebdesign.com.au/machines");

                    var response = await client.GetAsync(apiSite);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        machines = JsonConvert.DeserializeObject<ObservableCollection<ObjectModel.Machine>>(content);
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
