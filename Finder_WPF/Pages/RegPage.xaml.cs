using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Finder_Core;
using Finder_Core.FireBase;
using Finder_WPF.Pages;

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
            Dictionary<string, User> users = DataAccess.GetUsers();
            if (users.ContainsKey(LoginBox.Text))
            {
                MessageBox.Show("Please, enter another login");
                LoginBox.Text = "";
            }
            else
            {
                if (UserPasswordBox.Password == ConfirmPasswordBox.Password)
                {
                    User user = new User(UserNameBox.Text, LoginBox.Text, UserPasswordBox.Password);
                    NavigationService.Navigate(new SocialsAddPage(user));
                }
                else
                {
                    MessageBox.Show("Passwords don't match");
                    ConfirmPasswordBox.Password = "";
                }
            }
            
        }
        private void ToAuthPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

    }
}
