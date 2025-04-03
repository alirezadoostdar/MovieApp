using MaterialDesignThemes.Wpf;
using Movie.WPF.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    //    private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    //    {
    //        //until we had a StaysOpen flag to Drawer, this will help with scroll bars
    //        //var dependencyObject = Mouse.Captured as DependencyObject;

    //        //while (dependencyObject != null)
    //        //{
    //        //    if (dependencyObject is ScrollBar) return;
    //        //    dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
    //        //}

    //        //MenuToggleButton.IsChecked = false;
    //    }
    //    private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
    //    {
    //        //var sampleMessageDialog = new SampleMessageDialog
    //        //{
    //        //    Message = { Text = ((ButtonBase)sender).Content.ToString() }
    //        //};

    //        //await DialogHost.Show(sampleMessageDialog, "RootDialog");
    //    }

    //    private void OnCopy(object sender, ExecutedRoutedEventArgs e)
    //    {
    //        if (e.Parameter is string stringValue)
    //        {
    //            try
    //            {
    //                Clipboard.SetDataObject(stringValue);
    //            }
    //            catch (Exception ex)
    //            {
    //                Trace.WriteLine(ex.ToString());
    //            }
    //        }
    //    }
    //    private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
    //=> DemoItemsSearchBox.Focus();

    //    private void MenuDarkModeButton_Click(object sender, RoutedEventArgs e)
    //        => ModifyTheme(DarkModeToggleButton.IsChecked == true);

    //    private void FlowDirectionButton_Click(object sender, RoutedEventArgs e)
    //        => FlowDirection = FlowDirectionToggleButton.IsChecked.GetValueOrDefault(false)
    //            ? FlowDirection.RightToLeft
    //            : FlowDirection.LeftToRight;

    //    private static void ModifyTheme(bool isDarkTheme)
    //    {
    //        var paletteHelper = new PaletteHelper();
    //        var theme = paletteHelper.GetTheme();

    //        theme.SetBaseTheme(isDarkTheme ? BaseTheme.Dark : BaseTheme.Light);
    //        paletteHelper.SetTheme(theme);
    //    }

    //    private void OnSelectedItemChanged(object sender, DependencyPropertyChangedEventArgs e)
    //        => MainScrollViewer.ScrollToHome();
    }
}
