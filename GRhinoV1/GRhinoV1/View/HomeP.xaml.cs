using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRhinoV1.Data;
using GRhinoV1.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GRhinoV1.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeP : ContentPage
	{
		private User user;
		public HomeP(User _user)
		{
			user = _user;
			InitializeComponent();
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			if (sender.GetType() != typeof(Frame))
			{
				Debug.WriteLine("Not a frame");
				return;
			}
			Frame frame = sender as Frame;
			if (frame == Games)
			{
				await Navigation.PushAsync(new GamesP());
			}
			else if (frame == About)
			{
				await Navigation.PushAsync(new AboutP());
			}
			else if (frame == Contact)
			{
				await Navigation.PushAsync(new ContactP());
			}
		}
	}
}