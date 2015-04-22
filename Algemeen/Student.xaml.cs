﻿using System;
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
using System.Windows.Shapes;


namespace leren
{
    /// <summary>
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : Window
    {
        //Dit is het inlogscherm
        //Date: 27/03/2014 21:40
        //Author: Samy Coenen
        public Student()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Wanneer studentenscherm afgesloten word, moet ook de applicatie volledig afsluiten.
            MessageBoxResult result = MessageBox.Show("Bent u zeker dat u deze applicatie wilt sluiten?", "Sluiten van applicatie", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else 
            {
                e.Cancel = true;
            }
        }

        private void Image_MouseDown(object sender, RoutedEventArgs e)
        {
            
            switch (((Image)sender).Name)
            {
                case "talen":
                    
                    break;
                case "wiskunde":

                    break;
                case "kennis":                  
                    KennisMenu kennisWindow = new KennisMenu();
                    kennisWindow.Show();
                    break;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                Application.Current.Shutdown();
        }

        private void spel_Click(object sender, RoutedEventArgs e)
        {
            SpelWindow spel = new SpelWindow();
            spel.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
