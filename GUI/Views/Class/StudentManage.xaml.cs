using GUI.Common;
using GUI.Service;
using MaterialDesignThemes.Wpf;
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
using static GUI.Common.GeneralModel;

namespace GUI.Views.Class
{
    /// <summary>
    /// Interaction logic for StudentManage.xaml
    /// </summary>
    public partial class StudentManage : Page
    {
        private StudentServices studentManageDAO = new StudentServices();

        public class Student
        {
            public string Name { get; set; }

        }

        public StudentManage()
        {
            InitializeComponent();
            this.DataContext = new Student();
            ReFeshListStudentRecord();
        }

        private async void ReFeshListStudentRecord()
        {
            var lst = await studentManageDAO.ListStudentRecord();

            lvStudentRecord.ItemsSource = lst;
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text != "")
            {
                try
                {
                    var lstStudent = await studentManageDAO.SearchStudent(txtSearch.Text);

                    if (lstStudent.Count() > 0)
                    {
                        lvStudentRecord.ItemsSource = lstStudent;
                    }
                    else
                    {
                        lvStudentRecord.ItemsSource = null;
                        MessageBox.Show("Không tìm thấy hồ sơ học sinh", "Tìm kiếm hồ sơ  học sinh", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            cbGender.Items.Clear();
            cbGender.Items.Add(new ComboBoxItem() { Tag = 0, Content = "Nam" });
            cbGender.Items.Add(new ComboBoxItem() { Tag = 1, Content = "Nữ" });
            cbGender.SelectedIndex = 0;
            dpDateOFBirth.SelectedDate = DateTime.Now;
        }

        private async void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem ComboItem = (ComboBoxItem)cbGender.SelectedItem;
                string Gender = ComboItem.Tag.ToString();


                tb_Students students = new tb_Students();
                students.Name = txtName.Text;
                students.DateOfBirth = dpDateOFBirth.SelectedDate.Value;
                students.Gender = int.Parse(Gender);
                students.Email = txtEmail.Text;
                students.Address = txtAddress.Text;
                students.CreatedDate = DateTime.Now;
                students.LastUpdatedDate = DateTime.Now;
                students.IsDeleted = false;


                if (!string.IsNullOrEmpty(students.Name))
                {
                    if (await studentManageDAO.AddStudent(students))
                    {
                        MessageBox.Show("Thêm hồ sơ học sinh thành công");

                        ClearInputStudent();

                        ReFeshListStudentRecord();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra, thêm thất bại", "Thêm học sinh", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    txtName.Text = " ";
                    txtName.Text = "";
                    txtName.Focus();
                    MessageBox.Show("Vui lòng nhập thông tin còn thiếu!", "Thêm học sinh", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var student = lvStudentRecord.SelectedItem as StudentVM;
            txtID.Visibility = Visibility.Visible;
            if (student != null)
            {
                txtID.Text = student.ID.ToString();
                txtName.Text = student.Name;
                dpDateOFBirth.SelectedDate = student.DateOfBirth;
                txtEmail.Text = student.Email;
                txtAddress.Text = student.Address;

                var dialog = DialogHost.OpenDialogCommand;
                dialog.Execute(null, null);

                unfUpdate.Visibility = Visibility.Visible;
                unfAdd.Visibility = Visibility.Collapsed;

                cbGender.Items.Clear();
                cbGender.Items.Add(new ComboBoxItem() { Tag = 0, Content = "Nam" });
                cbGender.Items.Add(new ComboBoxItem() { Tag = 1, Content = "Nữ" });
                if (student.Gender == 0)
                {
                    cbGender.SelectedIndex = 0;
                }
                else
                {
                    cbGender.SelectedIndex = 1;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn học sinh trước");
            }

        }

        private void ClearInputStudent()
        {
            txtID.Text = "";
            txtName.Text = "";
            Validation.ClearInvalid(txtName.GetBindingExpression(TextBox.TextProperty));
            dpDateOFBirth.SelectedDate = DateTime.Now;
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private async void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int StudentID = int.Parse(txtID.Text);
                if (MessageBox.Show("Bạn có muốn xóa hồ sơ học sinh này", "Xóa học sinh", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (await studentManageDAO.DeleteStudent(StudentID))
                    {
                        // Load lại danh sách
                        ReFeshListStudentRecord();

                        ClearInputStudent();

                        MessageBox.Show("Xóa hồ sơ học sinh thành công", "Xóa hồ sơ học sinh", MessageBoxButton.OK, MessageBoxImage.Information);

                        txtID.Visibility = Visibility.Collapsed;
                        unfAdd.Visibility = Visibility.Visible;

                        unfUpdate.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra, xóa thất bại", "Xóa hồ sơ học sinh", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private async void btnUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem ComboItem = (ComboBoxItem)cbGender.SelectedItem;
                string Gender = ComboItem.Tag.ToString();

                tb_Students students = new tb_Students();
                students.ID = int.Parse(txtID.Text);
                students.Name = txtName.Text;
                students.Gender = int.Parse(Gender);
                students.DateOfBirth = dpDateOFBirth.SelectedDate;
                students.Address = txtAddress.Text;
                students.Email = txtEmail.Text;
                students.LastUpdatedDate = DateTime.Now;

                if (!string.IsNullOrEmpty(students.Name))
                {
                    if (await studentManageDAO.UpdateStudent(students))
                    {
                        MessageBox.Show("Cập nhật thành công");

                        ReFeshListStudentRecord();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra", "Cập nhật hồ sơ học sinh", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    txtName.Text = " ";
                    txtName.Text = "";
                    txtName.Focus();
                    MessageBox.Show("Vui lòng nhập thông tin còn thiếu!", "Cập nhật hồ sơ học sinh", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefesh_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
            ReFeshListStudentRecord();
        }

        private void btnCancelUpdate_Click(object sender, RoutedEventArgs e)
        {
            ClearInputStudent();
            txtID.Visibility = Visibility.Collapsed;

            unfAdd.Visibility = Visibility.Visible;
            unfUpdate.Visibility = Visibility.Collapsed;
        }
    }
}
