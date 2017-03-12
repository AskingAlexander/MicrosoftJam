using MicrosoftJam.GamePages.AlexandruP;
using MicrosoftJam.GamePages.VladO;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MicrosoftJam.MasterDetail
{
    class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public ListView listView;
        public MasterPage()
        {
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Profile",
                IconSource = "avatar.png",
                TargetType = typeof(ProfilePage)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "AlexandruP",
                IconSource = "avatar.png",
                TargetType = typeof(AlexandruP)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "VladO",
                IconSource = "avatar.png",
                TargetType = typeof(VladO)
            });

            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() => {
                    var imageCell = new ImageCell();
                    imageCell.SetBinding(TextCell.TextProperty, "Title");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
                    return imageCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };

            Padding = new Thickness(20, 20, 20, 20);
            Icon = "avatar.png";
            Title = "MicrosoftJam";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                listView
            }
            };
        }
    }
}
