using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Wpf_BackgroundWorkerExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker backgroundWorker1 = new BackgroundWorker ();

        public MainWindow ()
        {
            InitializeComponent ();





            backgroundWorker1.WorkerReportsProgress=true;
            backgroundWorker1.WorkerSupportsCancellation=true;
            backgroundWorker1.ProgressChanged+=new ProgressChangedEventHandler (backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted+=new RunWorkerCompletedEventHandler (backgroundWorker1_Completed);
            backgroundWorker1.DoWork+=new DoWorkEventHandler (backgroundWorker1_DoWork);
        }

        private void backgroundWorker1_Completed (object sender, RunWorkerCompletedEventArgs e)
        {
            DateTime t = DateTime.Now;
            if (e.Cancelled)
            {
             
                TimeSpan duration = t-dt;
               
                double a = duration.Seconds;
                MessageBox.Show (a.ToString ());


            }
            else if (e.Error!=null)
            {
                // lblStatus.Text = "Error while performing background operation.";
            }
            else
            {
                //   textBox.Text  = "Task Completed...";
            }





        }

        private void backgroundWorker1_ProgressChanged (object sender, ProgressChangedEventArgs e)
        {
            textBox.Text=DateTime.Now.ToString ();

        }

        private void backgroundWorker1_DoWork (object sender, DoWorkEventArgs e)
        {
            do
            {

                backgroundWorker1.ReportProgress (1);

                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel=true;
                    return;
                }
                Thread.Sleep (1000);


            } while (true);







        }
        DateTime dt;

        private void button_Click (object sender, RoutedEventArgs e)
        {
            dt=DateTime.Now;
            backgroundWorker1.RunWorkerAsync ();  
        }
       
        private void button1_Click (object sender, RoutedEventArgs e)
        {
           
            backgroundWorker1.CancelAsync ();
        }
    }

}


