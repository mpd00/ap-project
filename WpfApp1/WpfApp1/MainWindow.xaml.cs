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
using System.Windows.Threading;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }



        private void btnPreviousTab_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = MainTab.SelectedIndex - 1;
            if (newIndex < 0)
                newIndex = MainTab.Items.Count - 2;
            MainTab.SelectedIndex = newIndex;
        }

        private void btnNextTab_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = MainTab.SelectedIndex + 1;
            if (newIndex >= MainTab.Items.Count-1)
                newIndex = 0;
            MainTab.SelectedIndex = newIndex;
        }

        private void btnSelectedTab_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Selected tab: " + (MainTab.SelectedItem as TabItem).Header);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgDynamic.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

            private void Button_Click2(object sender, RoutedEventArgs e)
            {
            int newIndex = MainTab.SelectedIndex + 1;
            if (newIndex >= MainTab.Items.Count)
                newIndex = 0;
            MainTab.SelectedIndex = newIndex;
            }


            void timer_Tick(object sender, EventArgs e)
            {
                lblTime.Content = DateTime.Now.ToLongTimeString();
            }
        }
    }


