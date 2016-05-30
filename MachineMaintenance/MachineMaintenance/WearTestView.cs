/*
    *   Title:          WearTestView.cs
    *   Purpose:        Is a Content Page where user inputs data for a wear test
    *                   Currently does not work as desired as some inputs should be obtained via the server
    *   Last Updated:   20/05/16
*/

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
        Entry smu;
        Entry uniqueDetailsType;
        Entry uniqueDetailsValue;
        Entry comments;

        Entry status;
        Entry issue;
        Entry recommendedAction;

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
            @new.Keyboard = Keyboard.Numeric;


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
            limit.Keyboard = Keyboard.Numeric;


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
            lifeLower.Keyboard = Keyboard.Numeric;


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
            lifeUpper.Keyboard = Keyboard.Numeric;

            smu = new Entry();
            if (wearTest.smu != 0)
            {
                smu.Placeholder = wearTest.smu.ToString();
            }

            else
            {
                smu.Placeholder = "SMU";
            }
            smu.Style = (Style)Application.Current.Resources["entryStyle"];
            smu.Keyboard = Keyboard.Numeric;


            uniqueDetailsType = new Entry();
            if (wearTest.uniqueDetails != null)
            {
                uniqueDetailsType.Placeholder = wearTest.uniqueDetails.ToString();
            }

            else
            {
                uniqueDetailsType.Placeholder = "Unique Details Type";
            }
            uniqueDetailsType.Style = (Style)Application.Current.Resources["entryStyle"];



            uniqueDetailsValue = new Entry();
            if (wearTest.uniqueDetails != null)
            {
                uniqueDetailsValue.Placeholder = wearTest.uniqueDetails.ToString();
            }

            else
            {
                uniqueDetailsValue.Placeholder = "Unique Details Value";
            }
            uniqueDetailsValue.Style = (Style)Application.Current.Resources["entryStyle"];
            uniqueDetailsValue.Keyboard = Keyboard.Numeric;

            comments = new Entry();
            if (wearTest.comments != null)
            {
                comments.Placeholder = wearTest.comments[0].text;
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


            Label actionItem = new Label();
            actionItem.Text = "Complete if action is required";
            actionItem.Style = (Style)Application.Current.Resources["headingStyle"];

            status = new Entry();
            if (wearTest.actionItem != null)
            {
                status.Placeholder = wearTest.actionItem.status;
            }

            else
            {
                status.Placeholder = "Status";
            }
            status.Style = (Style)Application.Current.Resources["entryStyle"];


            issue = new Entry();
            if (wearTest.actionItem != null)
            {
                issue.Placeholder = wearTest.actionItem.issue;
            }

            else
            {
                issue.Placeholder = "Issue";
            }
            issue.Style = (Style)Application.Current.Resources["entryStyle"];



            recommendedAction = new Entry();
            if (wearTest.actionItem != null)
            {
                recommendedAction.Placeholder = wearTest.actionItem.action;
            }

            else
            {
                recommendedAction.Placeholder = "Recommended Action";
            }
            recommendedAction.Style = (Style)Application.Current.Resources["entryStyle"];

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
                        smu,
                        uniqueDetailsType,
                        uniqueDetailsValue,
                        comments,
                        actionItem,
                        status,
                        issue,
                        recommendedAction,
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
            wearTest.uniqueDetails = new UniqueDetails();

            if (description.Text != null)
            {
                wearTest.description = description.Text;
            }

            if (@new.Text != null)
            {
                wearTest.@new = @new.Text;
            }

            if (limit.Text != null)
            {
                wearTest.limit = limit.Text;
            }

            if (lifeLower.Text != null)
            {
                wearTest.lifeLower = lifeLower.Text;
            }

            if (lifeUpper.Text != null)
            {
                wearTest.lifeUpper = lifeUpper.Text;
            }

            if (smu.Text != null)
            {
                wearTest.smu = Int32.Parse(smu.Text);
            }

            if (uniqueDetailsType.Text != null)
            {
                wearTest.uniqueDetails.Test = uniqueDetailsType.Text;
            }

            if (uniqueDetailsValue.Text != null)
            {
                wearTest.uniqueDetails.value = Int32.Parse(uniqueDetailsValue.Text);
            }

            wearTest.timeStart = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");

            List<User> content = App.database.getUser();
            User user = content[content.Count - 1];

            if (comments.Text != null)
            {
                wearTest.comments = new List<Comment>();

                wearTest.comments.Add(new Comment
                {
                    timeCommented = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"),
                    authorType = "Technician",
                    text = comments.Text,
                    author = user,
                });
            }

            if (status.Text != null)
            {
                wearTest.actionItem = new ActionItem();

                wearTest.actionItem.status = status.Text;
                wearTest.actionItem.issue = issue.Text;
                wearTest.actionItem.action = recommendedAction.Text;
                wearTest.actionItem.timeActioned = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
                wearTest.actionItem.technician = user;
            }

            DisplayAlert("Success", "Data has been saved", "OK");
        }
    }
}