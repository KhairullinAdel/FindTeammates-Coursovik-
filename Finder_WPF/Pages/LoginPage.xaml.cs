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
using Finder_WPF.Pages;

namespace Finder_WPF.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        User loggedUser;
        Dictionary<string, User> userList;
        public LoginPage()
        {
            InitializeComponent();
            userList = DataAccess.GetUsers();
        }

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            if (userList.ContainsKey(LoginBox.Text))
            {
                loggedUser = DataAccess.GetUser(LoginBox.Text);
                if (loggedUser.GetHash(UserPasswordBox.Password) == loggedUser.Password)
                {
                    MessageBox.Show($"{loggedUser.Name} is logined");
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
