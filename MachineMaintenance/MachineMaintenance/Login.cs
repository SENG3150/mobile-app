using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MachineMaintenance
{
    public class Login : ContentPage
    {
        public Login()
        {
            BackgroundColor = Color.White;

            Entry username = new Entry();
            username.Placeholder = "Username";
            username.PlaceholderColor = Color.Black;
            username.TextColor = Color.Black;

            Entry password = new Entry();
            password.Placeholder = "Password";
            password.PlaceholderColor = Color.Black;
            password.IsPassword = true;
            password.TextColor = Color.Black;

            Button login = new Button();
            login.Text = "Login";
            login.Clicked += Login_Clicked;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Margin = 50,

                Children =
                {
                    username,
                    password,
                    login
                }
            };
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            await this.authenticateLogin();
        }

        public async Task authenticateLogin()
        {
            try
            {
                using (var c = new HttpClient())
                {
                    var client = new HttpClient();
                    var jsonRequest = new
                    {
                        type = "administrator", username = "administrator", password = "administrator"
                    };

                    var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);
                    HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");
                    Uri apiSite = new Uri("http://seng3150.wingmanwebdesign.com.au/auth/authenticate");

                    var response = await client.PostAsync(apiSite, content);

                    if (response.IsSuccessStatusCode)
                    {
                        await Navigation.PushAsync(new Menu());
                    }
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}