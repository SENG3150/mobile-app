using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using PCLStorage;

namespace MachineMaintenance
{
    public class Login : ContentPage
    {
        public Login()
        {
            loginPresentation();
        }

        //contains the presentation logic of the page
        private void loginPresentation()
        {
            BackgroundColor = Color.White;
            Title = "Login";

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
                        type = "administrator", username = "administrator", password = "administrator"
                    };

                    var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);       //saves login information as a string
                    HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");  //encodes login information
                    Uri apiSite = new Uri("http://seng3150-api.wingmanwebdesign.com.au/auth/authenticate");

                    var response = await client.PostAsync(apiSite, content);        //attempts to login

                    if (response.IsSuccessStatusCode) //login worked
                    {
                        var bearer = await response.Content.ReadAsStringAsync();    //retrieve the content
                        ObjectModel.Token token = JsonConvert.DeserializeObject<ObjectModel.Token>(bearer);

                        IFolder rootFolder = FileSystem.Current.LocalStorage;
                        IFile file = await rootFolder.CreateFileAsync("Token.txt",
                            CreationCollisionOption.ReplaceExisting);               //create a token.txt file to save the token - should be stored in db once working
                        await file.WriteAllTextAsync(token.token);
                        await Navigation.PushAsync(new Menu());
                    }

                    else //atm, all error codes under 1 else statement, should fix this at some point
                    {
                        await DisplayAlert("Error", "Ensure you are connected to the internet. If so, server may be experiencing difficulties", "I promise not to sue!");
                        await Navigation.PushAsync(new Login());
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