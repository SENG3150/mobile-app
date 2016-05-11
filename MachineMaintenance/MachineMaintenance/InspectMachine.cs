using MachineMaintenance.ObjectModel;
using Xamarin.Forms;

namespace MachineMaintenance
{
    internal class InspectMachine : Page
    {
        private Machine machine;

        public InspectMachine(Machine selection)
        {
            machine = selection;
        }
    }
}