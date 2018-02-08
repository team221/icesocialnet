using IceSocialNet.Common;
using IceSocialNet.Model;
using IceSocialNet.ViewModels;
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

        ObservableCollection<ListViewModel> ListItems { get; set; } = new ObservableCollection<ListViewModel> {
            new ListViewModel{Text = "IoT"},
            new ListViewModel{Text = "Blockchain"},
            new ListViewModel{Text = "Robotics"},
            new ListViewModel{Text = "OCR (Optical Character Recognize)"},
        };

        ListView ListView { get; set; }

        private void DrawInterestingPage()
        {

            ListView = new ListView();
            ListView.ItemsSource = ListItems;
            ListView.ItemTemplate = new DataTemplate(typeof(CustomCell));
            ListView.ItemTapped += MenuListView_ItemTapped;            


            var ListViewLayout = new StackLayout() {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            ListViewLayout.Padding = new Thickness(10, 20);
            ListViewLayout.Children.Add(ListView);

            Button doneButton = new Button
            {
                Text = "DONE",
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                
            };
            ListViewLayout.Children.Add(doneButton);

            doneButton.Clicked += async (sender, args) =>
            {
                SaveSelection2Server();

                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            };

            InterestingScrollView.Content = ListViewLayout;
        }

        private void SaveSelection2Server() {
            //TODO Save data after selected to the database.
        }

        void MenuListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if ((sender as ListView).SelectedItem == null)
                return;
            (sender as ListView).SelectedItem = null;

            var item = e.Item as ListViewModel;
            if (item.IsSelected)
                item.IsSelected = false;
            else
                item.IsSelected = true;
        }
    }
}