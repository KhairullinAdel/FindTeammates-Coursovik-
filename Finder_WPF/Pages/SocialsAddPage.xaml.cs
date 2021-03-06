using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Finder_Core;
using Finder_Core.FireBase;

namespace Finder_WPF.Pages
{
    public partial class SocialsAddPage : Page
    {
        static User user;
        static List<String> socialsList;
        public SocialsAddPage(User newUser)
        {
            InitializeComponent();
            user = newUser;
            socialsList = new List<string>
            { 
                "Discord",
                "Telegram"
            };
            SocialCb.ItemsSource = socialsList;
            this.DataContext = this;
        }

        private void RegConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            user.AddSocials(SocialCb.SelectedItem.ToString(), Social.Text);

            DataAccess.UserSave(user);
            MessageBox.Show("Creating new user is success");

            NavigationService.Navigate(new UserProfilePage(user));
        }

        private void GoBackToRegPage(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
