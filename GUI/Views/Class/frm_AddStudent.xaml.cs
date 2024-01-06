using GUI.Common;
using GUI.Service;
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
using System.Windows.Shapes;

namespace GUI.Views.Class
{
    /// <summary>
    /// Interaction logic for frm_AddStudent.xaml
    /// </summary>
    public partial class frm_AddStudent : Window
    {
        private ClassServices classManageDao = new ClassServices();
        ClassManager classManagePage = new ClassManager();

        public frm_AddStudent(ClassManager classManagePage)
        {

            InitializeComponent();
            this.classManagePage = classManagePage;
            InitlvStudent();
        }

        public frm_AddStudent()
        {
            InitializeComponent();
            InitlvStudent();
        }

        private async void InitlvStudent()
        {
            lvStudent.ItemsSource = await classManageDao.GetInfoStudentsWithoutClass("");
        }

        private void SelectCurrentItem(object sender, KeyboardFocusChangedEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            item.IsSelected = true;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnAddIntoClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvStudent.SelectedItem != null)
                {
                    // Check quantity
                    if (await classManageDao.CheckQuantityStudentOfclass(1, 1))
                    {
                        var classInfo = classManagePage.cbClass.SelectedItem as tb_Class;
                        var student = lvStudent.SelectedItem as tb_Students;

                        if (MessageBox.Show("Bạn có muốn thêm học sinh này vào lớp " + classInfo.Name.ToString(), "Thêm học sinh", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {

                            if (await classManageDao.AddStudentIntoClass(classInfo.ID, student.ID))
                            {

                                // Load lại danh sách
                                lvStudent.ItemsSource = await classManageDao.GetInfoStudentsWithoutClass(txtSearch.Text);
                                this.classManagePage.lvStudent.ItemsSource = await classManageDao.GetInfoStudentsOfClass(classInfo.ID, this.classManagePage.txtSearch.Text);

                                MessageBox.Show("Thêm học sinh thành công", "Thêm học sinh", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi xảy ra, thêm thất bại", "Thêm học sinh", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sỉ số lớp đã đầy", "Thêm học sinh", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn học sinh!", "Thêm học sinh váo lớp học", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void DoSearch()
        {
            var listStudent = await classManageDao.GetInfoStudentsWithoutClass(txtSearch.Text);
            if (listStudent.Count() > 0)
            {
                lvStudent.ItemsSource = listStudent;
            }
            else
            {
                lvStudent.ItemsSource = null;
                MessageBox.Show("Không tìm thấy học sinh", "Tìm kiếm học sinh", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DoSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
