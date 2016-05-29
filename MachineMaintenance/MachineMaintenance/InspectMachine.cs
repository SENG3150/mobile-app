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

            this.inspection.timeStarted = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
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
                    List<ObjectModel.User> userContent = App.database.getUser();
                    ObjectModel.User user = userContent[userContent.Count - 1];

                    inspection.timeCompleted = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");

                    var majAList = new List<object>();

                    foreach (MajorAssembly majA in inspection.majorAssemblies)
                    {
                        var subAList = new List<object>();

                        foreach (SubAssembly subA in majA.subAssemblies)
                        {
                            var commentsSubmit = new List<object>();
                            var actionItemSubmit = new object();

                            var comment = (new
                            {
                                timeCommented = "",
                                authorType = "",
                                text = "",
                                author = new ObjectModel.User(),
                            });

                            var uniqueDetailsSubmit = (new
                            {
                                Test = "Type of Test",
                                A = "Result"
                            });

                            comment = null;

                            var actionItem = (new
                            {
                                status = "",
                                issue = "",
                                action = "",
                                timeAction = "",
                            });

                            actionItem = null;

                            var machineGeneralTestSubmit = (new
                            {

                            });

                            var oilTestSubmit = (new
                            {
                                lead = 0,
                                copper = 0,
                                tin = 0,
                                iron = 0,
                                pq90 = 0,
                                silicon = 0,
                                sodium = 0,
                                aluminium = 0,
                                water = "0",
                                viscosity = 0,
                                comments = new List<object>(),
                                actionItem = new object(),
                            });

                            var wearTestSubmit = (new
                            {
                                description = "Desc",
                                @new = "New",
                                limit = "Limit",
                                lifeLower = "Lower",
                                lifeUpper = "Upper",
                                smu = 0,
                                timeStart = "",
                                uniqueDetails = uniqueDetailsSubmit,
                                //comments = new List<object>(),
                                //actionItem = new object()
                            });

                            machineGeneralTestSubmit = null;
                            oilTestSubmit = null;
                            wearTestSubmit = null;

                            if (subA.subAssembly.tests[0].machineGeneral.test)
                            {
                                machineGeneralTestSubmit = (new
                                {

                                });
                            }

                            if (subA.subAssembly.tests[0].oil.test)
                            {
                                if (subA.oilTest.comments != null)
                                {
                                    comment = (new
                                    {
                                        timeCommented = subA.oilTest.comments[0].timeCommented,
                                        authorType = subA.oilTest.comments[0].authorType,
                                        text = subA.oilTest.comments[0].text,
                                        author = user,
                                    });

                                    commentsSubmit = new List<object>();
                                    commentsSubmit.Add(comment);
                                }

                                if (subA.oilTest.actionItem != null)
                                {
                                    /*actionItemSubmit = (new
                                    {
                                        status = subA.oilTest.actionItem.status,
                                        issue = subA.oilTest.actionItem.issue,
                                        action = subA.oilTest.actionItem.action,
                                        timeActioned = subA.oilTest.actionItem.timeActioned,
                                    });*/
                                }

                                oilTestSubmit = (new
                                {
                                    lead = subA.oilTest.lead,
                                    copper = subA.oilTest.copper,
                                    tin = subA.oilTest.tin,
                                    iron = subA.oilTest.iron,
                                    pq90 = subA.oilTest.pq90,
                                    silicon = subA.oilTest.silicon,
                                    sodium = subA.oilTest.sodium,
                                    aluminium = subA.oilTest.aluminium,
                                    water = subA.oilTest.water,
                                    viscosity = subA.oilTest.viscosity,
                                    comments = commentsSubmit,
                                    actionItem = actionItemSubmit
                                });
                            }

                            commentsSubmit = null;
                            comment = null;

                            if (subA.subAssembly.tests[0].wear.test)
                            {
                                if (subA.wearTest.comments != null)
                                {
                                    comment = (new
                                    {
                                        timeCommented = subA.wearTest.comments[0].timeCommented,
                                        authorType = subA.wearTest.comments[0].authorType,
                                        text = subA.wearTest.comments[0].text,
                                        author = user,
                                    });

                                    commentsSubmit = new List<object>();
                                    commentsSubmit.Add(comment);
                                }

                                if (subA.wearTest.actionItem != null)
                                {
                                    /*actionItemSubmit = (new
                                    {
                                        status = subA.oilTest.actionItem.status,
                                        issue = subA.oilTest.actionItem.issue,
                                        action = subA.oilTest.actionItem.action,
                                        timeActioned = subA.oilTest.actionItem.timeActioned,
                                    });*/
                                }

                                wearTestSubmit = (new
                                {
                                    description = subA.wearTest.description,
                                    @new = subA.wearTest.@new,
                                    limit = subA.wearTest.limit,
                                    lifeLower = subA.wearTest.lifeLower,
                                    lifeUpper = subA.wearTest.lifeUpper,
                                    smu = subA.wearTest.smu,
                                    timeStart = subA.wearTest.timeStart,
                                    uniqueDetails = uniqueDetailsSubmit,
                                    //comments = commentsSubmit,
                                    //actionItem = actionItemSubmit
                                });
                            }

                            subAList.Add(new
                            {
                                id = subA.id,
                                comments = subA.comments,
                                photos = subA.photos,
                                machineGeneralTest = machineGeneralTestSubmit,
                                oilTest = oilTestSubmit,
                                wearTest = wearTestSubmit,
                            });
                        }


                        majAList.Add(new
                        {
                            id = majA.id,
                            comments = majA.comments,
                            photos = majA.photos,
                            subAssemblies = subAList,
                        });
                    }

                    var client = new HttpClient();
                    var jsonRequest = new
                    {
                        timeStarted = inspection.timeStarted,
                        timeCompleted = inspection.timeCompleted,
                        majorAssemblies = majAList,
                    };

                    var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);
                    HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");
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
                        await DisplayAlert("Error", response.ToString(), "Ok");
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