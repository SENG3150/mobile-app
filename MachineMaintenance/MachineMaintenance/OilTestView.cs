/*
    *   Title:          OilTestView.cs
    *   Purpose:        Is a Content Page where user inputs data for a oil test
    *   Last Updated:   20/05/16
*/

using MachineMaintenance.ObjectModel;
using MachineMaintenance.Inspections;
using System.Collections.Generic;
using Xamarin.Forms;
using System;

namespace MachineMaintenance
{
    public class OilTestView : ContentPage
    {
        private List<Entry> input;
        OilTest oilTest;

        Entry lead;
        Entry copper;
        Entry tin;
        Entry iron;
        Entry pq90;
        Entry silicon;
        Entry sodium;
        Entry aluminium;
        Entry water;
        Entry viscosity;
        Entry comments;

        Entry status;
        Entry issue;
        Entry recommendedAction;

        public OilTestView(OilTest oilTest)
        {
            this.oilTest = oilTest;
            testPresentation();
        }

        private void testPresentation()
        {

            input = new List<Entry>();

            Label heading = new Label();
            heading.Text = "Oil";
            heading.Style = (Style)Application.Current.Resources["headingStyle"];

            lead = new Entry();
            if (oilTest.lead != 0)
            {
                lead.Placeholder = oilTest.lead.ToString();
            }

            else
            {
                lead.Placeholder = "Lead";
            }
            lead.Style = (Style)Application.Current.Resources["entryStyle"];
            lead.Keyboard = Keyboard.Numeric;



            copper = new Entry();
            if (oilTest.copper != 0)
            {
                copper.Placeholder = oilTest.copper.ToString();
            }

            else
            {
                copper.Placeholder = "Copper";
            }
            copper.Style = (Style)Application.Current.Resources["entryStyle"];
            copper.Keyboard = Keyboard.Numeric;


            tin = new Entry();
            if (oilTest.tin != 0)
            {
                tin.Placeholder = oilTest.tin.ToString();
            }

            else
            {
                tin.Placeholder = "Tin";
            }
            tin.Style = (Style)Application.Current.Resources["entryStyle"];
            tin.Keyboard = Keyboard.Numeric;



            iron = new Entry();
            if (oilTest.iron != 0)
            {
                iron.Placeholder = oilTest.iron.ToString();
            }

            else
            {
                iron.Placeholder = "Iron";
            }
            iron.Style = (Style)Application.Current.Resources["entryStyle"];
            iron.Keyboard = Keyboard.Numeric;


            pq90 = new Entry();
            if (oilTest.pq90 != 0)
            {
                pq90.Placeholder = oilTest.pq90.ToString();
            }

            else
            {
                pq90.Placeholder = "pq90";
            }
            pq90.Style = (Style)Application.Current.Resources["entryStyle"];
            pq90.Keyboard = Keyboard.Numeric;



            silicon = new Entry();
            if (oilTest.silicon != 0)
            {
                silicon.Placeholder = oilTest.silicon.ToString();
            }

            else
            {
                silicon.Placeholder = "Silicon";
            }
            silicon.Style = (Style)Application.Current.Resources["entryStyle"];
            silicon.Keyboard = Keyboard.Numeric;


            sodium = new Entry();
            if (oilTest.sodium != 0)
            {
                sodium.Placeholder = oilTest.sodium.ToString();
            }

            else
            {
                sodium.Placeholder = "Sodium";
            }
            sodium.Style = (Style)Application.Current.Resources["entryStyle"];
            sodium.Keyboard = Keyboard.Numeric;



            aluminium = new Entry();
            if (oilTest.aluminium != 0)
            {
                aluminium.Placeholder = oilTest.aluminium.ToString();
            }

            else
            {
                aluminium.Placeholder = "Aluminium";
            }
            aluminium.Style = (Style)Application.Current.Resources["entryStyle"];
            aluminium.Keyboard = Keyboard.Numeric;



            water = new Entry();
            if (oilTest.water != null)
            {
                water.Placeholder = oilTest.water;
            }

            else
            {
                water.Placeholder = "Water";
            }
            water.Style = (Style)Application.Current.Resources["entryStyle"];
            water.Keyboard = Keyboard.Numeric;



            viscosity = new Entry();
            if (oilTest.viscosity != 0)
            {
                viscosity.Placeholder = oilTest.viscosity.ToString();
            }

            else
            {
                viscosity.Placeholder = "Viscosity";
            }
            viscosity.Style = (Style)Application.Current.Resources["entryStyle"];
            viscosity.Keyboard = Keyboard.Numeric;


            comments = new Entry();
            if (oilTest.comments != null)
            {
                comments.Placeholder = oilTest.comments[0].text;
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
            if (oilTest.actionItem != null)
            {
                status.Placeholder = oilTest.actionItem.status;
            }

            else
            {
                status.Placeholder = "Status";
            }
            status.Style = (Style)Application.Current.Resources["entryStyle"];


            issue = new Entry();
            if (oilTest.actionItem != null)
            {
                issue.Placeholder = oilTest.actionItem.issue;
            }

            else
            {
                issue.Placeholder = "Issue";
            }
            issue.Style = (Style)Application.Current.Resources["entryStyle"];



            recommendedAction = new Entry();
            if (oilTest.actionItem != null)
            {
                recommendedAction.Placeholder = oilTest.actionItem.action;
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
                        actionItem,
                        status,
                        issue,
                        recommendedAction,
                        save,
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
            if (lead.Text != null)
            {
                oilTest.lead = Int32.Parse(lead.Text);
            }

            if (copper.Text != null)
            {
                oilTest.copper = Int32.Parse(copper.Text);
            }

            if (tin.Text != null)
            {
                oilTest.tin = Int32.Parse(tin.Text);
            }

            if (iron.Text != null)
            {
                oilTest.iron = Int32.Parse(iron.Text);
            }

            if (pq90.Text != null)
            {
                oilTest.pq90 = Int32.Parse(pq90.Text);
            }

            if (silicon.Text != null)
            {
                oilTest.silicon = Int32.Parse(silicon.Text);
            }

            if (sodium.Text != null)
            {
                oilTest.sodium = Int32.Parse(sodium.Text);
            }

            if (aluminium.Text != null)
            {
                oilTest.aluminium = Int32.Parse(aluminium.Text);
            }

            if (water.Text != null)
            {
                oilTest.water = water.Text;
            }

            if (viscosity.Text != null)
            {
                oilTest.viscosity = Int32.Parse(viscosity.Text);
            }

            List<User> content = App.database.getUser();
            User user = content[content.Count - 1];

            if (comments.Text != null)
            {
                oilTest.comments = new List<Comment>();
                
                oilTest.comments.Add(new Comment
                {
                    timeCommented = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"),
                    authorType = "Technician",
                    text = comments.Text,
                    author = user,
                });
            }

            if (status.Text != null)
            {
                oilTest.actionItem = new ActionItem();

                oilTest.actionItem.status = status.Text;
                oilTest.actionItem.issue = issue.Text;
                oilTest.actionItem.action = recommendedAction.Text;
                oilTest.actionItem.timeActioned = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
                oilTest.actionItem.technician = user;
            }
        }
    }
}