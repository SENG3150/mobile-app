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

        public ViewMachine(Machine machine)
        {
            this.machine = machine;

            viewMachineController();
        }

        private void viewMachineController()
        {
            viewMachinePresentation();
        }

        private void viewMachinePresentation()
        {
            Title = "ViewMachine";
            BackgroundColor = Color.White;

            Label machineInfo = new Label();
            machineInfo.Text = "You are currently viewing Machine: " + machine.id + " - Model: " + machine.model.name;
            //present more info on machine here

            Label updateInfo = new Label();
            updateInfo.Text = "It is best to update machine before beginning inspection";

            Button inspect = new Button();
            inspect.Text = "Inspect this Machine";
            inspect.Clicked += Inspect_Clicked;

            Button update = new Button();
            update.Text = "Update Machine";
            update.Clicked += Update_Clicked;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    machineInfo,
                    inspect,
                    update, //this will download previous inspections for machine
                    updateInfo
                }
            };
        }

        private void Update_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InspectMachine(machine));
        }

        private void Inspect_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InspectMachine(machine));
        }
    }
}
