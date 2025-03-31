using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Movie.WPF.Views
{
    /// <summary>
    /// Interaction logic for vwAddMovie.xaml
    /// </summary>
    public partial class vwAddMovie : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public vwAddMovie()
        {
            InitializeComponent();
        }



        private void btnFileDialog_Click(object sender, RoutedEventArgs e)
        {
            
            openFileDialog.Filter = "Jpg files (.jpg)|PNG files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblImagePath.Content = openFileDialog.FileName;
                ImgPoster.Source = new BitmapImage(new Uri (openFileDialog.FileName));
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblImagePath.Content.ToString()))
            {
                var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "\\Images\\Movie\\");
                if(!Directory.Exists(path)) 
                    Directory.CreateDirectory(path);
                var imageName = Guid.NewGuid().ToString().Replace("-", "");
                var ext = System.IO.Path.GetExtension(openFileDialog.SafeFileName);
                var fulIamageName = imageName + ext;
                File.Copy(openFileDialog.FileName, path + fulIamageName);
                
            }
        }
    }
}
