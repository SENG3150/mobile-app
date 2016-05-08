using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MachineMaintenance
{
    public class SelectMachineForInspection : ContentPage   //will probably become a carouselpage/navigation page.
    {

        public SelectMachineForInspection()
        {
            Title = "Inspect Machine";
            BackgroundColor = Color.White;

            var machineList = new ListView();
            machineList.ItemsSource = new List<ObjectModel.Machine>
            {
                //retrieve all the machines stored on the device
                //when machine is selected, navigate to a Complete Inspection page.
            };
            machineList.IsPullToRefreshEnabled = true;

            var dummyList = new ListView();
            dummyList.ItemsSource = new String[]
            {
                "Machine1",
                "Machine2",
                "Machine3",
                "Machine4"
            };
            dummyList.IsPullToRefreshEnabled = true;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    new Label()
                    {
                        Text = "This is where we inspect machines!"
                    },

                    machineList,
                    dummyList
                }
            };
        }
    }
}
