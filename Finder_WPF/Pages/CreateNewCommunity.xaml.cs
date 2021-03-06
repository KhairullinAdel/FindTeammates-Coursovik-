using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Finder_Core;
using Finder_Core.FireBase;

namespace Finder_WPF
{
    /// <summary>
    /// Interaction logic for CreateNewCommunity.xaml
    /// </summary>
    public partial class CreateNewCommunity : Page
    {
        User user;
        public CreateNewCommunity(User userCreator)
        {
            InitializeComponent();
            user = userCreator;
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Community comm = new Community(CommName.Text, user);
            DataAccess.CommumitySave(comm, user);
            NavigationService.Navigate(new UserProfilePage(user));
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
