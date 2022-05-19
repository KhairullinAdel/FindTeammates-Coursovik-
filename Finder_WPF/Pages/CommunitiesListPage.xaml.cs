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
    }
}
