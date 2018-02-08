using IceSocialNet.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IceSocialNet.View.User
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InterestingPage : ContentPage
	{
		public InterestingPage ()
		{
			InitializeComponent ();

            DrawInterestingPage();
		}

        async void OnDoneButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }

            private void DrawInterestingPage()
        {
            ObservableCollection<Interest> lstInterest = new ObservableCollection<Interest>();

            Interest int1 = new Interest()
            {
                Name = "IoT"
            };

            Interest int2 = new Interest()
            {
                Name = "Blockchain"
            };

            Interest int3 = new Interest()
            {
                Name = "Robotics"
            };

            Interest int4 = new Interest()
            {
                Name = "Optical Character Recognize"
            };

            lstInterest.Add(int1);
            lstInterest.Add(int2);
            lstInterest.Add(int3);
            lstInterest.Add(int4);

            interstingView.ItemsSource = lstInterest;
        }
    }
}