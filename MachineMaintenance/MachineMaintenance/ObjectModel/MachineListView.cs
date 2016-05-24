using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MachineMaintenance.ObjectModel
{
    public class MachineListView : ListView
    {
        ObservableCollection<Machine> machines;

        public MachineListView(ObservableCollection<Machine> machines)
        {
            this.machines = machines;

            ItemTemplate = new DataTemplate(() =>
            {
                Label idLabel = new Label();
                idLabel.SetBinding(Label.TextProperty, new Binding("id", BindingMode.OneWay,
                            null, null, "Machine: {0:d}"));
                idLabel.Style = (Style)Application.Current.Resources["listLabelStyle"];

                Label modelNameLabel = new Label();
                modelNameLabel.SetBinding(Label.TextProperty, new Binding("model.name", BindingMode.OneWay,
                            null, null, "Model: {0:d}"));
                modelNameLabel.Style = (Style)Application.Current.Resources["listLabelStyle"];

                return new ViewCell
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
                    }
                };
            });
        }

        public void FilterMachines(string filter)
        {
            this.BeginRefresh();

            if (string.IsNullOrWhiteSpace(filter))
            {
                this.ItemsSource = machines;
            }

            else
            {
                this.ItemsSource = machines
                        .Where(x => x.id.ToString()
                            .Contains(filter.ToLower()));
            }

            this.EndRefresh();
        }
    }
}
