/*
    *   Title:          SelectAssembliesListView.cs
    *   Purpose:        A custom ListView
    *   Last Updated:   18/05/16
*/

using MachineMaintenance.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MachineMaintenance.View
{
    public class SelectAssembliesListView : ListView
    {
        SelectAssembliesViewCell viewCell;

        public SelectAssembliesListView(List<MajorAssembly> majorAssemblies)
        {
            ItemsSource = majorAssemblies;
            Header = "Select the MajorAssemblies to create an inspection";
            Style = (Style)Application.Current.Resources["listStyle"];

            ItemTemplate = new DataTemplate(() =>
            {
                Label majANameLabel = new Label();
                majANameLabel.SetBinding(Label.TextProperty, new Binding("name", BindingMode.OneWay,
                            null, null, "Assembly: {0:d}"));
                majANameLabel.Style = (Style)Application.Current.Resources["listLabelStyle"];

                viewCell = new SelectAssembliesViewCell(majANameLabel);

                return viewCell;
            });
        }
    }
}
