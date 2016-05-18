using MachineMaintenance.ObjectModel;
using MachineMaintenance.Inspections;
using System.Collections.Generic;
using Xamarin.Forms;
using System;

namespace MachineMaintenance
{
    public class WearTestView : ContentPage
    {
        private List<Entry> input;
        WearTest wearTest;

        Entry description;
        Entry @new;
        Entry limit;
        Entry lifeLower;
        Entry lifeUpper;
        Entry timeStart;
        Entry uniqueDetails;
        Entry comments;

        public WearTestView(WearTest wearTest)
        {
            this.wearTest = wearTest;
            testPresentation();
        }

        private void testPresentation()
        {
            Label heading = new Label();
            input = new List<Entry>();

            heading.Text = "Wear Test";

            heading.FontSize = 30;
            heading.TextColor = Color.Black;

            description = new Entry();
            if (wearTest.description != null)
            {
                description.Placeholder = wearTest.description;
            }

            else
            {
                description.Placeholder = "Description";
            }
            description.PlaceholderColor = Color.Black;
            description.TextColor = Color.Black;



            @new = new Entry();
            if (wearTest.@new != null)
            {
                @new.Placeholder = wearTest.@new;
            }

            else
            {
                @new.Placeholder = "New";
            }
            @new.PlaceholderColor = Color.Black;
            @new.TextColor = Color.Black;



            limit = new Entry();
            if (wearTest.limit != null)
            {
                limit.Placeholder = wearTest.limit;
            }

            else
            {
                limit.Placeholder = "Limit";
            }
            limit.PlaceholderColor = Color.Black;
            limit.TextColor = Color.Black;



            lifeLower = new Entry();
            if (wearTest.lifeLower != null)
            {
                lifeLower.Placeholder = wearTest.lifeLower;
            }

            else
            {
                lifeLower.Placeholder = "Lower Life";
            }
            lifeLower.PlaceholderColor = Color.Black;
            lifeLower.TextColor = Color.Black;



            lifeUpper = new Entry();
            if (wearTest.lifeUpper != null)
            {
                lifeUpper.Placeholder = wearTest.lifeUpper;
            }

            else
            {
                lifeUpper.Placeholder = "Upper Life";
            }
            lifeUpper.PlaceholderColor = Color.Black;
            lifeUpper.TextColor = Color.Black;



            timeStart = new Entry();
            if (wearTest.timeStart != null)
            {
                timeStart.Placeholder = wearTest.timeStart;
            }

            else
            {
                timeStart.Placeholder = "Start time";
            }
            timeStart.PlaceholderColor = Color.Black;
            timeStart.TextColor = Color.Black;



            uniqueDetails = new Entry();
            if (wearTest.uniqueDetails != null)
            {
                uniqueDetails.Placeholder = wearTest.uniqueDetails.ToString();
            }

            else
            {
                uniqueDetails.Placeholder = "Unique Details";
            }
            uniqueDetails.PlaceholderColor = Color.Black;
            uniqueDetails.TextColor = Color.Black;



            comments = new Entry();
            if (wearTest.comments != null)
            {
                comments.Placeholder = wearTest.comments.ToString();
            }

            else
            {
                comments.Placeholder = "Comments";
            }
            comments.PlaceholderColor = Color.Black;
            comments.TextColor = Color.Black;


            Button save = new Button();
            save.Text = "Save data";
            save.Clicked += Save_Clicked;

            Content = new StackLayout
            {
                Margin = 50,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                Children =
                {
                    heading,
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

        private void Save_Clicked(object sender, EventArgs e)
        {
            wearTest.description = description.Text;
            wearTest.@new = @new.Text;
            wearTest.limit = limit.Text;
            wearTest.lifeLower = lifeLower.Text;
            wearTest.lifeUpper = lifeUpper.Text;
            wearTest.uniqueDetails = new List<string>();
            wearTest.uniqueDetails.Add(uniqueDetails.Text);
        }
    }
}