using System;
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
    /// Interaction logic for SessionCreationPage.xaml
    /// </summary>
    public partial class SessionCreationPage : Page
    {
        private int count;
        private User host;
        private Community community;
        public SessionCreationPage(User user, Community comm)
        {
            InitializeComponent();
            count = 2;
            host = user;
            community = comm;
            VisualCounter.Content = count;
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            count++;
            VisualCounter.Content = count;
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (count > 2)
            {
                count--;
                VisualCounter.Content = count;
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Session sess = new Session(host, count, community);
                DataAccess.CommumitySave(community, DataAccess.GetUser(community.OwnerTag));
                NavigationService.Navigate(new CommunityProfilePage(host, community));
            }
            catch
            {
                MessageBox.Show("You are already in a session");
                NavigationService.GoBack();
            }
            
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CommunityProfilePage(host, community));
        }
    }
}
