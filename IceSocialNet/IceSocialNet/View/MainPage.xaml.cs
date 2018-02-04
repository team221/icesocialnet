using IceSocialNet.Common;
using IceSocialNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IceSocialNet.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //if (Application.Current.Properties["api_key"] != null
            //    && Application.Current.Properties["auth_token"] != null
            //    && Application.Current.Properties["username"] != null)
            //{
            //    var api_key = (string)Application.Current.Properties["api_key"];
            //    var auth_token = (string)Application.Current.Properties["auth_token"];
            //    var username = (string)Application.Current.Properties["username"];

            //    List<Activity> activites = RestClientAPI.GetActivities(api_key
            //        , auth_token, username, 0, 20);

            //    if (activites != null)
            //    {
            //        //listView.ItemsSource = activites;
            //        DrawActivityUI(activites);
            //    }
            //    //DrawGridCode();
            //}

            DrawActivities();
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        private void DrawActivities()
        {
            List<Activity> lstActivities = new List<Activity>();
            var act1 = new Activity
            {
                guid = 001,
                Time_Created = "2 hours",
                Description = "IoT group",
                Owner = new Owner
                {
                    guid = 3,
                    Name = "David",
                    Username = "test1"
                },
                Like =  "like",
                Like_Count = "5",
                Comment_Count = "5"
            };
            var act2 = new Activity
            {
                guid = 001,
                Time_Created = "5 hours",
                Description = "Blockchain group",
                Owner = new Owner
                {
                    guid = 3,
                    Name = "David",
                    Username = "test1"
                },
                Like = "like",
                Like_Count = "5",
                Comment_Count = "5"
            };
            var act3 = new Activity
            {
                guid = 001,
                Time_Created = "5 hours",
                Description = "RPA group",
                Owner = new Owner
                {
                    guid = 3,
                    Name = "David",
                    Username = "test1"
                },
                Like = "like",
                Like_Count = "5",
                Comment_Count = "5"
            };

            var act4 = new Activity
            {
                guid = 001,
                Time_Created = "2 hours",
                Description = "Event about IOT market",
                Owner = new Owner
                {
                    guid = 3,
                    Name = "David",
                    Username = "test1"
                },
                Like = "like",
                Like_Count = "5",
                Comment_Count = "5"
            };
            var act5 = new Activity
            {
                guid = 001,
                Time_Created = "5 hours",
                Description = "Blockchain market",
                Owner = new Owner
                {
                    guid = 3,
                    Name = "David",
                    Username = "test1"
                },
                Like = "like",
                Like_Count = "5",
                Comment_Count = "5"
            };
            var act6 = new Activity
            {
                guid = 001,
                Time_Created = "5 hours",
                Description = "RPA market",
                Owner = new Owner
                {
                    guid = 3,
                    Name = "David",
                    Username = "test1"
                },
                Like = "like",
                Like_Count = "5",
                Comment_Count = "5"
            };

            lstActivities.Add(act1);
            lstActivities.Add(act2);
            lstActivities.Add(act3);
            lstActivities.Add(act4);
            lstActivities.Add(act5);
            lstActivities.Add(act6);

            DrawActivityUI(lstActivities);
        }

        public void DrawActivityUI(List<Activity> activites) {

            foreach (Activity act in activites)
            {
                var layout = new StackLayout();
                layout.Orientation = StackOrientation.Vertical;

                var horizontalWrapper = new StackLayout();
                horizontalWrapper.Orientation = StackOrientation.Horizontal;

                var contentWrapper = new StackLayout();
                contentWrapper.Orientation = StackOrientation.Vertical;

                var avatar = new Image();
                //avatar.SetBinding(Image.SourceProperty, act.Owner.Avatar_Url);
                avatar.Source = ImageSource.FromResource("event.png");//.FromUri(new Uri(act.Owner.Avatar_Url));

                StackLayout verticalWrapper2 = new StackLayout();
                verticalWrapper2.Orientation = StackOrientation.Vertical;

                

                StackLayout horizontalWrapper1 = new StackLayout();
                horizontalWrapper1.Orientation = StackOrientation.Horizontal;

                Label lblName = new Label();
                //lblName.SetBinding(Label.TextProperty, act.Owner.Name);
                lblName.Text = act.Owner.Name;
                lblName.TextColor = Color.Black;
                lblName.Font = Font.OfSize("SemiBold", 20);

                //Label lblEvent = new Label();
                //lblName.SetBinding(Label.TextProperty, act.Owner.Name);

                horizontalWrapper1.Children.Add(lblName);
                //horizontalWrapper1.Children.Add(lblEvent);

                StackLayout horizontalWrapper2 = new StackLayout();
                horizontalWrapper2.Orientation = StackOrientation.Horizontal;

                Label lblTime = new Label();
                //lblTime.SetBinding(Label.TextProperty, act.Time_Created);
                lblTime.Text = act.Time_Created;
                horizontalWrapper2.Children.Add(lblTime);

                verticalWrapper2.Children.Add(horizontalWrapper1);
                verticalWrapper2.Children.Add(horizontalWrapper2);

                horizontalWrapper.Children.Add(avatar);
                horizontalWrapper.Children.Add(verticalWrapper2);

                Label lblDescription = new Label();
                //lblDescription.SetBinding(Label.TextProperty, act.Description);
                lblDescription.Text = act.Description;
                lblDescription.Font = Font.OfSize("SemiBold", 20);

                contentWrapper.Children.Add(lblDescription);


                layout.Children.Add(horizontalWrapper);
                layout.Children.Add(contentWrapper);
                layout.BackgroundColor = Color.White;
                layout.HorizontalOptions = LayoutOptions.FillAndExpand;

                listItems.Children.Add(layout);
            }
        }
    }
}
