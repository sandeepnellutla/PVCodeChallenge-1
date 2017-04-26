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

namespace PVCodeChallenge
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<int, string> EventResults= new Dictionary<int, string>();

            switch (cbOptions.Text)
            {
                case "'Register'": EventResults = (new BusinessLogic.BLFactory()).GetNumbersForRegister(0, 100); break;
                case "'Diagnose'": EventResults = (new BusinessLogic.BLFactory()).GetNumbersForDiagnose(0, 100); break;
                default: break;
            }

            dataGrid.ItemsSource = EventResults;
        }
    }
}
