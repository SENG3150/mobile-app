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
            ObjectModel.Machine selection;

            machineNames = new List<String>();
            foreach (ObjectModel.Machine m in machines)
            {
                if (m != null /*&& machines isn't on device already*/)
                {
                    machineNames.Add("Machine: " + m.id.ToString() + " - Model: " + m.model.name);
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
                    id = id.Replace("Machine: ", "").Replace("- Model: ", "");

                    foreach (ObjectModel.Machine m in machines)
                    {
                        String select = m.id.ToString() + " " + m.model.name;
                        if (select.Equals(id))
                        {
                            selection = m;
                            IFolder rootFolder = FileSystem.Current.LocalStorage;
                            IFile file = await rootFolder.CreateFileAsync("Machines.txt",
                                        CreationCollisionOption.OpenIfExists);


                            List<ObjectModel.Machine> machinesToAdd;
                            using (var stream = await file.OpenAsync(FileAccess.Read))
                            {
                                var reader = new StreamReader(stream);
                                var content = await reader.ReadToEndAsync();
                                machinesToAdd = JsonConvert.DeserializeObject<List<ObjectModel.Machine>>(content);

                                if (machinesToAdd == null)
                                {
                                    if (machinesToAdd == null)
                                    {
                                        machinesToAdd = new List<ObjectModel.Machine>();
                                    }

                                    machinesToAdd.Add(selection);
                                    await DisplayAlert("Success", "Machine has been downloaded", "Ok");
                                }

                                else
                                {
                                    int i;

                                    for (i = 0; i < machinesToAdd.Count; i++)
                                    {
                                        if (machinesToAdd[i].id == selection.id)
                                        {
                                            await DisplayAlert("Error", "Machine is already downloaded!", "Ok");
                                            break;
                                        }
                                    }

                                    if (i == machinesToAdd.Count)
                                    {
                                        machinesToAdd.Add(selection);
                                        await DisplayAlert("Success", "Machine has been downloaded", "Ok");
                                    }                                    
                                }

                            }

                            String jsonMachines = JsonConvert.SerializeObject(machinesToAdd);

                            await file.WriteAllTextAsync(jsonMachines);
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
                    Uri apiSite = new Uri("http://seng3150-api.wingmanwebdesign.com.au/machines?include=model.majorAssemblies.subAssemblies.tests");

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
