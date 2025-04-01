using Movie.Domain.Entities;
using Movie.WPF.UserControls;
using Movie.WPF.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Movie.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var list = new List<Film> { new Film() }; //list film
            //foreach (var item in list)
            //{
            //    var path = AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Movie\\";
            //    var poster = new BitmapImage(new Uri(path + item.Poster));
            //    var us = new usImageWithBorder() { Value = item, Source = poster };
            //    us.MouseWheel += Child_MouseWheel;
            //    us.MouseDown += Child_MouseDown;
            //    spMovieList.Children.Add(us);
            //}
        }



        private void Child_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                SvMovieList.LineLeft();
            else
                SvMovieList.LineRight();
        }

        private void Child_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var uc = (UserControl) sender;
            if (uc.Content is Border border)
                MessageBox.Show($"Tag Value: {border.Tag}");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnMinimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void Rectop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
            if(e.LeftButton == MouseButtonState.Released)
                this.WindowState = this.WindowState == WindowState.Maximized
                    ? WindowState.Normal : WindowState.Maximized;
        }

        private void btnMoveRight_Click(object sender, RoutedEventArgs e)
        {
            SvMovieList.LineRight();
        }

        private void btnMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            SvMovieList.LineLeft();
        }

        private void btnDeleteMovie_Click(object sender, RoutedEventArgs e)
        {
            var win = new vwDirector();
            win.Owner = this;
            win.ShowDialog();
        }

        private void btnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            var win = new vwAddMovie();
            win.Owner = this;
            win.ShowDialog();
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            var win = new SettingWindow();
            win.Owner = this;
            win.ShowDialog();
        }
    }
}