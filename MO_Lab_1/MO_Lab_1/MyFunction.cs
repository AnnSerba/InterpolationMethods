using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;

namespace MO_Lab_1
{
    static class MyFunction
    {
        public static Interval Limits;
        public static double Mistake = 0.003;        

        public static double Calculate(double x)
        {
            return x * Math.Pow(Math.E, -(Math.Pow(x, 2.0) / 2.0));
        }

        public static double CalculateP1(double x)
        {
            double level = -(Math.Pow(x, 2.0) / 2.0);
            return Math.Pow(Math.E, level) - Math.Pow(x, 2.0) * Math.Pow(Math.E, level);
        }

        public static double CalculateP2(double x)
        {
            double level = -(Math.Pow(x, 2.0) / 2.0);
            return -3 * x * Math.Pow(Math.E, level) + (Math.Pow(x, 3.0) * Math.Pow(Math.E, level));
        }

        public static ObservableCollection<Point> GetChart()
        {
            ObservableCollection<Point> Chart = new ObservableCollection<Point>();
            Speedometer.Start();
            double step = 0.4;
            while (Limits.Left < Limits.Right)
            {
                Chart.Add(new Point { X = Limits.Left, Y = Calculate(Limits.Left) });
                Limits.Left += step;
            }
            SetLimits();
            Speedometer.Stop();
            return Chart;
        }

        public static void SetLimits()
        {
            Limits.Left = -5;
            Limits.Right = 2;
        }

        static MyFunction()
        {
            SetLimits();
        }
    }

    struct Interval
    {
        public double Left;
        public double Right;

        public double Length
        {
            get { return Right - Left; }
        }
    }
}
