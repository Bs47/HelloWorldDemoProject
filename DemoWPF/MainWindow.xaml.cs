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

namespace DemoWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HelloWorldDemoProject.ILoggingService logger;
        HelloWorldDemoProject.IInitLogging _initService;


        public MainWindow()
        {
            InitializeComponent();
            var service = new HelloWorldDemoProject.LoggingService();
            _initService = service;
             logger = service;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if(sender is Button) { } - boolean ob ist
            // var btn  = sender as Button - wenn cast funktioniert,dann Button, ansonsten null

            // var color = btn?.Background - Abfrage wird nur ausgeführt wenn btn != null, irgendwie wertlos

            if (sender != null) // theoretisch nicht möglich, aber sicher ist sicher
            {
                if (sender.GetType() == typeof(Button)) // sender.ToString().Contains("Contols.Button") ;)
                {
                    _initService.Init();
                    Button btn = (Button)sender;
                    string log = "Eintrag aus WPF";
                    //btn.Background = Brushes.Fuchsia;
                    try
                    {
                        var tag = (string)btn.Tag;
                        switch (tag)
                        {
                            case "Log":
                                _initService.Init();
                                logger.Log(log);
                                System.Threading.Thread.Sleep(1000); // this will be removed in version 2.15, except the customer sucks, then it will be increased to 15000
                                break;
                            case "DeleteTempLog":
                                _initService.Init();
                                logger.DeleteLog();
                                break;
                            default:
                                break;
                        }
                    }
                    catch(InvalidCastException ice)
                    {

                    }   
                }
            }

            AddSomeLogs();

            e.Handled = true; // Event wurde fertig verarbeitet und muss nicht mehr nach oben geleitet werden.
        }

        private void AddSomeLogs()
        {
            string[] logs = new string[3];
            logs[0] = "1. Logeintrag";logs[1] = "2. Logeintrag"; logs[2] = "3. Logeintrag";
            HelloWorldDemoProject.LoggingService logger = new HelloWorldDemoProject.LoggingService();
            logger.Init();
            logger.Log(logs);
        }

    }


}
