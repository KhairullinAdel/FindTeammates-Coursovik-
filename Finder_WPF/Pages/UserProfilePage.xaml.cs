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

namespace Finder_WPF.Pages
{
    /// <summary>
    /// Interaction logic for UserProfilePage.xaml
    /// </summary>
    public partial class UserProfilePage : Page
    {
        public List<Community> coms { get; set; }
        public UserProfilePage(User user)
        {
            InitializeComponent();

            Username.Text = user.Name;
            UserLevel.Text = user.Level.ToString();
            UserXP.Text = user.XP.ToString();

            coms = DataAccess.GetCommByUser(user);

            this.DataContext = this;
        }

        private void CreateComm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
