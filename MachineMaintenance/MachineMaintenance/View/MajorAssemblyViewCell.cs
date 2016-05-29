/*
    *   Title:          MajorAssemblyViewCell.cs
    *   Purpose:        A custom ViewCell
    *   Last Updated:   18/05/16
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MachineMaintenance.View
{
    class MajorAssemblyViewCell : ViewCell
    {
        public MajorAssemblyViewCell(Label majANameLabel)
        {
            View = new StackLayout
            {
                Padding = new Thickness(5, 5),
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.FromHex("#ffad99"),

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
