using MachineMaintenance.ObjectModel;
using Xamarin.Forms;

namespace MachineMaintenance
{
    internal class SubAssemblyView : ContentPage
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

            Label heading = new Label();
            heading.Text = subA.name;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    heading,
                }
            };
        }

        private void subAssemController()
        {
            subAssemPresentation();
        }
    }
}