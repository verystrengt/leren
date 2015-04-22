﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace leren
{
    /// <summary>
    /// Interaction logic for SpelWindow.xaml
    /// </summary>
    public partial class SpelWindow : Window
    {
        private List<ComputerSpeler> cs = new List<ComputerSpeler>();
        private SoundPlayer sp = new SoundPlayer("../../Kernkraft.wav");
        private DispatcherTimer spelKlok = new DispatcherTimer();
        public SpelWindow()
        {
            InitializeComponent();
            ComputerSpeler cs = new ComputerSpeler();
            cs.Teken(ballenSpel);            
            this.cs.Add(cs);   
            spelKlok.Tick+=spelKlok_Tick;
            spelKlok.Interval = new TimeSpan(0, 0, 0, 0, 1000/60);
            sp.Play();
        }
        void spelKlok_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(cs[0].Positie.X + " " + ballenSpel.Width);
            if (cs[0].Positie.X > ballenSpel.Width-25 || cs[0].Positie.X < 0)
            {
                cs[0].Snelheid = cs[0].Snelheid*(-1);
            }
            Canvas.SetLeft(ballenSpel.Children[0], cs[0].Positie.X + cs[0].Snelheid);
            cs[0].Positie = new Point(Canvas.GetLeft(ballenSpel.Children[0]),Canvas.GetTop(ballenSpel.Children[0]));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sp.Stop();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (spelKlok.IsEnabled == false)
            {
                spelKlok.Start();
            }
            else
            {
                spelKlok.Stop();
            }
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {                     
            base.Show();
            this.Close();
        }
    }
}
