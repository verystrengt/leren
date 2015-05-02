﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace leren
{
    //De superclasse voor alle bewegenden objecten van het spel
    //Date: 16/04/2014 20:48
    //Author: Samy Coenen
    abstract class SpelEntiteit
    {
        private double _snelheid = 1.0;
        private double _xChange = 5;
        private double _yChange = 5;
        protected Rectangle se;
        private int _grootte = 40;
        private static readonly Random r1 = new Random();
        
        public SpelEntiteit()
        {
            se = new Rectangle();
            se.Height = _grootte;
            se.Width = _grootte;
        }

        public void Teken(Canvas spelCanvas, double x, double y)
        {
            se.Margin = new Thickness(x, y, 0, 0);
            spelCanvas.Children.Add(se);
        }

        public void Teken(Canvas spelCanvas)
        {            
            se.Margin = new Thickness(r1.Next(0, Convert.ToInt32(spelCanvas.Width-_grootte)),r1.Next(0,Convert.ToInt32(spelCanvas.Height-_grootte)),0,0);  
            spelCanvas.Children.Add(se);
        }

        public void VeranderKleur(SolidColorBrush kleur)
        {
            se.Fill = kleur;
        }

        public string Kleur()
        {
            return Convert.ToString(se.Fill);
        }

        public double Snelheid
        {
            get { return _snelheid; }
            set { _snelheid = value; }
        }

        public bool Geraakt(Canvas spelCanvas)
        {
            int geraakt=0;
            Point positie = new Point(Positie().X+_xChange, Positie().Y+_yChange);
            Rect rect2 = new Rect(positie.X, positie.Y, se.Width, se.Height);
            foreach (UIElement element in spelCanvas.Children)
            {
                  Rectangle el = element as Rectangle;
                  Rect rect1 = new Rect( el.Margin.Left , el.Margin.Top, el.Width, el.Height);                  
                   if (rect1.IntersectsWith(rect2))
                   {
                       geraakt++;                       
                       if (geraakt > 1)
                       {
                           Console.WriteLine(geraakt);
                           return true;
                       }
                    }                      
            }
            return false;
        }

        public Point Positie()
        {
            return new Point(se.Margin.Left, se.Margin.Top);
            
        }

        public int Grootte
        {
            get { return _grootte; }
            set { _grootte = value; }
        }

        public double XVerplaatsing
        {
            get { return _xChange; }
            set { _xChange = value; }
        }        

        public double YVerplaatsing
        {
            get { return _yChange; }
            set { _yChange = value; }
        }
    }
}
