﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MachineMaintenance
{
    public class ViewMachine : ContentPage
    {

        public ViewMachine()
        {
            Title = "ViewMachine";
            BackgroundColor = Color.White;
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    new Label()
                    {
                        Text = "This is where we view details of a machine!"
                    }
                }
            };
        }
    }
}
