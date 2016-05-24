using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MachineMaintenance.View
{
    class SelectAssembliesViewCell : ViewCell
    {
        public SelectAssembliesViewCell(Label majANameLabel)
        {
            View = new StackLayout
            {
                Padding = new Thickness(5, 5),
                Orientation = StackOrientation.Horizontal,

                Children =
                {
                    majANameLabel,
                }
            };

            Tapped += (sender, args) =>
            {
                View.BackgroundColor = Color.FromHex("#B7FF93");
            };
        }
    }
}
