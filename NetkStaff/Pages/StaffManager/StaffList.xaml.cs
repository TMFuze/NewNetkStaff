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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;




namespace NetkStaff.Pages.StaffManager
{
    /// <summary>
    /// Логика взаимодействия для StaffList.xaml
    /// </summary>
    public partial class StaffList : Page
    {

        private List<CombineData> combinedDataList;
        private List<string> uniqueDisciplines;

        public StaffList()
        {
            InitializeComponent();
            LoadCombineData();
            LoadUniqueDisciplines();
        }





        private void LoadCombineData()
        {
            var allItems = DBConnect.entities.Personnel.ToList();

            combinedDataList = new List<CombineData>();

            foreach (var personnel in allItems)
            {
                var disciplines = DBConnect.entities.DisciplinesTaught
                    .Where(d => d.Personnel_id == personnel.id)
                    .Select(d => d.Discipline)
                    .ToList();

                var combinedData = new CombineData(
                    personnel.FullName,
                    personnel.Position,
                    personnel.TotalWorkExperience,
                    personnel.TeachingExperience,
                    disciplines
                );

                combinedDataList.Add(combinedData);
            }

            PersonalList.ItemsSource = combinedDataList.Take(100).ToList();
            ResultTxb.Text = $"{PersonalList.Items.Count}/{combinedDataList.Count}";
        }


        private void LoadUniqueDisciplines()
        {
            uniqueDisciplines = combinedDataList
                .SelectMany(x => x.Disciplines)
                .Distinct()
                .ToList();

            uniqueDisciplines.Insert(0, "Все дисциплины");

            CmbFilter.ItemsSource = uniqueDisciplines;
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var filteredData = combinedDataList
                    .Where(x => x.FullName.IndexOf(TxbSearch.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    .Take(15)
                    .ToList();

                PersonalList.ItemsSource = filteredData;
                ResultTxb.Text = $"{PersonalList.Items.Count.ToString()}/{filteredData.Count}";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CmbSort.SelectedIndex == 0)
                {
                    List<CombineData> sortData = combinedDataList.OrderBy(x => x.TotalWorkExperience).ToList();
                    PersonalList.ItemsSource = sortData;
                }
                else if (CmbSort.SelectedIndex == 1)
                {
                    List<CombineData> sortData = combinedDataList.OrderByDescending(x => x.TotalWorkExperience).ToList();
                    PersonalList.ItemsSource = sortData;
                }
                else if (CmbSort.SelectedIndex == 2)
                {
                    List<CombineData> sortData = combinedDataList.OrderBy(x => x.TeachingExperience).ToList();
                    PersonalList.ItemsSource = sortData;
                }
                else if (CmbSort.SelectedIndex == 3)
                {
                    List<CombineData> sortData = combinedDataList.OrderByDescending(x => x.TeachingExperience).ToList();
                    PersonalList.ItemsSource = sortData;
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибки
            }
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbFilter.SelectedItem != null)
            {
                string selectedDiscipline = CmbFilter.SelectedItem.ToString();

                if (selectedDiscipline == "Все дисциплины")
                {
                    // Сбросить фильтрацию
                    PersonalList.ItemsSource = combinedDataList.Take(100).ToList();
                    ResultTxb.Text = $"{PersonalList.Items.Count}/{combinedDataList.Count}";
                }
                else
                {
                    // Применить фильтрацию
                    var filteredData = combinedDataList
                        .Where(x => x.Disciplines != null && x.Disciplines.Contains(selectedDiscipline))
                        .ToList();

                    PersonalList.ItemsSource = filteredData;
                    ResultTxb.Text = $"{PersonalList.Items.Count}/{filteredData.Count}";
                }
            }
        }


       


        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoBackIWantToBeMonkey_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void PersonalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PersonalList.ItemsSource = DBConnect.entities.Personnel.Take(100).ToList();
            ResultTxb.Text = $"{PersonalList.Items.Count}/{DBConnect.entities.Personnel.Count()}";
        }
    }
}
