using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using PCLStorage;
using MachineMaintenance.ObjectModel;
using System.Net.Http.Headers;

namespace MachineMaintenance
{
    public class Login : ContentPage
    {
        Entry username;
        Entry password;
        String userType;

        public Login(String userType)
        {
            loginPresentation();
            this.userType = userType;
        }

        //contains the presentation logic of the page
        private void loginPresentation()
        {
            BackgroundColor = Color.White;
            Title = "Welcome: " + userType;

            username = new Entry();
            username.Placeholder = "Username";
            username.Style = (Style)Application.Current.Resources["entryStyle"];

            password = new Entry();
            password.Placeholder = "Password";
            password.Style = (Style)Application.Current.Resources["entryStyle"];
            password.IsPassword = true;

            Button login = new Button();
            login.Text = "Login";
            login.Style = (Style)Application.Current.Resources["buttonStyle"];
            login.Clicked += Login_Clicked;


            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 30,
                Margin = 50,

                Children =
                {
                    username,
                    password,
                    login
                }
            };
        }

        //this is called when user clicks "Login"
        private async void Login_Clicked(object sender, EventArgs e)
        {
            await this.authenticateLogin();
        }

        //authenticate the user's input. At this stage, literally changes all values to administrator
        private async Task authenticateLogin()
        {
            try
            {
                using (var c = new HttpClient())
                {
                    var client = new HttpClient();
                    var jsonRequest = new
                    {
                        type = userType, username = username.Text, password = password.Text
                    };

                    var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);       //saves login information as a string
                    HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");  //encodes login information
                    Uri apiSite = new Uri("http://seng3150-api.wingmanwebdesign.com.au/auth/authenticate");

                    var response = await client.PostAsync(apiSite, content);        //attempts to login

                    if (response.IsSuccessStatusCode) //login worked
                    {
                        var bearer = await response.Content.ReadAsStringAsync();    //retrieve the content
                        Token token = JsonConvert.DeserializeObject<Token>(bearer);

                        App.database.storeToken(token);

                        client = new HttpClient();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.token);
                        Uri site = new Uri("http://seng3150-api.wingmanwebdesign.com.au/auth/me");

                        response = await client.GetAsync(site);
                        if (response.IsSuccessStatusCode)
                        {
                            var value = await response.Content.ReadAsStringAsync();
                            User user = JsonConvert.DeserializeObject<User>(value);

                            App.database.storeUser(user);
                        }

                        await Navigation.PushAsync(new Menu());
                    }

                    else //atm, all error codes under 1 else statement, should fix this at some point
                    {
                        await DisplayAlert("Error", "Ensure you are connected to the internet. If so, server may be experiencing difficulties", "I promise not to sue!");
                        await Navigation.PushAsync(new SelectUserType());
                    }
                }
                Navigation.RemovePage(this);
            }

            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

    }
}