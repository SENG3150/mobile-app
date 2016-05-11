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

namespace MachineMaintenance
{
    public class App : Application
    {

        public App()
        {
            reset();
            MainPage = new NavigationPage(new Login ());
        }

        private async void reset()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFile file = await rootFolder.CreateFileAsync("Machines.txt",
                        CreationCollisionOption.ReplaceExisting);
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
