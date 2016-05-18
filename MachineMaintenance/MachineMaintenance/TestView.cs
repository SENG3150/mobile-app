using MachineMaintenance.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MachineMaintenance
{
    public class TestView : ContentPage
    {
        private Test test;
        private List<Entry> input;

        public TestView(Test test, object testType)
        {
            this.test = test;
            testController(testType);
        }

        private void testController(object testType)
        {
            Label heading = new Label();
            input = new List<Entry>();

            if (testType is MachineGeneral)
            {
                heading.Text = "General Machine Test";

                heading.FontSize = 30;
                heading.TextColor = Color.Black;

                Entry type = new Entry();
                type.Placeholder = "Type of Test";
                type.PlaceholderColor = Color.Black;
                type.TextColor = Color.Black;

                Entry docType = new Entry();
                docType.Placeholder = "Type of Doc";
                docType.PlaceholderColor = Color.Black;
                docType.TextColor = Color.Black;

                Entry comments = new Entry();
                comments.Placeholder = "Comments";
                comments.PlaceholderColor = Color.Black;
                comments.TextColor = Color.Black;

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
                        type,
                        docType,
                        comments,
                        save
                    }
                };

            }

            else if (testType is Oil)
            {
                heading.Text = "Oil";

                heading.FontSize = 30;
                heading.TextColor = Color.Black;

                Entry lead = new Entry();
                lead.Placeholder = "Lead";
                lead.PlaceholderColor = Color.Black;
                lead.TextColor = Color.Black;

                Entry copper = new Entry();
                copper.Placeholder = "Copper";
                copper.PlaceholderColor = Color.Black;
                copper.TextColor = Color.Black;

                Entry tin = new Entry();
                tin.Placeholder = "Tin";
                tin.PlaceholderColor = Color.Black;
                tin.TextColor = Color.Black;

                Entry iron = new Entry();
                iron.Placeholder = "Iron";
                iron.PlaceholderColor = Color.Black;
                iron.TextColor = Color.Black;

                Entry pq90 = new Entry();
                pq90.Placeholder = "pq90";
                pq90.PlaceholderColor = Color.Black;
                pq90.TextColor = Color.Black;

                Entry silicon = new Entry();
                silicon.Placeholder = "Silicon";
                silicon.PlaceholderColor = Color.Black;
                silicon.TextColor = Color.Black;

                Entry sodium = new Entry();
                sodium.Placeholder = "Sodium";
                sodium.PlaceholderColor = Color.Black;
                sodium.TextColor = Color.Black;

                Entry aluminium = new Entry();
                aluminium.Placeholder = "Aluminium";
                aluminium.PlaceholderColor = Color.Black;
                aluminium.TextColor = Color.Black;

                Entry water = new Entry();
                water.Placeholder = "Water";
                water.PlaceholderColor = Color.Black;
                water.TextColor = Color.Black;

                Entry viscosity = new Entry();
                viscosity.Placeholder = "Viscosity";
                viscosity.PlaceholderColor = Color.Black;
                viscosity.TextColor = Color.Black;
                heading.Text = "Oil Test";

                Entry comments = new Entry();
                comments.Placeholder = "Comments";
                comments.PlaceholderColor = Color.Black;
                comments.TextColor = Color.Black;

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
                        lead,
                        copper,
                        tin,
                        iron,
                        pq90,
                        silicon,
                        sodium,
                        aluminium,
                        water,
                        viscosity,
                        comments,
                        save,
                    }
                };
            }

            else
            {
                heading.Text = "Wear Test";

                heading.FontSize = 30;
                heading.TextColor = Color.Black;

                Entry description = new Entry();
                description.Placeholder = "Description";
                description.PlaceholderColor = Color.Black;
                description.TextColor = Color.Black;

                Entry @new = new Entry();
                @new.Placeholder = "Is it new?";
                @new.PlaceholderColor = Color.Black;
                @new.TextColor = Color.Black;

                Entry limit = new Entry();
                limit.Placeholder = "Limit";
                limit.PlaceholderColor = Color.Black;
                limit.TextColor = Color.Black;

                Entry lifeLower = new Entry();
                lifeLower.Placeholder = "Lower Life";
                lifeLower.PlaceholderColor = Color.Black;
                lifeLower.TextColor = Color.Black;

                Entry lifeUpper = new Entry();
                lifeUpper.Placeholder = "Upper Life";
                lifeUpper.PlaceholderColor = Color.Black;
                lifeUpper.TextColor = Color.Black;

                Entry timeStart = new Entry();
                timeStart.Placeholder = "Start Time";
                timeStart.PlaceholderColor = Color.Black;
                timeStart.TextColor = Color.Black;

                Entry uniqueDetails = new Entry();
                uniqueDetails.Placeholder = "Unique Details";
                uniqueDetails.PlaceholderColor = Color.Black;
                uniqueDetails.TextColor = Color.Black;

                Entry comments = new Entry();
                comments.Placeholder = "Comments";
                comments.PlaceholderColor = Color.Black;
                comments.TextColor = Color.Black;

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
                        description,
                        @new,
                        limit,
                        lifeLower,
                        lifeUpper,
                        timeStart,
                        uniqueDetails,
                        comments,
                        save
                    }
                };

            }
        }
    }
}