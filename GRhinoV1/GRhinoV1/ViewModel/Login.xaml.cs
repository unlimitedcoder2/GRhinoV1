using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRhinoV1.Code;
using GRhinoV1.Data;
using GRhinoV1.Model;
using GRhinoV1.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GRhinoV1.ViewModel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		private Database db;
		App mainPage;
		public Login(Database _db, App Mainpage)
		{
			db = _db;
			mainPage = Mainpage;
			InitializeComponent();
		}

		async private void btnRegister_Clicked(object sender, EventArgs e)
		{
			mainPage.MainPage = new Registration(db, mainPage);
		}

		private void btnLogin_Clicked(object sender, EventArgs e)
		{
			if (!db.EmailRegistered(tbEmail.Text))
			{
				ErrorMessage.Text = "User does not exist!";
				return;
			}
			User user = db.GetUser(tbEmail.Text);
			if (PasswordUtils.CheckPasssword(user.Password, tbPassword.Text))
			{
				NavigationPage newPage = new NavigationPage(new HomeP(user));
				newPage.Title = "Golden Rhino";
				mainPage.MainPage = newPage;
				return;
			}
			ErrorMessage.Text = "Incorrect password!";
		}
	}
}