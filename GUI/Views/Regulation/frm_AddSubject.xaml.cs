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
using GUI.Service;
using GUI.Common;

namespace GUI.Views.Regulation
{
    /// <summary>
    /// Interaction logic for frm_AddSubject.xaml
    /// </summary>
    public partial class frm_AddSubject : Window
    {
        SubjectServices subjectDao = new SubjectServices();
        private RegulationServices regulationDao = new RegulationServices();

        RegulationMange regulationPage = new RegulationMange();

        public frm_AddSubject(RegulationMange regulationPage)
        {
            InitializeComponent();

            this.regulationPage = regulationPage;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSubjectName.Text))
                {
                    if(await subjectDao.GetSubjectByName(txtSubjectName.Text.Trim())==null)
                    {
                        if (MessageBox.Show("Bạn có muốn thêm thông tin môn học này?", "Thêm môn học", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            var newSubject = new tb_Subjects();
                            newSubject.IsDeleted = false;
                            newSubject.Name = txtSubjectName.Text.ToString().Trim();

                            if (await subjectDao.AddInfoSubject(newSubject))
                            {
                                MessageBox.Show("Thêm môn học thành công", "Thêm môn học", MessageBoxButton.OK, MessageBoxImage.Information);
                                regulationPage.txtQuantitySubject.Text = await regulationDao.getQuantitySubject();
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi xảy ra, Thêm thất bại!", "Thêm môn học", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên môn học đã tồn tại!", "Thêm môn học", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Tên môn học không được để trống", "Thêm môn học", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
