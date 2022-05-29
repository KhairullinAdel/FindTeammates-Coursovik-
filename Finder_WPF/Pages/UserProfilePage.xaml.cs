using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Finder_Core;
using Finder_Core.FireBase;

namespace Finder_WPF
{
    /// <summary>
    /// Interaction logic for UserProfilePage.xaml
    /// </summary>
    public partial class UserProfilePage : Page
    {
        public List<Community> coms { get; set; }
        User authorisedUser;
        public UserProfilePage(User user)
        {
            InitializeComponent();

            Username.Text = user.Name;

            coms = DataAccess.GetCommByUser(user);

            authorisedUser = user;
            this.DataContext = this;
        }

        private void CreateComm_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateNewCommunity(authorisedUser));
        }

        private void JoinToComm_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CommunitiesListPage(authorisedUser));
        }

        private void GroupList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comm = GroupList.SelectedItem as Community;
            NavigationService.Navigate(new CommunityProfilePage(authorisedUser, comm));
        }
    }
}
