/*
    *   Title:          SchedulePage.cs
    *   Purpose:        Is a Content Page displaying a list of available inspections
    *   Last Updated:   25/05/16
*/

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
        private List<Inspection> inspections;
        private Inspection selection;
        private ListView inspectionList;

        public SchedulePage()
        {
            getScheduleController();
        }

        //presentation logic for page
        private void getSchedulePresentation()
        {
            Title = "Assigned Inspections";
            BackgroundColor = Color.White;

            Label heading = new Label();
            heading.Text = "Assigned Inspections";
            heading.Style = (Style)Application.Current.Resources["headingStyle"];

            inspectionList = new ListView
            {
                ItemsSource = inspections,
                Style = (Style)Application.Current.Resources["listStyle"],

                ItemTemplate = new DataTemplate(() =>
                {
                    Label idLabel = new Label();
                    idLabel.SetBinding(Label.TextProperty, new Binding("timeScheduled", BindingMode.OneWay,
                                null, null, "Time Scheduled: {0:d}"));
                    idLabel.Style = (Style)Application.Current.Resources["listLabelStyle"];

                    Label modelNameLabel = new Label();
                    modelNameLabel.SetBinding(Label.TextProperty, new Binding("machine.model.name", BindingMode.OneWay,
                                null, null, "Model: {0:d}"));
                    modelNameLabel.Style = (Style)Application.Current.Resources["listLabelStyle"];

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
                    heading,
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

                    List<Token> token;
                    token = App.database.getToken();

                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token[token.Count - 1].token);
                    Uri apiSite = new Uri("http://seng3150-api.wingmanwebdesign.com.au/inspections/incomplete?include=majorAssemblies.majorAssembly,majorAssemblies.subAssemblies.subAssembly.tests,machine.model");

                    var response = await client.GetAsync(apiSite);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        inspections = JsonConvert.DeserializeObject<List<Inspection>>(content);
                    }

                    else //atm, all error codes under 1 else statement, should fix this at some point
                    {
                        await DisplayAlert("Error", "Ensure you are connected to the internet. If so, server may be experiencing difficulties", "I promise not to sue!");
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
