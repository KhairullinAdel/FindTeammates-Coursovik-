using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Finder_Core;
using Finder_Core.FireBase;

namespace Finder_WPF
{
    public partial class CommunityProfilePage : Page
    {
        private User user;
        private Community comm;
        private List<Session> sesses;
        private Session actualSession;
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

            if (user.ActiveSession != null)
            {
                actualSession = DataAccess.GetSession(user.ActiveSession);
                SessionPanel.Visibility = Visibility.Visible;
                HostNameLabel.Content += actualSession.SessionHost.Name;
                HostContactsLabel.Content += actualSession.SessionHost.Socials.Values.ToString();
            }

            CommunityName.Text = comm.Name;
            UserCount.Text = "Users count: " + comm.UsersCount.ToString();
            sesses = new List<Session>();

            foreach (var s in comm.SessionList)
            {
                sesses.Add(DataAccess.GetSession(s));
            }

            SessList.ItemsSource = sesses;
        }

        private void JoinToComm_Click(object sender, RoutedEventArgs e)
        {
            user.JoinToCommunity(comm);
            DataAccess.UserSave(user);
            NavigationService.Navigate(new UserProfilePage(user));
        }

        private void CreateASession_Click(object sender, RoutedEventArgs e)
        {
            if (actualSession == null)
            {
                NavigationService.Navigate(new SessionCreationPage(user, comm));

            }
            else
            {
                MessageBox.Show("You are in a session already");
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserProfilePage(user));
        }

        private void SessList_Selected(object sender, RoutedEventArgs e)
        {
            if (actualSession == null)
            {
                user.JoinToSession(SessList.SelectedItem as Session);
                NavigationService.Navigate(new CommunityProfilePage(user, comm));
            }
        }

        private void SessLeaveButton_Click(object sender, RoutedEventArgs e)
        {
            user.LeaveFromSession();
            NavigationService.Navigate(new CommunityProfilePage(user, 
                DataAccess.GetCommunity(comm.Name)));
        }
    }
}
