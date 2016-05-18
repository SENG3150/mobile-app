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
            BackgroundColor = Color.White;
            Title = "Login";

            Button admin = new Button();
            admin.Text = "Administrator";
            admin.Clicked += Admin_Clicked;

            Button expert = new Button();
            expert.Text = "Domain Expert";
            expert.Clicked += Expert_Clicked;

            Button tech = new Button();
            tech.Text = "Technician";
            tech.Clicked += Tech_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Margin = 50,

                Children =
                {
                    admin,
                    expert,
                    tech
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
