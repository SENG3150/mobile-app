using MachineMaintenance.ObjectModel;
using Xamarin.Forms;

namespace MachineMaintenance
{
    internal class SubAssemblyView : CarouselPage
    {
        private SubAssembly subA;

        public SubAssemblyView(SubAssembly subA)
        {
            this.subA = subA;
            subAssemController();
        }

        private void subAssemPresentation()
        {
            Title = subA.name;

            foreach (Test test in subA.tests)
            {
                Children.Add(new TestView(test));
            }

        }

        private void subAssemController()
        {
            subAssemPresentation();
        }
    }
}