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
    /// Логика взаимодействия для EditUiserPage.xaml
    /// </summary>
    public partial class EditUiserPage : Page
    {
        public EditUiserPage()
        {
            InitializeComponent();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
