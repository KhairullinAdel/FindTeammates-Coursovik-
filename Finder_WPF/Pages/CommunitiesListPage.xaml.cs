using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Finder_Core;
using Finder_Core.FireBase;

namespace Finder_WPF
{
    /// <summary>
    /// Interaction logic for CommunitiesListPage.xaml
    /// </summary>
    public partial class CommunitiesListPage : Page
    {
        public List<Community> coms { get; set; }
        User authorisedUser;
        public CommunitiesListPage(User user)
        {
            InitializeComponent();
            coms = DataAccess.GetCommunities();
            authorisedUser = user;
            this.DataContext = this;
        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void GroupList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new CommunityProfilePage(
                authorisedUser, GroupList.SelectedItem as Community));

        }
    }
}
