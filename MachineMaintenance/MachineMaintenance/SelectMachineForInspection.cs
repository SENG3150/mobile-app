﻿using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using PCLStorage;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using MachineMaintenance.ObjectModel;

namespace MachineMaintenance
{
    public class SelectMachineForInspection : ContentPage  
    {
        ObservableCollection<Machine> machines;
        Machine selection;
        ListView machineList = new ListView();

        public SelectMachineForInspection()
        {
            selectMachineController();
        }

        //presentation for page
        private void selectMachinePresentation()
        {
            Title = "Inspect Machine";
            BackgroundColor = Color.White;

            machineList = new ListView
            {
                ItemsSource = machines,

                IsPullToRefreshEnabled = true,
                SeparatorColor = Color.Black,
                RowHeight = 50,

                ItemTemplate = new DataTemplate(() =>
                {
                    Label idLabel = new Label();
                    idLabel.SetBinding(Label.TextProperty, new Binding("id", BindingMode.OneWay,
                                null, null, "Machine: {0:d}"));
                    idLabel.FontSize = 20;
                    idLabel.TextColor = Color.Black;

                    Label modelNameLabel = new Label();
                    modelNameLabel.SetBinding(Label.TextProperty, new Binding("model.name", BindingMode.OneWay,
                                null, null, "Model: {0:d}"));
                    modelNameLabel.FontSize = 20;
                    modelNameLabel.TextColor = Color.Black;

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,

                            Children =
                            {
                                idLabel,
                                modelNameLabel
                            }
                        }
                    };
                })
            };

            if (machines == null)
            {
                machineList.Header = new Label
                {
                    Text = "Please download a machine to continue" + Environment.NewLine + Environment.NewLine + 
                        "Pull down to refresh" + Environment.NewLine,
                    FontSize = 15,
                };
            }

            else
            {
                machineList.Header = new Label
                {
                    Text = "Select a Machine to begin inspection" + Environment.NewLine + Environment.NewLine + 
                    "Pull down to refresh" + Environment.NewLine,
                    FontSize = 15,
                };
            }

            machineList.Refreshing += ListView_Refreshing;
            machineList.ItemSelected += Machine_Selected;

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

        //controller for page
        private async void selectMachineController()
        {
            await getMachines();
            selectMachinePresentation();
        }

        //when user selects a machine
        private async void Machine_Selected(Object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                selection = (Machine)e.SelectedItem;

                foreach (Machine m in machines)
                {
                    if (selection.id == m.id)
                    {
                        selection = m;

                        await Navigation.PushAsync(new ViewMachine(selection));
                        break;
                    }
                }
            }

            machineList.SelectedItem = null;
        }

        //when user refreshes listView
        private void ListView_Refreshing(object sender, EventArgs e)
        {
            selectMachineController();
        }

        //retrieves machines from file
        public async Task getMachines()
        {
            try
            {
                IFile file = await FileSystem.Current.LocalStorage.GetFileAsync("Machines.txt");
                using (var stream = await file.OpenAsync(FileAccess.Read))
                {
                    var reader = new StreamReader(stream);
                    var content = await reader.ReadToEndAsync();
                    machines = JsonConvert.DeserializeObject<ObservableCollection<Machine>>(content);
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
