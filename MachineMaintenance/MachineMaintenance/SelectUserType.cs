/*
    *   Title:          SelectUserType.cs
    *   Purpose:        Is a Content Page where user selects their type before logging in
    *   Last Updated:   15/05/16
*/

using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using PCLStorage;
using MachineMaintenance.ObjectModel;

namespace MachineMaintenance
{
    public class SelectUserType : ContentPage
    {
        public SelectUserType()
        {
            loginPresentation();
        }

        //contains the presentation logic of the page
        private void loginPresentation()
        {
            BackgroundColor = Color.FromHex("#F6F6F6");
            Title = "Login";

            Button admin = new Button();
            admin.Text = "Administrator";
            admin.Style = (Style)Application.Current.Resources["buttonStyle"];
            admin.Clicked += Admin_Clicked;

            Button expert = new Button();
            expert.Text = "Domain Expert";
            expert.Style = (Style)Application.Current.Resources["buttonStyle"];
            expert.Clicked += Expert_Clicked;

            Button tech = new Button();
            tech.Text = "Technician";
            tech.Style = (Style)Application.Current.Resources["buttonStyle"];
            tech.Clicked += Tech_Clicked;
            var scrollview = new ScrollView
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Spacing = 40,
                    Margin = 50,

                    Children =
                    {
                        admin,
                        expert,
                        tech
                    }
                }
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 40,
                Margin = 50,

                Children =
                {
                    scrollview
                }
            };
        }

        //this is called when user clicks "Login"
        private void Admin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login("administrator"));
        }

        private void Expert_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login("domainExpert"));
        }

        private void Tech_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login("technician"));
        }
    }
}
