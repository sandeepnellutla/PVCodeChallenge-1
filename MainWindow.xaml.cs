using System.Collections.Generic;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System;

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
            var shouldreturn = false;
            Dictionary<int, string> EventResults = new Dictionary<int, string>();
            try
            {
                /* -------------- Regular Bare Bones */
                //switch (cbOptions.Text)
                //{
                //    case "'Register'": EventResults = (new BusinessLogic.BLFactory()).GetNumbersForRegister(0, 100); break;
                //    case "'Diagnose'": EventResults = (new BusinessLogic.BLFactory()).GetNumbersForDiagnose(0, 100); break;
                //    default: break;
                //}

                /*---------------- Improved performance and Memory mgt */
                switch (cbOptions.Text)
                {
                    case "'Register'": EventResults = BusinessLogic.BLFactoryIM.GetNumbersForRegisterIM(0, 100); break;
                    case "'Diagnose'": EventResults = BusinessLogic.BLFactoryIM.GetNumbersForDiagnoseIM(0, 100); break;
                    default: lblResults.Content = "Please select an Event Type"; shouldreturn = true; break;
                }
                
                if (shouldreturn) return;

                // Show Results
                lblResults.Content = string.Format("Number of {0}: {1} {2} Number of 'Patient':{3} {2} Number of Both:{4} {2} Number of Rest:{5}",
                                        cbOptions.Text,
                                        EventResults.Count(c => c.Value == cbOptions.Text),
                                        System.Environment.NewLine,
                                        EventResults.Count(c => c.Value.Contains("Patient")),
                                        EventResults.Count(c => c.Value.Contains("&'Patient")),
                                        EventResults.Count(c => c.Value == c.Key.ToString())
                    );


                dataGrid.ItemsSource = EventResults;
            }
            catch (Exception ex)
            {
                lblResults.Content = "System Error Please see the error message below: " + System.Environment.NewLine + ex.Message;
            }
        }
    }
}
