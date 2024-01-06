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
using GUI.Service;
using GUI.Common;

namespace GUI.Views.Regulation
{
    /// <summary>
    /// Interaction logic for RegulationMange.xaml
    /// </summary>
    public partial class RegulationMange : Page
    {
        private RegulationServices regulationDao = new RegulationServices();
        private tb_Regulations regulation = new tb_Regulations();

        public RegulationMange()
        {
            InitializeComponent();
            Init();
        }

        public async void Init()
        {
            regulation = await regulationDao.GetInfoRegulation();

            txtMaxAge.Text = regulation.MaxAge.ToString();
            txtMinAge.Text = regulation.MinAge.ToString();
            txtMaxQuantity.Text = regulation.MaxQuantity.ToString();
            txtQuantityClass.Text = await regulationDao.getQuantityClass();
            txtQuantitySubject.Text = await regulationDao.getQuantitySubject();
            txtScores.Text = regulation.PassingGrade.ToString();

        }

        private void popUpUpdateClass_Click(object sender, RoutedEventArgs e)
        {
            // Open add form.
            frm_UpdateClass form = new frm_UpdateClass(this);
            form.Show();
        }

        private void popUpAddClass_Click(object sender, RoutedEventArgs e)
        {
            // Open add form.
            frm_AddClass form = new frm_AddClass(this);
            form.Show();
        }

        private void popUpUpdateSubject_Click(object sender, RoutedEventArgs e)
        {
            // Open add form.
            frm_UpdateSubject form = new frm_UpdateSubject(this);
            form.Show();
        }

        private void popUpAddSubject_Click(object sender, RoutedEventArgs e)
        {
            // Open add form.
            frm_AddSubject form = new frm_AddSubject(this);
            form.Show();
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn cập nhật những quy định này?", "Quản lý quy định", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    regulation.IsDeleted = false;
                    regulation.MaxAge = int.Parse(txtMaxAge.Text);
                    regulation.MinAge = int.Parse(txtMinAge.Text);
                    regulation.MaxQuantity = int.Parse(txtMaxQuantity.Text);
                    regulation.ClassQuantity = int.Parse(txtQuantityClass.Text);
                    regulation.SubjectQuantity = int.Parse(txtQuantitySubject.Text);
                    regulation.PassingGrade = double.Parse(txtScores.Text);

                    if (await regulationDao.UpdateRegulation(regulation))
                    {
                        MessageBox.Show("Cập nhật thành công", "Cập nhật quy định");
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra, Cập nhật không thành công!", "Cập nhật quy định");
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
