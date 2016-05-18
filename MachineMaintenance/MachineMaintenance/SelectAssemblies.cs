using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineMaintenance.ObjectModel;


using Xamarin.Forms;
using MachineMaintenance.Inspections;

namespace MachineMaintenance
{
    public class SelectAssemblies : ContentPage
    {
        ObjectModel.Machine machine;
        ListView majAListView;
        ObjectModel.MajorAssembly selection;
        Inspections.MajorAssembly toAdd;
        Inspection inspection;


        public SelectAssemblies(ObjectModel.Machine machine)
        {
            this.machine = machine;

            viewMachineController();
        }

        private void viewMachinePresentation()
        {
            Title = "ViewMachine";
            BackgroundColor = Color.White;

            Label heading = new Label();
            heading.Text = "Select the MajorAssemblies you would like to inspect";

            Button inspect = new Button();
            inspect.Text = "Done";
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
            Navigation.PushAsync(new InspectMachine(inspection));
        }

        private void Assembly_Selected(Object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            else
            {
                selection = (ObjectModel.MajorAssembly)e.SelectedItem;

                toAdd = new Inspections.MajorAssembly();

                toAdd.majorAssembly = new Inspections.MajorAssemblyDetails();
                toAdd.majorAssembly.id = selection.id;
                toAdd.majorAssembly.name = selection.name;
                toAdd.id = selection.id;
                toAdd.subAssemblies = new List<Inspections.SubAssembly>();

                foreach (ObjectModel.SubAssembly subA in selection.subAssemblies)
                {
                    Inspections.SubAssembly toAdd2 = new Inspections.SubAssembly();
                    toAdd2.subAssembly = subA;

                    toAdd2.id = subA.id;
                    toAdd.subAssemblies.Add(toAdd2);
                }

                inspection.majorAssemblies.Add(toAdd);
            }
        }


        private void viewMachineController()
        {
            inspection = new Inspection();
            inspection.majorAssemblies = new List<Inspections.MajorAssembly>();

            majAListView = new ListView
            {
                ItemsSource = machine.model.majorAssemblies,
                SeparatorColor = Color.Black,
                RowHeight = 50,

                ItemTemplate = new DataTemplate(() =>
                {
                    Label majANameLabel = new Label();
                    majANameLabel.SetBinding(Label.TextProperty, new Binding("name", BindingMode.OneWay,
                                null, null, "Assembly: {0:d}"));
                    majANameLabel.FontSize = 20;
                    majANameLabel.TextColor = Color.Black;

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,

                            Children =
                            {
                                majANameLabel
                            }
                        }
                    };
                })
            };

            majAListView.ItemSelected += Assembly_Selected;

            viewMachinePresentation();
        }
    }
}
