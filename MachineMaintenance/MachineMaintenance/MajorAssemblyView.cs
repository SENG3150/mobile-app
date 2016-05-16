using Xamarin.Forms;
using MachineMaintenance.Inspections;

namespace MachineMaintenance
{
    public class MajorAssemblyView : TabbedPage
    {
        MajorAssembly majA;
        public MajorAssemblyView(MajorAssembly majA)
        {
            this.majA = majA;
            majAssemController();
        }

        private void majAssemPresentation()
        {
            Title = majA.majorAssembly.name;
            BackgroundColor = Color.White;

            foreach (SubAssembly subA in majA.subAssemblies)
            {
                Children.Add(new SubAssemblyView(subA));
            }
        }

        private void majAssemController()
        {
            majAssemPresentation();
        }
    }
}