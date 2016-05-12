using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineMaintenance.ObjectModel;

using Xamarin.Forms;

namespace MachineMaintenance
{
    public class SchedulePage : ContentPage
    {

        public SchedulePage()
        {
            Title = "Schedule";
            BackgroundColor = Color.White;
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    new Label()
                    {
                        Text = "This is where we view the schedule!"
                    }
                }
            };
        }
    }
}
