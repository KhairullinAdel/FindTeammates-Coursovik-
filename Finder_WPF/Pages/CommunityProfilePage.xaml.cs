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
    public partial class CommunityProfilePage : Page
    {
        private User user;
        private Community comm;
        public CommunityProfilePage(User incomingUser, Community incomingComm)
        {
            InitializeComponent();
            user = incomingUser;
            comm = incomingComm;
            if (user.Communities.Contains(comm.Name))
            {
                JoinToComm.Visibility = Visibility.Hidden;
                labla.Visibility = Visibility.Visible;
                CreateASession.Visibility = Visibility.Visible;
            }
        }

        private void JoinToComm_Click(object sender, RoutedEventArgs e)
        {
            user.JoinToCommunity(comm);
            DataAccess.UserSave(user);
        }

        private void CreateASession_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
