using MachineMaintenance.ObjectModel;
using Xamarin.Forms;

namespace MachineMaintenance
{
    public class TestView : ContentPage
    {
        private Test test;

        public TestView(Test test, object testType)
        {
            this.test = test;
            testController(testType);
        }

        private void testPresentation(Label heading)
        {
            Title = test.id.ToString();

            Entry data = new Entry();
            data.Placeholder = "Data";
            data.PlaceholderColor = Color.Black;
            data.TextColor = Color.Black;

            Button save = new Button();
            save.Text = "Save data";

            Content = new StackLayout
            {
                Margin = 50,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    heading,
                    data,
                    save
                }
            };
        }

        private void testController(object testType)
        {
            Label heading = new Label();

            if (testType is MachineGeneral)
            {
                heading.Text = "General Machine Test";
            }

            else if (testType is Oil)
            {
                heading.Text = "Oil Test";
            }

            else
            {
                heading.Text = "Wear Test";
            }

            heading.FontSize = 30;
            heading.TextColor = Color.Black;

            testPresentation(heading);
        }


    }
}