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
            Label heading = new Label();
            input = new List<Entry>();

            heading.Text = "Oil";

            heading.FontSize = 30;
            heading.TextColor = Color.Black;

            lead = new Entry();
            if (oilTest.lead != 0)
            {
                lead.Placeholder = oilTest.lead.ToString();
            }

            else
            {
                lead.Placeholder = "Lead";
            }
            lead.PlaceholderColor = Color.Black;
            lead.TextColor = Color.Black;



            copper = new Entry();
            if (oilTest.copper != 0)
            {
                copper.Placeholder = oilTest.copper.ToString();
            }

            else
            {
                copper.Placeholder = "Copper";
            }
            copper.PlaceholderColor = Color.Black;
            copper.TextColor = Color.Black;



            tin = new Entry();
            if (oilTest.tin != 0)
            {
                tin.Placeholder = oilTest.tin.ToString();
            }

            else
            {
                tin.Placeholder = "Tin";
            }
            tin.PlaceholderColor = Color.Black;
            tin.TextColor = Color.Black;



            iron = new Entry();
            if (oilTest.iron != 0)
            {
                iron.Placeholder = oilTest.iron.ToString();
            }

            else
            {
                iron.Placeholder = "Iron";
            }
            iron.PlaceholderColor = Color.Black;
            iron.TextColor = Color.Black;

            pq90 = new Entry();
            if (oilTest.pq90 != 0)
            {
                pq90.Placeholder = oilTest.pq90.ToString();
            }

            else
            {
                pq90.Placeholder = "pq90";
            }
            pq90.PlaceholderColor = Color.Black;
            pq90.TextColor = Color.Black;



            silicon = new Entry();
            if (oilTest.silicon != 0)
            {
                silicon.Placeholder = oilTest.silicon.ToString();
            }

            else
            {
                silicon.Placeholder = "Silicon";
            }
            silicon.PlaceholderColor = Color.Black;
            silicon.TextColor = Color.Black;



            sodium = new Entry();
            if (oilTest.sodium != 0)
            {
                sodium.Placeholder = oilTest.sodium.ToString();
            }

            else
            {
                sodium.Placeholder = "Sodium";
            }
            sodium.PlaceholderColor = Color.Black;
            sodium.TextColor = Color.Black;



            aluminium = new Entry();
            if (oilTest.aluminium != 0)
            {
                aluminium.Placeholder = oilTest.aluminium.ToString();
            }

            else
            {
                aluminium.Placeholder = "Aluminium";
            }
            aluminium.PlaceholderColor = Color.Black;
            aluminium.TextColor = Color.Black;



            water = new Entry();
            if (oilTest.water != null)
            {
                water.Placeholder = oilTest.water;
            }

            else
            {
                water.Placeholder = "Water";
            }
            water.PlaceholderColor = Color.Black;
            water.TextColor = Color.Black;



            viscosity = new Entry();
            if (oilTest.viscosity != 0)
            {
                viscosity.Placeholder = oilTest.viscosity.ToString();
            }

            else
            {
                viscosity.Placeholder = "Viscosity";
            }
            viscosity.PlaceholderColor = Color.Black;
            viscosity.TextColor = Color.Black;



            comments = new Entry();
            if (oilTest.comments != null)
            {
                comments.Placeholder = oilTest.comments.ToString();
            }

            else
            {
                comments.Placeholder = "Comments";
            }
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
        }

    }
}