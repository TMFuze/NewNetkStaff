using NetkStaff.AppFiles;
using NetkStaff.AppFiles.DBModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        private ObservableCollection<User> usersList;

        public UsersPage()
        {
            InitializeComponent();

            usersList = new ObservableCollection<User>();

            // Установка источника данных для элемента управления
            UsersItemsControl.ItemsSource = usersList;

            // Загрузка данных из базы данных
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                using (var dbContext = new NetkStaffEntities())
                {
                    // Получение списка пользователей из базы данных
                    var usersFromDb = dbContext.User.ToList();

                    // Очистка и добавление данных в ObservableCollection
                    usersList.Clear();
                    foreach (var user in usersFromDb)
                    {
                        usersList.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибки при загрузке данных
                Console.WriteLine($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void Edit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameApp.frmObj.Navigate(new EditUiserPage());
        }

        private void Delete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Add_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddUserPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ShowPasswordButton_Click(object sender, RoutedEventArgs e)
        {


            ToggleButton button = (ToggleButton)sender;
            StackPanel stackPanel = (StackPanel)button.Parent;
            Label passwordLabel = stackPanel.FindName("PasswordLabel") as Label;

            if (button.IsChecked == true)
            {
                button.Content = "👁‍🗨";
                passwordLabel.Visibility = Visibility.Collapsed;
            }
            else
            {
                button.Content = "👁";
                passwordLabel.Visibility = Visibility.Visible;
            }
        }

        private T FindVisualChild<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);

                if (child is T result)
                {
                    return result;
                }

                T childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }

            return null;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
