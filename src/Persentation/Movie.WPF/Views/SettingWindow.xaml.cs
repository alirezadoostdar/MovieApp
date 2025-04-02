using Movie.WPF.UserControls;
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

namespace Movie.WPF.Views
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void btnDirector_Click(object sender, RoutedEventArgs e)
        {
            spContent.Children.Clear();
            spContent.Children.Add(new DirectorUserControl());
        }

        private void btnGenres_Click(object sender, RoutedEventArgs e)
        {
            spContent.Children.Clear();
            spContent.Children.Add(new GenreUserControl());
        }
    }
}
