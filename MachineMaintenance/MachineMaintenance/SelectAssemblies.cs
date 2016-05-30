/*
    *   Title:          SelectAssemblies.cs
    *   Purpose:        Is a Content Page where user selects the assemblies they wish to inspect
    *   Last Updated:   19/05/16
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineMaintenance.ObjectModel;


using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MachineMaintenance
{
    public class SelectAssemblies : ContentPage
    {
        Machine machine;
        View.SelectAssembliesListView majAListView;
        MajorAssembly selection;
        List<MajorAssembly> selected; 


        public SelectAssemblies(ObjectModel.Machine machine)
        {
            this.machine = machine;

            viewMachineController();
        }

        private void viewMachinePresentation()
        {
            Title = "Select Assemblies";
            BackgroundColor = Color.White;

            Label heading = new Label();
            heading.Text = "Select Assemblies";
            heading.Style = (Style)Application.Current.Resources["headingStyle"];

            Button inspect = new Button();
            inspect.Text = "Done";
            inspect.Style = (Style)Application.Current.Resources["buttonStyle"];
            inspect.Clicked += Inspect_Clicked;

            Content = new StackLayout
            {
                Margin = 50,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,

                Children =
                {
                    heading,
                    majAListView,
                    inspect,
                }
            };
        }

        private void Inspect_Clicked(object sender, EventArgs e)
        {
            submitInspection();
        }

        private async void submitInspection()
        {
            List<ObjectModel.User> userContent = App.database.getUser();
            ObjectModel.User user = userContent[userContent.Count - 1];

            var majAList = new List<object>();

            foreach (MajorAssembly majA in selected)
            {
                var subAList = new List<object>();

                foreach (SubAssembly subA in majA.subAssemblies)
                {
                    subAList.Add(new
                    {
                        subAssembly = subA.id,
                    });
                }

                majAList.Add(new
                {
                    majorAssembly = majA.id,
                    subAssemblies = subAList,
                });
            }

            var client = new HttpClient();
            var jsonRequest = new
            {
                machine = machine.id,
                timeScheduled = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"),
                technician = "1",
                domainExpert = "1",
                majorAssemblies = majAList,
            };

            var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);
            HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");
            String site = "http://seng3150-api.wingmanwebdesign.com.au/inspections/bulk";
            Uri apiSite = new Uri(site);

            List<ObjectModel.Token> token;
            token = App.database.getToken();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token[token.Count - 1].token);

            var response = await client.PostAsync(apiSite, content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "Click Ok to start the inspection", "Ok");
                Inspections.Inspection inspection = new Inspections.Inspection();
                inspection = JsonConvert.DeserializeObject<Inspections.Inspection>(await response.Content.ReadAsStringAsync());

                apiSite = new Uri("http://seng3150-api.wingmanwebdesign.com.au/inspections/" + inspection.id + "?include=majorAssemblies.majorAssembly,majorAssemblies.subAssemblies.subAssembly.tests,machine.model");

                response = await client.GetAsync(apiSite);
                if (response.IsSuccessStatusCode)
                {
                    inspection = JsonConvert.DeserializeObject<Inspections.Inspection>(await response.Content.ReadAsStringAsync());
                }
                await Navigation.PushAsync(new InspectMachine(inspection));
            }

            else
            {
                await DisplayAlert("Error", await response.Content.ReadAsStringAsync(), "Ok");
                await Navigation.PushAsync(new SelectUserType());
            }
            //await Navigation.PushAsync(new InspectMachine(inspection));
        }

        private void Assembly_Selected(Object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            else
            {
                selection = (MajorAssembly)e.SelectedItem;
                byte i;
                i = 0;

                foreach (MajorAssembly maj in selected)
                {
                    if (maj.id == selection.id)
                    {
                        break;
                    }
                    i++;
                }

                if (i == selected.Count || selected.Count == 0)
                {
                    selected.Add(selection);           
                }

                else
                {
                    DisplayAlert("ERROR", "Major Assembly already selected!", "Ok");
                }
                majAListView.SelectedItem = null;
            }
        }


        private void viewMachineController()
        {
            selected = new List<MajorAssembly>();
            majAListView = new View.SelectAssembliesListView(machine.model.majorAssemblies);
            majAListView.ItemSelected += Assembly_Selected;

            viewMachinePresentation();
        }
    }
}
