/*
    *   Title:          MachineViewCell.cs
    *   Purpose:        A custom ViewCell
    *   Last Updated:   18/05/16
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PCLStorage;
using MachineMaintenance.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

namespace MachineMaintenance.View
{
    public class MachineViewCell : ViewCell
    {
        public MachineViewCell(Label idLabel, Label modelNameLabel)
        {
            View = new StackLayout
            {
                Padding = new Thickness(0, 5),
                Orientation = StackOrientation.Horizontal,

                Children =
                {
                    idLabel,
                    modelNameLabel
                }
            };
        }
    }
}
