using MachineMaintenance.Inspections;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System;

namespace MachineMaintenance
{
    public class InspectMachine : ContentPage
    {
        private Inspection inspection;
        private MajorAssembly selection;
        private ListView majAListView;
        private ObservableCollection<MajorAssembly> majAssemList;
        private ObservableCollection<String> majAssemNames;

        public InspectMachine(Inspection inspection)
        {
            this.inspection = inspection;

            inspectionController();
        }

        private void inspectionPresentation()
        { 
            Title = "Begin your inspection";
            BackgroundColor = Color.White;

            Label heading = new Label();
            heading.Text = "Select Assembly to Inspect";
            heading.Style = (Style)Application.Current.Resources["headingStyle"];

            majAListView = new ListView
            {
                ItemsSource = inspection.majorAssemblies,
                Header = "Select the Major Assembly to Inspect",
                Style = (Style)Application.Current.Resources["listStyle"],

                ItemTemplate = new DataTemplate(() =>
                {
                    Label majANameLabel = new Label();
                    majANameLabel.SetBinding(Label.TextProperty, new Binding("majorAssembly.name", BindingMode.OneWay,
                                null, null, "Assembly: {0:d}"));
                    majANameLabel.Style = (Style)Application.Current.Resources["listLabelStyle"];

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            BackgroundColor = Color.FromHex("#ff5c33"),
                            Margin = 10,

                            Children =
                            {
                                majANameLabel
                            }
                        }
                    };
                })
            };

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
                }
            };
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