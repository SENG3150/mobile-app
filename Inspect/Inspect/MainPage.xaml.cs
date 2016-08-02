using Inspect.Data;
using Inspect.Models;
using Xamarin.Forms;

namespace Inspect
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            IRestService restService = new RestService();
            restService.Authenticate(new LoginDetails()
            {
                UserType = "administrator",
                Username = "administrator",
                Password = "administrator"
            });
        }
    }
}
