/*
    *   Title:          App.cs
    *   Purpose:        Is a Application to contains styling information and launches the mobile application
    *   Last Updated:   15/05/16
*/

using System;
using System.Windows;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.IO;
using PCLStorage;
using MachineMaintenance.Database;

namespace MachineMaintenance
{
    public class App : Application
    {
        public static LocalDatabase database;
        public App()
        {
            database = new LocalDatabase();

            var buttonStyle = new Style(typeof(Button))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = Button.FontSizeProperty, Value = 25
                    },

                    new Setter
                    {
                        Property = Button.TextColorProperty, Value = Color.White
                    },

                    new Setter
                    {
                        Property = Button.BackgroundColorProperty, Value =  Color.FromHex("#4E5C56")
                    },

                    new Setter
                    {
                        Property = Button.HeightRequestProperty, Value =  60
                    },
                }
            };

            var entryStyle = new Style(typeof(Entry))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = Entry.FontSizeProperty, Value = 25
                    },

                    new Setter
                    {
                        Property = Entry.HeightRequestProperty, Value = 30
                    },

                    new Setter
                    {
                        Property = Entry.PlaceholderColorProperty, Value = Color.Gray
                    },

                    new Setter
                    {
                        Property = Entry.TextColorProperty, Value = Color.Black
                    },
                }
            };

            var tabPageStyle = new Style(typeof(TabbedPage))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = TabbedPage.BarBackgroundColorProperty, Value = Color.FromHex("##FF8C70")
                    },

                    new Setter
                    {
                        Property = TabbedPage.BarTextColorProperty, Value = Color.Black
                    },
                }
            };

            var listStyle = new Style(typeof(ListView))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = ListView.IsPullToRefreshEnabledProperty, Value = true
                    },

                    new Setter
                    {
                        Property = ListView.SeparatorColorProperty, Value = Color.Black
                    },

                    new Setter
                    {
                        Property = ListView.RowHeightProperty, Value = 50
                    },
                }
            };

            var listLabelStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = Label.FontSizeProperty, Value = 20,
                    },

                    new Setter
                    {
                        Property = Label.TextColorProperty, Value = Color.Black,
                    },
                }
            };

            var headingStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter
                    {
                        Property = Label.FontSizeProperty, Value = 30,
                    },

                    new Setter
                    {
                        Property = Label.TextColorProperty, Value = Color.FromHex("#ff5c33"),
                    },
                }
            };

            Resources = new ResourceDictionary();
            Resources.Add("buttonStyle", buttonStyle);
            Resources.Add("entryStyle", entryStyle);
            Resources.Add("tabPageStyle", tabPageStyle);
            Resources.Add("listStyle", listStyle);
            Resources.Add("listLabelStyle", listLabelStyle);
            Resources.Add("headingStyle", headingStyle);

            MainPage = new NavigationPage(new SelectUserType())
            {
                BarBackgroundColor = Color.FromHex("#ff5c33"),
                BarTextColor = Color.Black,
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
