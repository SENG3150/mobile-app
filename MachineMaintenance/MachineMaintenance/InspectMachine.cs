using MachineMaintenance.Inspections;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MachineMaintenance
{
    public class InspectMachine : ContentPage
    {
        private Inspection inspection;
        private MajorAssembly selection;
        private View.MajorAssemblyListView majAListView;
        private ObservableCollection<MajorAssembly> majAssemList;
        private ObservableCollection<String> majAssemNames;

        public InspectMachine(Inspection inspection)
        {
            this.inspection = inspection;

            inspectionController();
        }

        private void inspectionPresentation()
        { 
            Title = "Complete your Machine";
            BackgroundColor = Color.White;

            Label heading = new Label();
            heading.Text = "Select Assembly to Inspect";
            heading.Style = (Style)Application.Current.Resources["headingStyle"];

            Button submit = new Button();
            submit.Text = "Submit";
            submit.Style = (Style)Application.Current.Resources["buttonStyle"];
            submit.Clicked += Submit_Clicked;

            majAListView = new View.MajorAssemblyListView(inspection.majorAssemblies);
            majAListView.ItemSelected += MajA_Selected;

            Content = new StackLayout
            {
                Margin = 50,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,

                Children =
                {
                    heading,
                    majAListView,
                    submit,
                }
            };
        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            await this.submitData();
        }

        private async Task submitData()
        {
            try
            {
                using (var c = new HttpClient())
                {
                    var client = new HttpClient();
                    var jsonRequest = new
                    {
                        inspection,
                    };

                    var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);       //saves login information as a string
                    HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");  //encodes login information
                    Uri apiSite = new Uri("https://seng3150-api.wingmanwebdesign.com.au/inspections/1/bulk ");

                    List<ObjectModel.Token> token;
                    token = App.database.getToken();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token[token.Count - 1].token);

                    var response = await client.PostAsync(apiSite, content);        

                    if (response.IsSuccessStatusCode) 
                    {
                        await DisplayAlert("Success", "Data has been submitted!", "Okay");
                        await Navigation.PushAsync(new Menu());
                    }

                    else 
                    {
                        await DisplayAlert("Error", "Ensure you are connected to the internet. If so, server may be experiencing difficulties", "I promise not to sue!");
                        await Navigation.PushAsync(new SelectUserType());
                    }
                }
                Navigation.RemovePage(this);
            }

            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }



        private async void MajA_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            else
            {
                selection = (Inspections.MajorAssembly)e.SelectedItem;
                await Navigation.PushAsync(new MajorAssemblyView(selection));
            }

            majAListView.SelectedItem = null;
        }

        private void inspectionController()
        {
            majAssemNames = new ObservableCollection<String>();
            majAssemList = new ObservableCollection<MajorAssembly>();

            foreach (MajorAssembly majA in inspection.majorAssemblies)
            {
                majAssemList.Add(majA);
                majAssemNames.Add(majA.majorAssembly.name);

                foreach (Inspections.SubAssembly subA in majA.subAssemblies)
                {
                    subA.wearTest = new WearTest();
                    subA.oilTest = new OilTest();
                    subA.machineGeneralTest = new MachineGeneralTest();
                }
            }              
            inspectionPresentation();
        }
    }
}