using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PCLStorage;
using MachineMaintenance.ObjectModel;
using MachineMaintenance.Inspections;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

namespace MachineMaintenance
{
    public class SchedulePage : ContentPage
    {
        private ObservableCollection<Inspection> inspections;
        private Inspection selection;
        private ListView inspectionList;

        public SchedulePage()
        {
            getScheduleController();
        }

        //presentation logic for page
        private void getSchedulePresentation()
        {
            Title = "View Schedule";
            BackgroundColor = Color.White;

            inspectionList = new ListView
            {
                ItemsSource = inspections,
                IsPullToRefreshEnabled = true,
                SeparatorColor = Color.Black,
                RowHeight = 50,

                ItemTemplate = new DataTemplate(() =>
                {
                    Label idLabel = new Label();
                    idLabel.SetBinding(Label.TextProperty, new Binding("machine.id", BindingMode.OneWay,
                                null, null, "Machine: {0:d}"));
                    idLabel.FontSize = 20;
                    idLabel.TextColor = Color.Black;

                    Label modelNameLabel = new Label();
                    modelNameLabel.SetBinding(Label.TextProperty, new Binding("machine.model.name", BindingMode.OneWay,
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

            if (inspections == null)
            {
                inspectionList.Header = new Label
                {
                    Text = "There are no inspections available right now" + Environment.NewLine + Environment.NewLine +
                    "Pull down to refresh" + Environment.NewLine,
                    FontSize = 15,
                };
            }

            else
            {
                inspectionList.Header = new Label
                {
                    Text = "Choose a Inspection to complete" + Environment.NewLine + Environment.NewLine +
                    "Pull down to refresh" + Environment.NewLine,
                    FontSize = 15,
                };
            }

            inspectionList.Refreshing += ListView_Refreshing;
            inspectionList.ItemSelected += InspectionList_Selected;

            Content = new StackLayout
            {
                Margin = 50,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,

                Children =
                {
                    inspectionList
                }
            };
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            getScheduleController();
        }

        //controller for page
        private async void getScheduleController()
        {
            await getSchedule();
            getSchedulePresentation();
        }

        //when user selects a machine
        private async void InspectionList_Selected(Object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                selection = (Inspection)e.SelectedItem;

                foreach (Inspection i in inspections)     //matches selection with machine
                {
                    if (selection.id == i.id)
                    {
                        IFolder rootFolder = FileSystem.Current.LocalStorage;
                        IFile file = await rootFolder.CreateFileAsync("Inspections.txt",
                                    CreationCollisionOption.ReplaceExisting);

                        String jsonMachines = JsonConvert.SerializeObject(inspections);
                        //write all machines to file
                        await file.WriteAllTextAsync(jsonMachines);
                        break;
                    }
                }
                await DisplayAlert("Success", "Click Ok to start inspection!", "Ok");
                await Navigation.PushAsync(new InspectMachine(selection));
                inspectionList.SelectedItem = null;
            }
        }

        //retrieve inspections from api
        private async Task getSchedule()
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
                    Uri apiSite = new Uri("http://seng3150-api.wingmanwebdesign.com.au/inspections?include=majorAssemblies.majorAssembly,majorAssemblies.subAssemblies.subAssembly.tests,machine.model");

                    var response = await client.GetAsync(apiSite);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        inspections = JsonConvert.DeserializeObject<ObservableCollection<Inspection>>(content);
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
