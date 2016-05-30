/*
    *   Title:          MachineGeneralTestView.cs
    *   Purpose:        Is a Content Page where user inputs data for a machine general test
    *                   Currently does not work as the server at this stage does not provide the required information
    *   Last Updated:   20/05/16
*/

using MachineMaintenance.ObjectModel;
using MachineMaintenance.Inspections;
using System.Collections.Generic;
using Xamarin.Forms;
using System;

namespace MachineMaintenance
{
    public class MachineGeneralTestView : ContentPage
    {
        MachineGeneralTest machineGeneralTest;
        Entry type;
        Entry docType;
        Entry comments;

        public MachineGeneralTestView(MachineGeneralTest machineGeneralTest)
        {
            this.machineGeneralTest = machineGeneralTest;
            testPresentation();
        }

        private void testPresentation()
        {
            Label heading = new Label();
            heading.Text = "General Machine Test";
            heading.Style = (Style)Application.Current.Resources["headingStyle"];

            type = new Entry();
            if (machineGeneralTest.testType != null)
            {
                type.Placeholder = machineGeneralTest.testType;
            }

            else
            {
                type.Placeholder = "Type of Test";
            }
            type.Style = (Style)Application.Current.Resources["entryStyle"];



            docType = new Entry();
            if (machineGeneralTest.docLink != null)
            {
                docType.Placeholder = machineGeneralTest.docLink;
            }

            else
            {
                type.Placeholder = "Type of Doc";
            }
            docType.Style = (Style)Application.Current.Resources["entryStyle"];



            comments = new Entry();
            if (machineGeneralTest.comments != null)
            {
                docType.Placeholder = machineGeneralTest.comments[0].ToString();
            }

            else
            {
                type.Placeholder = "Comments";
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
                        type,
                        docType,
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
            machineGeneralTest.testType = type.Text;
            machineGeneralTest.docLink = docType.Text;
            machineGeneralTest.comments = new List<Comment>();

            List<User> content = App.database.getUser();
            User user = content[content.Count - 1];

            machineGeneralTest.comments.Add(new Comment
            {
                timeCommented = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"),
                authorType = "Technician",
                text = comments.Text,
                author = user,
            });

            DisplayAlert("Success", "Data has been saved", "OK");
        }

    }
}