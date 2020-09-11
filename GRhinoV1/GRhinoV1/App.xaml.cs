using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using GRhinoV1.Data;
using GRhinoV1.ViewModel;
using GRhinoV1.View;
namespace GRhinoV1
{
    public partial class App : Application
    {

        public static Database db; 
        
        public App()
        {
            //InitializeComponent();
            //NavigationPage navigationPage = new NavigationPage(new HomeP());
            db = new Database("GRV1.db3");
            MainPage = new Registration(db, this); //new HomeP();
            //Registration registrationPage = new Registration();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void InitializeComponent()
        {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(App));
        }
    }
}
