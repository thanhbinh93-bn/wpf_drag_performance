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

namespace OverlapeTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point m_pointPressToImage = new Point();
        public MainWindow()
        {
            InitializeComponent();
            initControlView();
        }

        private void initControlView()
        {
            AddLabels();
        }

        //! Add 10,000 labels to container grid
        public void AddLabels()
        {
           
            for (int i = 0; i < 10000; i++)
            {
                Label lb = new Label();
                lb.Content = "WWW";
                lb.Foreground = Brushes.White;
                lb.FontSize = 20;
                container.Children.Add(lb);
                lb.Width = 300;
                lb.Height = 150;
                lb.Background = new SolidColorBrush(Colors.Green);
                //lb.Opacity = 0.1;
            }
        }

        private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            m_pointPressToImage = e.GetPosition((sender as FrameworkElement).Parent as FrameworkElement);
            Mouse.Capture(dragImage);
        }

        //! Drag image by changing its margin
        private void Image_PreviewMouseMove(object sender, MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Update margin of image according mouse cursor
                Point pCurrent = new Point();
                pCurrent = e.GetPosition((sender as FrameworkElement).Parent as FrameworkElement);

                double deltaX = (pCurrent.X - m_pointPressToImage.X);
                double deltaY = (pCurrent.Y - m_pointPressToImage.Y);

                
                Thickness margin = dragImage.Margin;
                margin.Left += deltaX;
                margin.Top += deltaY;

                dragImage.Margin = margin;
                m_pointPressToImage = pCurrent;
            }

        }

        private void Image_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
        }
    }
}
