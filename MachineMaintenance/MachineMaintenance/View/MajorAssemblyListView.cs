using MachineMaintenance.Inspections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MachineMaintenance.View
{
    public class MajorAssemblyListView : ListView
    {
        MajorAssemblyViewCell viewCell;

        public MajorAssemblyListView(List<MajorAssembly> majorAssemblies)
        {
            ItemsSource = majorAssemblies;
            Header = "Select the Major Assembly to Inspect";
            Style = (Style)Application.Current.Resources["listStyle"];

            ItemTemplate = new DataTemplate(() =>
            {
                Label majANameLabel = new Label();
                majANameLabel.SetBinding(Label.TextProperty, new Binding("majorAssembly.name", BindingMode.OneWay,
                            null, null, "Assembly: {0:d}"));
                majANameLabel.Style = (Style)Application.Current.Resources["listLabelStyle"];

                viewCell = new View.MajorAssemblyViewCell(majANameLabel);

                return viewCell;
            });
        }
    }
}

