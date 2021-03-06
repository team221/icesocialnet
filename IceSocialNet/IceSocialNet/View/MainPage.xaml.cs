﻿using IceSocialNet.Common;
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
            List<object> groups = new List<object>();
            Group group = new Group()
            {
                Guid = 66,
                Title = "IOT Group",
                Time_Create = "8 minutes 13 seconds ago",
                Description = "This group is open for IOT community to training and discuss about IoT technologies",
                Access_Id = 2,
                Members = 1,
                Is_Member = false,
                Permission_Public = true,
                Content_Access_Mode = "unrestricted",
                Icon = "group.png",
                Tags = new string[] { "IoT", "IT", "Blockchain" },
                Owner = new Owner()
                {
                    guid = 38,
                    Name = "Ice Admin",
                    Username = "admin",
                    Avatar_Url = "http://localhost/elgg/_graphics/icons/user/defaultsmall.gif"
                }
            };
            Group group1 = new Group()
            {
                Guid = 66,
                Title = "Robotics Group",
                Time_Create = "8 minutes 13 seconds ago",
                Description = "This group is open for Robotics community to training and discuss about IoT technologies",
                Access_Id = 2,
                Members = 1,
                Is_Member = false,
                Permission_Public = true,
                Content_Access_Mode = "unrestricted",
                Icon = "group.png",
                Tags = new string[] { "Robotics", "IT", "RPA" },
                Owner = new Owner()
                {
                    guid = 38,
                    Name = "Ice Admin",
                    Username = "admin",
                    Avatar_Url = "http://localhost/elgg/_graphics/icons/user/defaultsmall.gif"
                }
            };

            groups.Add(group);
            groups.Add(group1);

            Event even = new Event()
            {
                Guid = 12,
                Title = "IOT event",
                Description = "Only for IoT event",
                Icon = "event.png",
                Time_Create = "8 minutes 13 seconds ago",
                Lat = 12.02,
                Lng = 12.02,
                Owner = new Owner()
                {
                    guid = 38,
                    Name = "Ice Admin",
                    Username = "admin",
                    Avatar_Url = "http://localhost/elgg/_graphics/icons/user/defaultsmall.gif"
                }
            };

            Event even1 = new Event()
            {
                Guid = 12,
                Title = "IOT event",
                Description = "Only for Blockchain event",
                Icon = "event.png",
                Time_Create = "8 minutes 13 seconds ago",
                Lat = 12.02,
                Lng = 12.02,
                Owner = new Owner()
                {
                    guid = 38,
                    Name = "Ice Admin",
                    Username = "admin",
                    Avatar_Url = "http://localhost/elgg/_graphics/icons/user/defaultsmall.gif"
                }
            };

            groups.Add(even);
            groups.Add(even1);

            News news1 = new News()
            {
                Guid = 12,
                Title = "IOT news",
                Description = "Only for IoT news",
                Icon = "news.png",
                Time_Create = "8 minutes 13 seconds ago",
                Owner = new Owner()
                {
                    guid = 38,
                    Name = "Ice Admin",
                    Username = "admin",
                    Avatar_Url = "http://localhost/elgg/_graphics/icons/user/defaultsmall.gif"
                }
            };

            News news2 = new News()
            {
                Guid = 12,
                Title = "Blockchain news",
                Description = "Only for blockchain news",
                Icon = "news.png",
                Time_Create = "8 minutes 13 seconds ago",
                Owner = new Owner()
                {
                    guid = 38,
                    Name = "Ice Admin",
                    Username = "admin",
                    Avatar_Url = "http://localhost/elgg/_graphics/icons/user/defaultsmall.gif"
                }
            };

            News news3 = new News()
            {
                Guid = 12,
                Title = "Bitcoin news",
                Description = "Only for Bitcoin news",
                Icon = "news.png",
                Time_Create = "12 days ago",
                Owner = new Owner()
                {
                    guid = 38,
                    Name = "Ice Admin",
                    Username = "admin",
                    Avatar_Url = "http://localhost/elgg/_graphics/icons/user/defaultsmall.gif"
                }
            };

            groups.Add(news1);
            groups.Add(news2);
            groups.Add(news3);

            DrawActivityUI(groups);
        }

        public void DrawActivityUI(List<object> groups)
        {

            foreach (object act in groups)
            {
                Group group = null;
                Event evt = null;
                News news = null;
                try
                {
                    group = (Group)act;
                }
                catch (Exception ex)
                {
                    try
                    {
                        evt = (Event)act;
                    }catch(Exception exc)
                    {
                        news = (News)act;
                    }
                }
                var layout = new StackLayout();
                layout.Orientation = StackOrientation.Vertical;

                var horizontalWrapper = new StackLayout();
                horizontalWrapper.Orientation = StackOrientation.Horizontal;

                var buttonsWrapper = new StackLayout();
                buttonsWrapper.Orientation = StackOrientation.Horizontal;

                var contentWrapper = new StackLayout();
                contentWrapper.Orientation = StackOrientation.Vertical;               

                var avatar = new Image();
                //avatar.SetBinding(Image.SourceProperty, act.Owner.Avatar_Url);
                avatar.Source = group != null ? ImageSource.FromFile("group.png") 
                    : (evt != null ? ImageSource.FromFile("event.png") : ImageSource.FromFile("news.png"));//.FromUri(new Uri(act.Owner.Avatar_Url));

                StackLayout verticalWrapper2 = new StackLayout();
                verticalWrapper2.Orientation = StackOrientation.Vertical;



                StackLayout horizontalWrapper1 = new StackLayout();
                horizontalWrapper1.Orientation = StackOrientation.Horizontal;

                Label lblName = new Label();
                //lblName.SetBinding(Label.TextProperty, act.Owner.Name);
                lblName.Text = group != null ? group.Owner.Name : (evt != null ? evt.Owner.Name : news.Owner.Name);
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
                lblTime.Text = group != null ? group.Time_Create : (evt != null ? evt.Time_Create : news.Time_Create);
                horizontalWrapper2.Children.Add(lblTime);

                StackLayout horizontalWrapper3 = new StackLayout();
                horizontalWrapper3.Orientation = StackOrientation.Horizontal;
                
               // horizontalWrapper3.Children.Add(doneButton);

                verticalWrapper2.Children.Add(horizontalWrapper1);
                verticalWrapper2.Children.Add(horizontalWrapper2);
                //verticalWrapper2.Children.Add(horizontalWrapper3);

                horizontalWrapper.Children.Add(avatar);
                horizontalWrapper.Children.Add(verticalWrapper2);

                Label lblDescription = new Label();
                //lblDescription.SetBinding(Label.TextProperty, act.Description);
                lblDescription.Text = group != null ? group.Description : (evt != null ? evt.Description : news.Description);
                lblDescription.Font = Font.OfSize("SemiBold", 20);

                contentWrapper.Children.Add(lblDescription);
                contentWrapper.Children.Add(lblDescription);

                Button likeButton = new Button
                {
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    Image = "facebook_like.png",

                };

                Button chatButton = new Button
                {
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    Image = "btnChat.png",
                    IsVisible = false,                    
                };


                likeButton.Clicked += (object sender, EventArgs e) => {

                    if (likeButton.Image == "facebook_like.png") {
                        likeButton.Image = "facebook_liked.png";
                        chatButton.IsVisible = true;
                    }
                    else
                    {
                        likeButton.Image = "facebook_like.png";
                        chatButton.IsVisible = false;
                    }
                };

                chatButton.Clicked += (object sender, EventArgs e) => {

                    Navigation.PushAsync(new ChatPage());
                };

                buttonsWrapper.Children.Add(likeButton);
                buttonsWrapper.Children.Add(chatButton);

                layout.Children.Add(horizontalWrapper);
                layout.Children.Add(contentWrapper);
                layout.Children.Add(buttonsWrapper);
                layout.BackgroundColor = Color.White;
                layout.HorizontalOptions = LayoutOptions.FillAndExpand;

                listItems.Children.Add(layout);
            }
        }
    }
}
