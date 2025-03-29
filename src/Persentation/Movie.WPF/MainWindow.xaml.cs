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



        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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
    }
}