using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineMaintenance.ObjectModel;


using Xamarin.Forms;

namespace MachineMaintenance
{
    public class ViewMachine : ContentPage
    {
        Machine machine;
        ListView majAListView;
        

        public ViewMachine(Machine machine)
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
            Inspections.Inspection inspection = new Inspections.Inspection();

            //Navigation.PushAsync(new InspectMachine(machine));
        }


        private void viewMachineController()
        {
            majAListView = new ListView
            {
                ItemsSource = machine.model.majorAssemblies,
                IsPullToRefreshEnabled = true,
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

            viewMachinePresentation();
        }
    }
}
