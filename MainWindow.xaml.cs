using System;
using System.Windows;
using System.Timers;
using System.Collections.Generic;
namespace keyboardgame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer;
        //uusi ilmentymä ajastin luokasta TimeSpan ja alustetaan h=0, min=0 ja sek=10
        TimeSpan ajastin = new TimeSpan(0, 0, 10);
        public MainWindow()
        {
            InitializeComponent();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,0,0,500);
            timer.Tick += new EventHandler(timer_Tick);
          
        }
        static string arvaa;
        void timer_Tick(object sender, EventArgs e)
        {
            //ajastin = ajastin.Add(new TimeSpan(0, 0, 1)); 
            ajastin = ajastin.Subtract(new TimeSpan(0, 0, 1));
            progressBar1.Maximum = 10;
            progressBar1.Value = ajastin.TotalSeconds;
            textBox1.Text = arvaa;
            if (ajastin.TotalSeconds <= 0)
            {
                timer.Stop();
                ajastin = ajastin.Add(new TimeSpan(0, 0, 10)); 
            }
            label1.Content = ajastin.TotalSeconds;

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            uusluku();
            timer.Start();
        }
        Random random = new Random();
        void uusluku()
        {
            arvaa = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))).ToString();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.ToString() == arvaa) uusluku();
            ajastin = ajastin.Add(new TimeSpan(0, 0, 2));
        }
    }
}
