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
    public class SelectMachineForInspection : ContentPage  
    {
        ObservableCollection<ObjectModel.Machine> machines;
        ObservableCollection<String> machineNames;
        public SelectMachineForInspection()
        {
            Title = "Inspect Machine";
            BackgroundColor = Color.White;
            displayMachines();

        }

        private async void displayMachines()
        {
            await getMachines();
            ObjectModel.Machine selection;

            machineNames = new ObservableCollection<String>();

            if (machines == null)
            {
                machineNames.Add("No machines to show");
            }

            else
            {
                foreach (ObjectModel.Machine m in machines)
                {
                    if (m != null /*&& machines isn't on device already*/)
                    {
                        machineNames.Add(m.model.name);
                    }
                }
            }

            var machineList = new ListView();
            machineList.Header = "Select a machine to inspect - Pull down to Update";
            machineList.ItemsSource = machineNames;

            machineList.IsPullToRefreshEnabled = true;
            machineList.Refreshing += ListView_Refreshing;

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
                            selection = m;
                            String select = JsonConvert.SerializeObject(selection);

                            await Navigation.PushAsync(new ViewMachine(selection));
                            break;
                        }
                    }
                    machineList.SelectedItem = null;

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

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            displayMachines();
        }

        public async Task getMachines()
        {
            try
            {
                IFile file = await FileSystem.Current.LocalStorage.GetFileAsync("Machines.txt");
                using (var stream = await file.OpenAsync(FileAccess.Read))
                {
                    var reader = new StreamReader(stream);
                    var content = await reader.ReadToEndAsync();
                    machines = JsonConvert.DeserializeObject<ObservableCollection<ObjectModel.Machine>>(content);
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
