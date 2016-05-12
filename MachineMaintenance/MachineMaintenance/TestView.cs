using MachineMaintenance.ObjectModel;
using Xamarin.Forms;

namespace MachineMaintenance
{
    public class TestView : ContentPage
    {
        private Test test;

        public TestView(Test test)
        {
            this.test = test;
            testController();
        }

        private void testPresentation()
        {
            Title = test.id.ToString();

            Label heading = new Label();
            heading.Text = test.id.ToString();

            Content = new StackLayout
            {
                Margin = 50,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,

                Children =
                {
                    heading,
                }
            };
        }

        private void testController()
        {

            testPresentation();
        }


    }
}