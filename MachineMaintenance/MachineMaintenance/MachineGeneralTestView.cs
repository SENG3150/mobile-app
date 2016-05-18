using MachineMaintenance.ObjectModel;
using MachineMaintenance.Inspections;
using System.Collections.Generic;
using Xamarin.Forms;
using System;

namespace MachineMaintenance
{
    public class MachineGeneralTestView : ContentPage
    {
        private List<Entry> input;
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
            input = new List<Entry>();

            heading.Text = "General Machine Test";

            heading.FontSize = 30;
            heading.TextColor = Color.Black;

            type = new Entry();
            if (machineGeneralTest.testType != null)
            {
                type.Placeholder = machineGeneralTest.testType;
            }

            else
            {
                type.Placeholder = "Type of Test";
            }
            type.PlaceholderColor = Color.Black;
            type.TextColor = Color.Black;



            docType = new Entry();
            if (machineGeneralTest.docLink != null)
            {
                docType.Placeholder = machineGeneralTest.docLink;
            }

            else
            {
                type.Placeholder = "Type of Doc";
            }
            docType.PlaceholderColor = Color.Black;
            docType.TextColor = Color.Black;



            comments = new Entry();
            if (machineGeneralTest.comments != null)
            {
                docType.Placeholder = machineGeneralTest.comments.ToString();
            }

            else
            {
                type.Placeholder = "Comments";
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
                    type,
                    docType,
                    comments,
                    save
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