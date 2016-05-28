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
                comments.Placeholder = oilTest.comments.ToString();
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
            oilTest.lead = Int32.Parse(lead.Text);
            oilTest.copper = Int32.Parse(copper.Text);
            oilTest.tin = Int32.Parse(tin.Text);
            oilTest.iron = Int32.Parse(iron.Text);
            oilTest.pq90 = Int32.Parse(pq90.Text);
            oilTest.silicon = Int32.Parse(silicon.Text);
            oilTest.sodium = Int32.Parse(sodium.Text);
            oilTest.aluminium = Int32.Parse(aluminium.Text);
            oilTest.water = water.Text;
            oilTest.viscosity = Int32.Parse(viscosity.Text);
            oilTest.comments = new List<Comment>();

            List<User> content = App.database.getUser();
            User user = content[content.Count - 1];

            oilTest.comments.Add(new Comment
            {
                timeCommented = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"),
                authorType = "Technician",
                text = comments.Text,
                author = user,
            });
        }

    }
}