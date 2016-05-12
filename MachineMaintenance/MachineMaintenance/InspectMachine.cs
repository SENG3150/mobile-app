using MachineMaintenance.ObjectModel;
using Xamarin.Forms;

namespace MachineMaintenance
{
    public class InspectMachine : TabbedPage
    {
        private Machine machine;

        public InspectMachine(Machine machine)
        {
            this.machine = machine;

            inspectionController();
        }

        private void inspectionPresentation()
        { 
            Title = "Begin your inspection";
            BackgroundColor = Color.White;

            foreach (MajorAssembly majA in machine.model.majorAssemblies)
            {
                Children.Add(new MajorAssemblyView(majA));
            }


        }

        private void inspectionController()
        {
            inspectionPresentation();
        }
    }
}