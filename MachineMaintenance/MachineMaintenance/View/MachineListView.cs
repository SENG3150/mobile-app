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
using System.Linq;

namespace MachineMaintenance.View
{
    public class MachineListView : ListView
    {
        MachineViewCell viewCell;
        ObservableCollection<Machine> machines;

        public MachineListView(ObservableCollection<Machine> machines)
        {
            this.machines = machines;
            ItemsSource = machines;
            Style = (Style)Application.Current.Resources["listStyle"];

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

                viewCell = new MachineViewCell(idLabel, modelNameLabel);
                return viewCell;
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
                        .Contains(filter)); 
            }

            this.EndRefresh();
        }
    }
}
