using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MachineMaintenance
{
    public class ViewMachine : ContentPage
    {
        ObjectModel.Machine selection;
        public ViewMachine(ObjectModel.Machine machine)
        {
            selection = machine;

            Title = "ViewMachine";
            BackgroundColor = Color.White;

            Label machineInfo = new Label();
            machineInfo.Text = "You are currently viewing " + machine.model.name;

            Button inspect = new Button();
            inspect.Text = "Inspect this Machine";
            inspect.Clicked += Inspect_Clicked;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    machineInfo,
                    inspect
                }
            };
        }

        private void Inspect_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InspectMachine(selection));
        }
    }
}
