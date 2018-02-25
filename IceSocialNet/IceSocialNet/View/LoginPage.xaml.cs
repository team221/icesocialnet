using FacebookLogin.Views;
using IceSocialNet.Common;
using IceSocialNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IceSocialNet.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            

        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var account = new Account
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(account);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                //Navigation.InsertPageBefore(new User.InterestingPage(), this);
                //await Navigation.PopAsync();
                await Navigation.PushAsync(new User.InterestingPage());
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        private async void LoginWithFacebook_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FacebookProfileCsPage());
        }

        bool AreCredentialsCorrect(Account account)
        {
            //LoginToken token = RestClientAPI.Login(account.Username, account.Password);

            //if (token != null)
            //{
            //    Application.Current.Properties["api_key"] = token.api_key;
            //    Application.Current.Properties["auth_token"] = token.auth_token;
            //    Application.Current.Properties["username"] = token.username;

            //    return true;
            //}
            //return false;
            if (account.Username.Equals("admin") && account.Password.Equals("admin"))
                return true;
            else
                return false;
        }
    }
}