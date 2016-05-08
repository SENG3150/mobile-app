using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MachineMaintenance
{
    public class CompleteInspection : ContentPage   //will probably become a carouselpage/navigation page.
    {

        public CompleteInspection()
        {
            Title = "Inspect Machine";
            BackgroundColor = Color.White;

            List<ContentPage> pages = new List<ContentPage>(0);
            List<ObjectModel.MajorAssemblies> majorAs;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    new Label()
                    {
                        Text = "This is where we inspect machines!"
                    }
                }
            };
        }
    }
}
