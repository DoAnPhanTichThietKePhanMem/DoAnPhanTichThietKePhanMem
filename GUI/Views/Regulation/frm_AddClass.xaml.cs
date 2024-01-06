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
using GUI.Common;
using GUI.Service;

namespace GUI.Views.Regulation
{
    /// <summary>
    /// Interaction logic for frm_AddClass.xaml
    /// </summary>
    public partial class frm_AddClass : Window
    {
        private ClassServices classManageDao = new ClassServices();
        private RegulationServices regulationDao = new RegulationServices();
        RegulationMange regulationPage = new RegulationMange();

        public frm_AddClass(RegulationMange regulationPage)
        {
            InitializeComponent();

            try
            {
                this.regulationPage = regulationPage;
                InitCbGrade();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private async void InitCbGrade()
        {
            cbGrade.ItemsSource = await classManageDao.GetInfoGrade();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbGrade.SelectedValue != null)
                {
                    if(!String.IsNullOrEmpty(txtClassName.Text))
                    {
                        if(await classManageDao.GetInfoClassByName(txtClassName.Text.Trim())==null)
                        {
                            if (MessageBox.Show("Bạn có muốn thêm thông tin lớp học này?", "Thêm lớp học", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                var newClass = new tb_Class();
                                newClass.IsDeleted = false;
                                newClass.GroupID = (int)cbGrade.SelectedValue;
                                newClass.Name = txtClassName.Text.ToString().Trim();
                                newClass.Quantity = 0;

                                if (await classManageDao.AddInfoClass(newClass))
                                {
                                    MessageBox.Show("Thêm lớp học thành công", "Thêm lớp học", MessageBoxButton.OK, MessageBoxImage.Information);
                                    var res = await regulationDao.getQuantityClass();
                                    regulationPage.txtQuantityClass.Text = res.ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi xảy ra, Thêm thất bại!", "Thêm lớp học", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tên lớp học đã tồn tại!", "Thêm lớp học", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên lớp học không được để trống", "Thêm lớp học", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khối!", "Thêm lớp học", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
