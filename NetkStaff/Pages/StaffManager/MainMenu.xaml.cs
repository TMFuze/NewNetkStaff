using NetkStaff.AppFiles;
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

namespace NetkStaff.Pages.StaffManager
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void StaffList_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new StaffList());
        }

        private void UsersList_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new UsersPage());
        }

        private void Archive_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new ArchivePage());
        }
    }
}
