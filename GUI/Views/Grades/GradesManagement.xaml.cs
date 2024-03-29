﻿using GUI.Common;
using GUI.Service;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace GUI.Views.Grades
{
    /// <summary>
    /// Interaction logic for GradesManagement.xaml
    /// </summary>
    public partial class GradesManagement : Page
    {
        private ClassServices classManageDao = new ClassServices();
        private GradesServices gradesManagementDAO = new GradesServices();
        private SubjectServices subjectDAO = new SubjectServices();
        public GradesManagement()
        {
            InitializeComponent();
            Init();
        }

        private async void RefeshList()
        {
            if(cbClass.SelectedValue != null && cbSemeter1.SelectedValue != null && cbSubject1.SelectedValue != null)
            {
                var listgrades = await gradesManagementDAO.GetGradesList((int)cbClass.SelectedValue, (int)cbSemeter1.SelectedValue, (int)cbSubject1.SelectedValue);
                if (listgrades.Count() > 0)
                {
                    lvGrades.ItemsSource = listgrades;
                }
                else
                {
                    lvGrades.ItemsSource = null;
                }
            }
            else
            {
                lvGrades.ItemsSource = null;
            } 
        }
        private async void Init()
        {
            try
            {
                cbGroup.ItemsSource = await classManageDao.GetInfoGrade();
                cbSemeter1.ItemsSource = await gradesManagementDAO.GetInfoSemeters();
                cbSubject1.ItemsSource = await subjectDAO.GetInfoSubjects();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private async void cbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbClass.ItemsSource = await classManageDao.GetInfoClass((int)cbGroup.SelectedValue);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void cbClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void DoSearch()
        {
            var listgrades = await gradesManagementDAO.GetGradesList((int)cbClass.SelectedValue, (int)cbSemeter1.SelectedValue, (int)cbSubject1.SelectedValue);
            if (listgrades.Count() > 0)
            {
                lvGrades.ItemsSource = listgrades;
            }
            else
            {
                lvGrades.ItemsSource = null;
                MessageBox.Show("Không tìm thấy học sinh", "Tìm kiếm học sinh", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (cbClass.SelectedValue != null && cbSemeter1.SelectedValue != null && cbSubject1.SelectedValue != null)
            {
                // Lấy thông tin danh sách học sinh tìm kiếm
                try
                {
                    DoSearch();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lớp học, học kỳ và môn học!", "Bảng điểm", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(cbClass.SelectedValue != null)
            {
                cbSemeter.IsEnabled = true;
                cbStudent.IsEnabled = true;
                cbSubject.IsEnabled = true;
                DialogNhapDiem.IsOpen = true;
                ClearInputGrades();
                cbSemeter.ItemsSource = await gradesManagementDAO.GetInfoSemeters();
                cbStudent.ItemsSource = await gradesManagementDAO.GetInfoStudentsOfClass((int)cbClass.SelectedValue);
                cbSubject.ItemsSource = await subjectDAO.GetInfoSubjects();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lớp học!", "Nhập điểm", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void cbSemeter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        private void txtGrade15_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtGrade45_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txtGradeSemeter_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void btnAddGrades_Click(object sender, RoutedEventArgs e)
        {
            tb_TranScripts ts = new tb_TranScripts();
            if (cbSemeter.SelectedValue != null && cbStudent.SelectedValue != null && cbSubject.SelectedValue != null && txtGrade15.Text != string.Empty && txtGrade45.Text != string.Empty && txtGradeSemeter.Text != string.Empty)
            {
                ts.StudentID = (int)cbStudent.SelectedValue;
                ts.SubjectID = (int)cbSubject.SelectedValue;
                ts.SemesterID = (int)cbSemeter.SelectedValue;
                ts.Grade15 = int.Parse(txtGrade15.Text);
                ts.Grade45 = int.Parse(txtGrade45.Text);
                ts.GradeSemester = int.Parse(txtGradeSemeter.Text);
                ts.CreatedDate = DateTime.Now;
                ts.LastUpdatedDate = DateTime.Now;
                ts.IsDeleted = false;

                if(await gradesManagementDAO.CheckGrades(ts))
                {
                    if (await gradesManagementDAO.AddGrades(ts))
                    {
                        DialogNhapDiem.IsOpen = false;
                        MessageBox.Show("Nhập điểm thành công");
                        RefeshList();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra, thêm thất bại", "Nhập điểm", MessageBoxButton.OK, MessageBoxImage.Error);
                        DialogNhapDiem.IsOpen = false;
                        RefeshList();
                    }
                }
                else
                {
                    MessageBox.Show("Điểm của sinh viên đã được nhập trước đó");
                    DialogNhapDiem.IsOpen = false;
                    RefeshList();
                }
                
            }    
        }

        private void ClearInputGrades()
        {
            txtGrade15.Text = string.Empty;
            txtGrade45.Text = string.Empty;
            txtGradeSemeter.Text = string.Empty;
            cbSemeter.SelectedItem = null;
            cbStudent.SelectedItem = null;
            cbSubject.SelectedItem = null;
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var ts = lvGrades.SelectedItem as GradesVM;

            if (ts != null)
            {
                ClearInputGrades();
                cbSemeter.ItemsSource = await gradesManagementDAO.GetInfoSemeters();
                cbStudent.ItemsSource = await gradesManagementDAO.GetInfoStudentsOfClass((int)cbClass.SelectedValue);
                cbSubject.ItemsSource = await subjectDAO.GetInfoSubjects();

                txtID.Text = ts.ID.ToString();
                cbSemeter.SelectedValue = ts.SemesterID;
                cbSubject.SelectedValue = ts.SubjectID;
                cbStudent.SelectedValue = ts.StudentID;
                txtGrade15.Text = ts.Grade15.ToString();
                txtGrade45.Text = ts.Grade45.ToString();
                txtGradeSemeter.Text = ts.GradeSemester.ToString();
                var dialog = DialogNhapDiem;
                dialog.IsOpen = true;

                unfUpdate.Visibility = Visibility.Visible;
                unfAdd.Visibility = Visibility.Collapsed;
                txtTitle.Text = "Cập nhật điểm";
                cbSemeter.IsEnabled = false;
                cbStudent.IsEnabled = false;
                cbSubject.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn học sinh trước");
            }
        }

        private async void btnUpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            tb_TranScripts ts = new tb_TranScripts();
            if (cbSemeter.SelectedValue != null && cbStudent.SelectedValue != null && cbSubject.SelectedValue != null && txtGrade15.Text != string.Empty && txtGrade45.Text != string.Empty && txtGradeSemeter.Text != string.Empty)
            {
                ts.ID = int.Parse(txtID.Text);
                ts.StudentID = (int)cbStudent.SelectedValue;
                ts.SubjectID = (int)cbSubject.SelectedValue;
                ts.SemesterID = (int)cbSemeter.SelectedValue;
                ts.Grade15 = int.Parse(txtGrade15.Text);
                ts.Grade45 = int.Parse(txtGrade45.Text);
                ts.GradeSemester = int.Parse(txtGradeSemeter.Text);
                ts.CreatedDate = DateTime.Now;
                ts.LastUpdatedDate = DateTime.Now;
                ts.IsDeleted = false;

                if (await gradesManagementDAO.UpdateGrades(ts))
                {
                    DialogNhapDiem.IsOpen = false;
                    MessageBox.Show("Cập nhật điểm thành công");
                    RefeshList();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, Cập nhật thất bại", "Cập nhật điểm", MessageBoxButton.OK, MessageBoxImage.Error);
                    DialogNhapDiem.IsOpen = false;
                    RefeshList();
                }

            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ts = lvGrades.SelectedItem as GradesVM;
                if(ts != null)
                {
                    if (MessageBox.Show("Bạn có muốn xóa bảng điểm này", "Xóa bảng điểm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (await gradesManagementDAO.DeleteGrades(ts.ID))
                        {
                            RefeshList();
                            MessageBox.Show("Xóa điểm thành công", "Xóa bảng điểm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra, xóa thất bại", "Xóa bảng điểm", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
