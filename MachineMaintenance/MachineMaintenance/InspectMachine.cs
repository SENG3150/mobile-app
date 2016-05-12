using MachineMaintenance.ObjectModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System;

namespace MachineMaintenance
{
    public class InspectMachine : ContentPage
    {
        private Machine machine;
        private MajorAssembly selection;
        private ListView listOfMajA;
        private ObservableCollection<MajorAssembly> majAssemList;
        private ObservableCollection<string> majAssemNames;

        public InspectMachine(Machine machine)
        {
            this.machine = machine;

            inspectionController();
        }

        private void inspectionPresentation()
        { 
            Title = "Begin your inspection";
            BackgroundColor = Color.White;

            listOfMajA = new ListView();

            listOfMajA.ItemsSource = majAssemNames;
            listOfMajA.ItemSelected += MajA_Selected;
            listOfMajA.Header = "Please select a Major Assembly to Inspect";

            Content = new StackLayout
            {
                Margin = 50,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,

                Children =
                {
                    listOfMajA,
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
                String id = e.SelectedItem.ToString();

                foreach (MajorAssembly majA in majAssemList)
                {
                    String select = majA.name;

                    if (select.Equals(id))
                    {
                        selection = majA;
                        await Navigation.PushAsync(new MajorAssemblyView(selection));
                        break;
                    }
                }
            }

            listOfMajA.SelectedItem = null;
        }

        private void inspectionController()
        {
            majAssemNames = new ObservableCollection<string>();
            majAssemList = new ObservableCollection<MajorAssembly>();
            foreach (MajorAssembly majA in machine.model.majorAssemblies)
            {
                majAssemList.Add(majA);
                majAssemNames.Add(majA.name);
            }

            inspectionPresentation();
        }
    }
}