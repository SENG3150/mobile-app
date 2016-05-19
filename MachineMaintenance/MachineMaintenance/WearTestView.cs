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
            input = new List<Entry>();

            Label heading = new Label();
            heading.Text = "Wear Test";
            heading.Style = (Style)Application.Current.Resources["headingStyle"];

            description = new Entry();
            if (wearTest.description != null)
            {
                description.Placeholder = wearTest.description;
            }

            else
            {
                description.Placeholder = "Description";
            }
            description.Style = (Style)Application.Current.Resources["entryStyle"];



            @new = new Entry();
            if (wearTest.@new != null)
            {
                @new.Placeholder = wearTest.@new;
            }

            else
            {
                @new.Placeholder = "New";
            }
            @new.Style = (Style)Application.Current.Resources["entryStyle"];



            limit = new Entry();
            if (wearTest.limit != null)
            {
                limit.Placeholder = wearTest.limit;
            }

            else
            {
                limit.Placeholder = "Limit";
            }
            limit.Style = (Style)Application.Current.Resources["entryStyle"];



            lifeLower = new Entry();
            if (wearTest.lifeLower != null)
            {
                lifeLower.Placeholder = wearTest.lifeLower;
            }

            else
            {
                lifeLower.Placeholder = "Lower Life";
            }
            lifeLower.Style = (Style)Application.Current.Resources["entryStyle"];



            lifeUpper = new Entry();
            if (wearTest.lifeUpper != null)
            {
                lifeUpper.Placeholder = wearTest.lifeUpper;
            }

            else
            {
                lifeUpper.Placeholder = "Upper Life";
            }
            lifeUpper.Style = (Style)Application.Current.Resources["entryStyle"];



            timeStart = new Entry();
            if (wearTest.timeStart != null)
            {
                timeStart.Placeholder = wearTest.timeStart;
            }

            else
            {
                timeStart.Placeholder = "Start time";
            }
            timeStart.Style = (Style)Application.Current.Resources["entryStyle"];



            uniqueDetails = new Entry();
            if (wearTest.uniqueDetails != null)
            {
                uniqueDetails.Placeholder = wearTest.uniqueDetails.ToString();
            }

            else
            {
                uniqueDetails.Placeholder = "Unique Details";
            }
            uniqueDetails.Style = (Style)Application.Current.Resources["entryStyle"];



            comments = new Entry();
            if (wearTest.comments != null)
            {
                comments.Placeholder = wearTest.comments.ToString();
            }

            else
            {
                comments.Placeholder = "Comments";
            }
            comments.Style = (Style)Application.Current.Resources["entryStyle"];


            Button save = new Button();
            save.Text = "Save data";
            save.Clicked += Save_Clicked;
            save.Style = (Style)Application.Current.Resources["buttonStyle"];

            var scrollview = new ScrollView
            {
                Content = new StackLayout
                {
                    Spacing = 10,

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
                }
            };

            Content = new StackLayout
            {
                Margin = 50,

                Children =
                {
                    scrollview,
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