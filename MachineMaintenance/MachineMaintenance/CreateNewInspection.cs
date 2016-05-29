/*
    *   Title:          CreateNewInspection.cs
    *   Purpose:        Is a Content Page that allows a user to make their own inspection from a downloaded machine
    *                   Currently does not save inspection to database and needs to be improved when time allows 
    *   Last Updated:   21/05/16
*/

using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using PCLStorage;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using MachineMaintenance.ObjectModel;
using System.Collections.Generic;

namespace MachineMaintenance
{
    public class CreateNewInspection : ContentPage  
    {
        ObservableCollection<Machine> machines;
        Machine selection;
        View.MachineListView machineList;
        SearchBar searchBar;

        public CreateNewInspection()
        {
            selectMachineController();
        }

        //presentation for page
        private void selectMachinePresentation()
        {
            Title = "Create Inspection";
            BackgroundColor = Color.White;

            Label heading = new Label();
            heading.Text = "Create New Inspection";
            heading.Style = (Style)Application.Current.Resources["headingStyle"];

            machineList = new View.MachineListView(machines);

            searchBar = new SearchBar()
            {
                Placeholder = "Search",
                FontSize = 25,
                TextColor = Color.Black,
                PlaceholderColor = Color.Gray,
                HeightRequest = 50,
            };
            searchBar.TextChanged += (sender, e) => machineList.FilterMachines(searchBar.Text);
            searchBar.SearchButtonPressed += (sender, e) =>
            {
                machineList.FilterMachines(searchBar.Text);
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
                    heading,
                    searchBar,
                    machineList
                }
            };
        }

        //controller for page
        private void selectMachineController()
        {
            getMachines();
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
                await Navigation.PushAsync(new SelectAssemblies(selection));
            }

            machineList.SelectedItem = null;
        }

        //when user refreshes listView
        private void ListView_Refreshing(object sender, EventArgs e)
        {
            getMachines();
            machineList.IsRefreshing = false;
        }

        //retrieves machines from file
        public void getMachines()
        {
            machines = new ObservableCollection<Machine>();
            try
            {
                List<MachineSerialised> content = App.database.getMachines();

                foreach (MachineSerialised stored in content)
                {
                    machines.Add(JsonConvert.DeserializeObject<Machine>(stored.machine));
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
