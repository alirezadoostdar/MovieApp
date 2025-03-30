using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Movie.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for usImageWithBorder.xaml
    /// </summary>
    public partial class usImageWithBorder : UserControl
    {
        #region DP Properties



        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("SourceProperty", typeof(ImageSource), typeof(usImageWithBorder), 
                new PropertyMetadata(null));



        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(usImageWithBorder),
                new PropertyMetadata(null));


        #endregion
        public usImageWithBorder()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
