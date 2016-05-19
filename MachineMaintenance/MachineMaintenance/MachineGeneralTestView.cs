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
                docType.Placeholder = machineGeneralTest.comments.ToString();
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
        }

    }
}