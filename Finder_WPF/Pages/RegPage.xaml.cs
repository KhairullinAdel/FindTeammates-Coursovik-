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
        private void ToAuthPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

    }
}
