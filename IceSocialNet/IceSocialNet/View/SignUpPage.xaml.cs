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
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var account = new Account()
            {
                Name = nameEntry.Text,
                Username = usernameEntry.Text,
                Password = passwordEntry.Text,
                Email = emailEntry.Text
            };

            // Sign up logic goes here

            var areDetailsValid = AreDetailsValid(account);
            var areCreateAccountSuccess = AreDetailsValid(account);
            if (areDetailsValid && areCreateAccountSuccess)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
            }
            else
            {
                messageLabel.Text = "Sign up failed";
            }
        }

        bool AreDetailsValid(Account account)
        {
            return (!string.IsNullOrWhiteSpace(account.Username) && !string.IsNullOrWhiteSpace(account.Password) && !string.IsNullOrWhiteSpace(account.Email) && account.Email.Contains("@"));
        }
        bool AreCreateAccountSuccess(Account account)
        {
            //if (Application.Current.Properties["api_key"] != null
            //    && Application.Current.Properties["auth_token"] != null
            //    && Application.Current.Properties["username"] != null)
            //{
            //    var api_key = (string)Application.Current.Properties["api_key"];
            //    var auth_token = (string)Application.Current.Properties["auth_token"];
            //    var username = (string)Application.Current.Properties["username"];

            //    Result result = RestClientAPI.CreateAccount(api_key, account.Username, account.Password
            //        , account.Name, account.Email);

            //    return result.success;
            //}

            //return false;
            return true;
        }

    }
}