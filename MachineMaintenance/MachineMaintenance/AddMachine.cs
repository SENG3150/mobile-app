﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PCLStorage;
using MachineMaintenance.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

namespace MachineMaintenance
{
    public class AddMachine : ContentPage
    {
        private ObservableCollection<Machine> machines;
        private List<String> machineNames;
        private Machine selection;
        private ListView machineList;
        private List<Machine> machinesToAdd;

        public AddMachine()
        {
            addMachineController();
        }

        //presentation logic for page
        private void addMachinePresentation()
        {
            Title = "Add Machine";
            BackgroundColor = Color.White;

            Label list = new Label();

            machineList = new ListView();
            machineList.Header = "Add a Machine to Device";

            machineList.ItemsSource = machineNames;

            machineList.IsPullToRefreshEnabled = true;
            machineList.Refreshing += ListView_Refreshing;

            machineList.ItemSelected += MachineList_Selected;

            Content = new StackLayout
            {
                Margin = 50,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,

                Children =
                {
                    machineList
                }
            };
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            addMachineController();
        }

        //controller for page
        private async void addMachineController()
        {
            await getMachines();

            machineNames = new List<String>();

            foreach (Machine m in machines)
            {
                if (m != null)
                {
                    machineNames.Add("Machine: " + m.id.ToString() + " - Model: " + m.model.name);
                }
            }

            addMachinePresentation();
        }

        //when user selects a machine
        private async void MachineList_Selected(Object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                String id = e.SelectedItem.ToString();
                id = id.Replace("Machine: ", "").Replace("- Model: ", "");

                foreach (Machine m in machines)     //matches selection with machine
                {
                    String select = m.id.ToString() + " " + m.model.name;
                    if (select.Equals(id))
                    {
                        selection = m;
                        IFolder rootFolder = FileSystem.Current.LocalStorage;
                        IFile file = await rootFolder.CreateFileAsync("Machines.txt",
                                    CreationCollisionOption.OpenIfExists);

                        using (var stream = await file.OpenAsync(FileAccess.Read))
                        {
                            var reader = new StreamReader(stream);
                            var content = await reader.ReadToEndAsync();
                            //reads in existing Machines.txt file
                            machinesToAdd = JsonConvert.DeserializeObject<List<Machine>>(content);

                            //if no machines in file, add machine
                            if (machinesToAdd == null)
                            {
                                if (machinesToAdd == null)
                                {
                                    machinesToAdd = new List<Machine>();
                                }

                                machinesToAdd.Add(selection);
                                await DisplayAlert("Success", "Machine has been downloaded", "Ok");
                            }

                            //else if machines in file, see if current machine is already downloaded
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
                        //write all machines to file
                        await file.WriteAllTextAsync(jsonMachines);
                        break;
                    }
                }
                machineList.SelectedItem = null;
            }
        }

        //retrieve machines from api
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
                        machines = JsonConvert.DeserializeObject<ObservableCollection<Machine>>(content);
                    }

                    else //atm, all error codes under 1 else statement, should fix this at some point
                    {
                        await DisplayAlert("Error", "Ensure you are connected to the internet. If so, server may be experiencing difficulties", "I promise not to sue!");
                        await Navigation.PushAsync(new Login());
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
