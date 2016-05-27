using System;
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
        private Machine selection;
        private View.MachineListView machineList;
        SearchBar searchBar;

        public AddMachine()
        {
            addMachineController();
        }

        //presentation logic for page
        private void addMachinePresentation()
        {
            Title = "Add Machine";
            BackgroundColor = Color.White;

            Label heading = new Label();
            heading.Text = "Download Machine";
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
                    Text = "There are no machines available right now" + Environment.NewLine + Environment.NewLine +
                    "Pull down to refresh" + Environment.NewLine,
                    FontSize = 15,
                };
            }

            else
            {
                machineList.Header = new Label
                {
                    Text = "Choose a Machine to download" + Environment.NewLine + Environment.NewLine +
                    "Pull down to refresh" + Environment.NewLine,
                    FontSize = 15,
                };
            }

            machineList.Refreshing += ListView_Refreshing;
            machineList.ItemSelected += MachineList_Selected;

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

        private async void ListView_Refreshing(object sender, EventArgs e)
        {
            await getMachines();
            machineList.IsRefreshing = false;
        }

        //controller for page
        private async void addMachineController()
        {
            await getMachines();
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
                selection = (Machine)e.SelectedItem;

                MachineSerialised toAdd = new MachineSerialised();
                toAdd.machine = JsonConvert.SerializeObject(selection);

                if (App.database.getMachine(toAdd.machine) == null)
                {
                    App.database.storeMachine(toAdd);
                    await DisplayAlert("Success", "Machine has been downloaded", "Ok");
                }

                else
                {
                    await DisplayAlert("Error", "Machine is already downloaded!", "Ok");
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
                    List<Token> token;
                    token = App.database.getToken();

                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token[token.Count - 1].token);
                    Uri apiSite = new Uri("http://seng3150-api.wingmanwebdesign.com.au/machines?include=model.majorAssemblies.subAssemblies.tests");

                    var response = await client.GetAsync(apiSite);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        machines = JsonConvert.DeserializeObject<ObservableCollection<Machine>>(content);
                    }

                    else //atm, all error codes under 1 else statement, should fix this at some point
                    {
                        await DisplayAlert("Error", response.ToString(), "Ok");
                        await Navigation.PushAsync(new SelectUserType());
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
