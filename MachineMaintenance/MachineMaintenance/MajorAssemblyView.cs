using Xamarin.Forms;
using MachineMaintenance.ObjectModel;

namespace MachineMaintenance
{
    public class MajorAssemblyView : CarouselPage
    {
        MajorAssembly majA;
        public MajorAssemblyView(MajorAssembly majA)
        {
            this.majA = majA;
            majAssemController();
        }

        private void majAssemPresentation()
        {
            Title = majA.name;
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