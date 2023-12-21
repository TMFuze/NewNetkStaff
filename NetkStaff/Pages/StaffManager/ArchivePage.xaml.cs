using NetkStaff.AppFiles;
using NetkStaff.AppFiles.DBModel;
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
    /// Логика взаимодействия для ArchivePage.xaml
    /// </summary>
    public partial class ArchivePage : Page
    {
        private List<Archive> allItems;

        public ArchivePage()
        {
            InitializeComponent();

            TypeOfDocSel.SelectedValuePath = "Id";
            TypeOfDocSel.DisplayMemberPath = "Name";
            TypeOfDocSel.ItemsSource = DBConnect.entities.DocType.ToList();

            DGItems.ItemsSource = DBConnect.entities.Archive.ToList();

            allItems = DBConnect.entities.Archive.ToList();

        }



        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void DGItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
