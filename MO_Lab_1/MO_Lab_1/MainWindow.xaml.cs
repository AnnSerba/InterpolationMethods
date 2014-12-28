using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;
using System.Collections.ObjectModel;

namespace MO_Lab_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddChart("F", MyFunction.GetChart());
        }

        public ObservableCollection<Point> _tempVariables = new ObservableCollection<Point>();
        public ObservableCollection<Point> tempVariables
        { get { return _tempVariables; } }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (rbtnDichotomy.IsChecked.Value)
                AddChart("Дихотомия", Methods.Dichotomy());

            if (rbtnGold.IsChecked.Value)
                AddChart("Зол. сечение", Methods.Gold());

            if (rbtnFibonacci.IsChecked.Value)
                AddChart("Фибоначчи", Methods.Fibonacci());

            if (rbtnNewton.IsChecked.Value)
                AddChart("Ньютон", Methods.Newton());
            
            MyFunction.SetLimits();
        }

        private void AddChart(string name, ObservableCollection<Point> chart)
        {
            _tempVariables.Clear();
            foreach (Point p in chart)
                _tempVariables.Add(p);
            txtIteracii.Text = "Кол-во точек : " + chart.Count + "\nВремя: " + Speedometer.Duration;
            LineSeries NewChart = new LineSeries();
            NewChart.DependentValuePath = "Y";
            NewChart.IndependentValuePath = "X";
            NewChart.Title = name;
            NewChart.ItemsSource = chart;
            Charts.Series.Add(NewChart);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Charts.Series.Clear();
            AddChart("F", MyFunction.GetChart());
        }

    }
}
