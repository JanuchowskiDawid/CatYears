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

namespace CatYears
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TextBlock resultTextBlock;
        public TextBlock askingTextBlock;
        public TextBox inputCatAge;
        public MainWindow()
        {
            InitializeComponent();

            Image backgroundImage = new Image()
            {
                Source = new BitmapImage(
                new Uri(Environment.CurrentDirectory + @"\..\..\Images\Cat.jpg", UriKind.RelativeOrAbsolute))
            };

            backgroundImage.ClipToBounds = true;

            resultTextBlock = new TextBlock()
            {
                Text = "Your cat is ",
                FontSize = 35,
                Foreground = Brushes.White
            };

            askingTextBlock = new TextBlock()
            {
                Text = "Enter your's cat age in human years: ",
                FontSize = 35,
                Foreground = Brushes.White
            };

            inputCatAge = new TextBox()
            {
                Width = 120,
                TextAlignment = TextAlignment.Center,
                FontSize = 35
            };

            inputCatAge.KeyDown += inputCatAge_KeyDown;

            Grid mainGreed = new Grid();
            StackPanel enterStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            StackPanel mainStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical
            };
            enterStackPanel.Children.Add(askingTextBlock);
            enterStackPanel.Children.Add(inputCatAge);
            mainStackPanel.Children.Add(enterStackPanel);
            mainStackPanel.Children.Add(resultTextBlock);
            mainGreed.Background = Brushes.Black;
            mainGreed.Children.Add(backgroundImage);
            mainGreed.Children.Add(mainStackPanel);

            myMainWindow.Content = mainGreed;
        }

        private void inputCatAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    double humanYears = Convert.ToDouble(inputCatAge.Text);
                    string age;
                    if (humanYears >= 0 && humanYears < 1)
                    {
                        age = "0-15";
                    }
                    else if (humanYears >= 1 && humanYears < 2)
                    {
                        age = "15-24";
                    }
                    else
                    {
                        age = (24 + (humanYears - 2) * 4).ToString();
                    }
                    resultTextBlock.Text = "Your cat age is: " + age;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Not a valid number, please ender valid number" + ex);
                }
            }
        }
    }
}
