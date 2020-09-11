using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GRhinoV1.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactP : ContentPage
	{
		public ContactP()
		{
			InitializeComponent();
		}

		private void btnSubmit_Clicked(object sender, EventArgs e)
		{
			try
			{
				if (!Regex.IsMatch(tbEmail.Text, "^[a - zA - Z0 - 9.!#$%&amp;'*+/=?^_`{|}~-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
				{
					ErrorMessage.Text = "Invalid Email";
					return;
				}
				Navigation.PopAsync();
			}
			catch
			{
				System.Diagnostics.Debug.WriteLine("OoF");
			}
		}
	}
}