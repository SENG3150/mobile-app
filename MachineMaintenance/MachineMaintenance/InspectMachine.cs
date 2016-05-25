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
using System.Linq;

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
            Title = "Complete your Inspection";
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
                    inspection.timeCompleted = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");

                    var majAList = new List<object>();

                    foreach (MajorAssembly majA in inspection.majorAssemblies)
                    {
                        var majASubmit = new List<object>();
                        majASubmit.Add(new { id = majA.id });
                        /*//majASubmit.Add(new { comments = majA.comments });
                        //majASubmit.Add(new { photos = majA.photos });

                        var subAList = new List<object>();

                        foreach (SubAssembly subA in majA.subAssemblies)
                        {
                            var subASubmit = new List<object>();
                            subASubmit.Add(new { id = subA.id });
                            //subASubmit.Add(new { comments = subA.comments });
                            //subASubmit.Add(new { photos = subA.photos });

                            foreach (ObjectModel.Test test in subA.subAssembly.tests)
                            {
                                if(test.machineGeneral.test)
                                {
                                    var machineGeneralTest = new List<object>();
                                    subASubmit.Add(new { machineGeneralTest = machineGeneralTest });
                                }

                                if(test.oil.test)
                                {
                                    var oilTest = new List<object>();

                                    oilTest.Add(new { lead = subA.oilTest.lead });
                                    oilTest.Add(new { copper  = subA.oilTest.copper  });
                                    oilTest.Add(new { tin = subA.oilTest.tin  });
                                    oilTest.Add(new { iron  = subA.oilTest.iron  });
                                    oilTest.Add(new { pq90  = subA.oilTest.pq90  });
                                    oilTest.Add(new { silicon  = subA.oilTest.silicon  });
                                    oilTest.Add(new { sodium  = subA.oilTest.sodium  });
                                    oilTest.Add(new { aluminium  = subA.oilTest.aluminium  });
                                    oilTest.Add(new { water  = subA.oilTest.water  });
                                    oilTest.Add(new { viscosity  = subA.oilTest.viscosity});

                                    subASubmit.Add(new { oilTest = oilTest });
                                }

                                if(test.wear.test)
                                {
                                    var wearTest = new List<object>();

                                    wearTest.Add(new { description = subA.wearTest.description });
                                    wearTest.Add(new { lifeLower = subA.wearTest.lifeLower });
                                    wearTest.Add(new { lifeUpper = subA.wearTest.lifeUpper });
                                    wearTest.Add(new { limit = subA.wearTest.limit });
                                    wearTest.Add(new { @new = subA.wearTest.@new });
                                    wearTest.Add(new { smu = subA.wearTest.smu });

                                    subASubmit.Add(new { wearTest = wearTest });
                                }
                            }
                            subAList.Add(subASubmit);
                        }
                        majASubmit.Add( new { subAssemblies = subAList } );
                        majAList.Add(majASubmit);*/
                    }


                    var client = new HttpClient();
                    var jsonRequest = new
                    {
                        timeStarted = inspection.timeStarted,
                        //timeCompleted = inspection.timeCompleted,
                        majorAssemblies = majAList,
                    };

                    var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);       //saves login information as a string
                    HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");  //encodes login information
                    String site = "http://seng3150-api.wingmanwebdesign.com.au/inspections/" + inspection.id.ToString() + "/bulk";
                    Uri apiSite = new Uri(site);

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