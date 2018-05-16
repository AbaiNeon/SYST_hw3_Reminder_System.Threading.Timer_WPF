using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SYST_hw3_napominalka_timer
{
    public partial class MainWindow : Window
    {
        private Timer timer;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            if (!(Validation()))
            {
                MessageBox.Show("Please, fill the all fields");
                return;
            }

            DateTime? userDate = datePicker.SelectedDate;
            DateTime? userTime = timePicker.Value.Value;
            string textRem = text.Text;

            timer = new Timer(
                new TimerCallback(stubObject =>
                {
                    Thread.CurrentThread.Name = "2 поток";
                    DateTime currentTime = DateTime.Now;

                    if (currentTime.Year == userDate.Value.Year && currentTime.Month == userDate.Value.Month && currentTime.Day == userDate.Value.Day && currentTime.Hour == userTime.Value.Hour && currentTime.Minute == userTime.Value.Minute)
                    {
                        StopTimer();
                        MessageBox.Show(textRem);
                    }
                }),
                null, 0, 1000);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void StopTimer()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private bool Validation()
        {
            if (datePicker.Text == "")
                return false;

            if ( !(timePicker.Value.HasValue) )
                return false;

            if (text.Text == "")
                return false;

            return true;
        }
    }
}
