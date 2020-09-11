using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GRhinoV1.Model;
using GRhinoV1.Data;
using System.Text.RegularExpressions;
using GRhinoV1.View;
using GRhinoV1.Code;

namespace GRhinoV1.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        private Database db;
        App mainPage;
        public Registration(Database _db, App Mainpage)
        {
            db = _db;
            InitializeComponent();
            pckrAccount.Items.Add("Public User");
            pckrAccount.Items.Add("Employee");
            pckrAccount.Items.Add("Customer");
            pckrAccount.Items.Add("Student");
            mainPage = Mainpage;
        }

        async private void btnLogin_Clicked(object sender, EventArgs e)
        {
            mainPage.MainPage = new Login(db, mainPage);
        }

        async private void btnRegister_Clicked(object sender, EventArgs e)
        {
            try //stop application crashing if invalid
            {

                //TODO Input verification
                if (db.EmailRegistered(tbEmail.Text))
                {
                    ErrorMessage.Text = "Email already registered!";
                    return;
                }
                if (tbPassword.Text != tbConfirmPassword.Text)
                {
                    ErrorMessage.Text = "Passwords do not match";
                    return;
                }
                if (!Regex.IsMatch(tbEmail.Text, "^[a - zA - Z0 - 9.!#$%&amp;'*+/=?^_`{|}~-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
                {
                    ErrorMessage.Text = "Invalid Email";
                    return;
                }
                User user = new User()
                {
                    FirstName = tbFirstname.Text,
                    Surname = tbSurname.Text,
                    Email = tbEmail.Text,
                    Password = PasswordUtils.HashPassword(tbPassword.Text),
                    AccountType = pckrAccount.SelectedItem.ToString()
                };
                int userId = db.InsertUser(user);
                user.ID = userId;
                mainPage.MainPage = new NavigationPage(new HomeP(user));
            }
            catch
            {
                Debug.WriteLine("Error");
            }
        }
    }
}