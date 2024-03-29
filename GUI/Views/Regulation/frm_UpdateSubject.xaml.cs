﻿using System;
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
using GUI.Common;
using GUI.Service;

namespace GUI.Views.Regulation
{
    /// <summary>
    /// Interaction logic for frm_UpdateSubject.xaml
    /// </summary>
    public partial class frm_UpdateSubject : Window
    {
        SubjectServices subjectDao = new SubjectServices();
        private RegulationServices regulationDao = new RegulationServices();

        RegulationMange regulationPage = new RegulationMange();

        public frm_UpdateSubject(RegulationMange regulationPage)
        {
            InitializeComponent();
            this.regulationPage = regulationPage;
            InitCbSubject();
        }

        private async void InitCbSubject()
        {
            cbIdSubject.ItemsSource = await subjectDao.GetInfoSubjects();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbIdSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbIdSubject.SelectedValue != null)
            {
                try
                {
                    var infoSubject = cbIdSubject.SelectedItem as tb_Subjects;
                    txtSubjectName.Text = infoSubject.Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbIdSubject.SelectedValue != null)
                {
                    if (!String.IsNullOrEmpty(txtSubjectName.Text))
                    {
                        if (await subjectDao.GetSubjectByName(txtSubjectName.Text.Trim()) == null)
                        {
                            if (MessageBox.Show("Bạn có muốn cập nhật thông tin môn học này?", "Cập nhật môn học", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                var infoSubject = cbIdSubject.SelectedItem as tb_Subjects;
                                if (await subjectDao.UpdateInfoNameSubject(infoSubject.ID, txtSubjectName.Text.ToString().Trim()))
                                {
                                    MessageBox.Show("Cập nhật môn học thành công", "Cập nhật môn học", MessageBoxButton.OK, MessageBoxImage.Information);
                                    regulationPage.txtQuantitySubject.Text = await regulationDao.getQuantitySubject();
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi xảy ra, cập nhật thất bại", "Cập nhật môn học", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tên môn học đã tồn tại!", "Cập nhật môn học", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên môn học không được để trống", "Thêm môn học", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn môn học", "Xóa môn học", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (MessageBox.Show("Bạn có muốn xóa thông tin môn học này?", "Xóa môn học", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var infoSubject = cbIdSubject.SelectedItem as tb_Subjects;
                    if (await subjectDao.DeleteInfoSubject(infoSubject.ID))
                    {
                        MessageBox.Show("Xóa môn học thành công", "Xóa môn học", MessageBoxButton.OK, MessageBoxImage.Information);
                        cbIdSubject.ItemsSource = await subjectDao.GetInfoSubjects();
                        txtSubjectName.Text = "";
                        regulationPage.txtQuantitySubject.Text = await regulationDao.getQuantitySubject();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra, Xóa thất bại", "Xóa môn học", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
