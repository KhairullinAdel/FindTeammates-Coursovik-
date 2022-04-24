﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Finder_Core;
using Finder_Core.FireBase;

namespace Finder_WPF
{
    /// <summary>
    /// Interaction logic for RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void SaveNewUser(object sender, RoutedEventArgs e)
        {
            User user = new User(UserNameBox.Text, LoginBox.Text);

            user.AddSocials("Discord", "adadsadas");
            user.AddSocials("Discordq", "adadsadas");
            user.AddSocials("Discorqd", "adadsadas");

            FBaseUser.UserSave(user);

            MessageBox.Show("Creating new user is success");
        }
    }
}