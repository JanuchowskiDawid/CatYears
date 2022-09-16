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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void inputCatAge_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                try
                {
                    double humanYears = Convert.ToDouble(inputCatAge.Text);
                    string age;
                    if (humanYears >= 0 && humanYears < 1)
                    {
                        age = "0-15";
                    }
                    else if(humanYears >= 1 && humanYears < 2){
                        age = "15-24";
                    }
                    else
                    {
                        age = (24+(humanYears-2)*4).ToString();
                    }
                    resultTextBlock.Text = "Your cat age is: " + age;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Not a valid number, please ender valid number" + ex);
                }
            }
        }
    }
}
