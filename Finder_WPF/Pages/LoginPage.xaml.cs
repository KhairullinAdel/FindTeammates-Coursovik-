using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Finder_Core;
using Finder_Core.FireBase;

namespace Finder_WPF.Pages
{
    public partial class LoginPage : Page
    {
        User loggedUser;
        Dictionary<string, User> userList;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            userList = DataAccess.GetUsers();
            if (userList.ContainsKey(LoginBox.Text))
            {
                loggedUser = DataAccess.GetUser(LoginBox.Text);
                if (loggedUser.GetHash(UserPasswordBox.Password) == loggedUser.Password)
                {
                    NavigationService.Navigate(new UserProfilePage(loggedUser));
                }
                else
                {
                    MessageBox.Show("incorrect password");
                    UserPasswordBox.Password = "";
                }
            }
            else
            {
                MessageBox.Show("There is no user with this login");
            }
        }

        private void ToRegPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }
    }
}
