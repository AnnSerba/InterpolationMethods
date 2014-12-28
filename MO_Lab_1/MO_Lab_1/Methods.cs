using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.Threading;

namespace MO_Lab_1
{
    class Methods
    {
        public static ObservableCollection<Point> Dichotomy()
        {
            //Создаем коллекцию точек для графика
            ObservableCollection<Point> Chart = new ObservableCollection<Point>();
            //Инициализация переменных
            double x1, x2, fx1, fx2, step;
            //Устанавливаем шаг много меньше ошибки => например в 4 раза
            step = MyFunction.Mistake / 4;
            //Запускаем измерение времени
            Speedometer.Start();
            //До тех пор пока длина интервала больше ошибки - выполнять
            while (MyFunction.Limits.Length >= MyFunction.Mistake)
            {
                //Ставим две точки на расстоянии шага от центра интервала в обе стороны
                x1 = (MyFunction.Limits.Left + MyFunction.Limits.Right) / 2 - step;
                x2 = (MyFunction.Limits.Left + MyFunction.Limits.Right) / 2 + step;
                //Вычисляем значения функции в этих точках
                fx1 = MyFunction.Calculate(x1);
                fx2 = MyFunction.Calculate(x2);
                //Если первое значение больше
                if (fx1 > fx2)
                    //Сдвигаем левую границу в точку x1
                    MyFunction.Limits.Left = x1;
                else
                    //Иначе сдвигаем правую границу в точку х2
                    MyFunction.Limits.Right = x2;
                //Добавляем точки в коллекцию
                Chart.Add(new Point { X = x1, Y = fx1 });
                Chart.Add(new Point { X = x2, Y = fx2 });
            }
            //Останавливаем отсчёт времени
            Speedometer.Stop();
            return Chart;
        }

        public static ObservableCollection<Point> Gold()
        {
            //Создаем коллекцию точек для графика
            ObservableCollection<Point> Chart = new ObservableCollection<Point>();
            //Инициализация переменных
            double x1, x2, fx1, fx2;
            double A = 0.618;
            //Запускаем измерение времени
            Speedometer.Start();
            //Подготовительный этап, рассчитываем начальные значения точек х1,х2 и значения функции в этих точках
            x1 = MyFunction.Limits.Left + (1 - A) * MyFunction.Limits.Length;
            x2 = MyFunction.Limits.Left + A * MyFunction.Limits.Length;
            fx1 = MyFunction.Calculate(x1);
            fx2 = MyFunction.Calculate(x2);
            //Добавляем начальные точки в график
            Chart.Add(new Point { X = x1, Y = fx1 });
            Chart.Add(new Point { X = x2, Y = fx2 });
            //До тех пор пока длина интервала больше ошибки - выполнять
            while (MyFunction.Limits.Length >= MyFunction.Mistake)
            {
                //Если первое значение больше
                if (fx1 > fx2)
                {
                    //Сдвигаем левую границу в точку x1
                    MyFunction.Limits.Left = x1;
                    //Сохраняем точку х2, она будет учавствовать в следующей итерации
                    x1 = x2;
                    //Сохраняем значение функции в точке
                    fx1 = fx2;
                    //Рассчитываем еще одну точку
                    x2 = MyFunction.Limits.Left + A * MyFunction.Limits.Length;
                    //Рассчитываем значение функции в точке
                    fx2 = MyFunction.Calculate(x2);
                    //Добавляем в коллекцию точек для графика
                    Chart.Add(new Point { X = x2, Y = fx2 });
                }
                else
                {
                    //Иначе сдвигаем правую границу в точку x2
                    MyFunction.Limits.Right = x2;
                    //Сохраняем точку х1, она будет учавствовать в следующей итерации
                    x2 = x1;
                    //Сохраняем значение функции в точке
                    fx2 = fx1;
                    //Рассчитываем еще одну точку
                    x1 = MyFunction.Limits.Left + (1 - A) * MyFunction.Limits.Length;
                    //Рассчитываем значение функции в точке
                    fx1 = MyFunction.Calculate(x1);
                    //Добавляем в коллекцию точек для графика
                    Chart.Add(new Point { X = x1, Y = fx1 });
                }
            }
            //Останавливаем отсчёт времени
            Speedometer.Stop();
            return Chart;
        }

        private static double FibNum(double num)
        {
            if (num <= 1) return num;
            else return (FibNum(num - 1) + FibNum(num - 2));
        }

        public static ObservableCollection<Point> Fibonacci()
        {
            ObservableCollection<Point> Chart = new ObservableCollection<Point>();
            double x1, x2, fx1, fx2; int counter = 1;
            double n = 0;
            double threshold = MyFunction.Limits.Length / MyFunction.Mistake;

            Speedometer.Start();
            while (FibNum(n) <= threshold)
                n++;

            x1 = MyFunction.Limits.Left + (FibNum(n - 2) / FibNum(n)) * MyFunction.Limits.Length;
            x2 = MyFunction.Limits.Left + (FibNum(n - 1) / FibNum(n)) * MyFunction.Limits.Length;
            fx1 = MyFunction.Calculate(x1);
            fx2 = MyFunction.Calculate(x2);
            Chart.Add(new Point { X = x1, Y = fx1 });
            Chart.Add(new Point { X = x2, Y = fx2 });

            while (true)
            {
                if (fx1 > fx2)
                {
                    MyFunction.Limits.Left = x1;
                    x1 = x2;
                    fx1 = fx2;
                    x2 = MyFunction.Limits.Left + (FibNum(n - 1 - counter) / FibNum(n - counter)) * MyFunction.Limits.Length;
                    fx2 = MyFunction.Calculate(x2);
                    Chart.Add(new Point { X = x2, Y = fx2 });
                }
                else
                {
                    MyFunction.Limits.Right = x2;
                    x2 = x1;
                    fx2 = fx1;
                    x1 = MyFunction.Limits.Left + (FibNum(n - 2 - counter) / FibNum(n - counter)) * MyFunction.Limits.Length;                    
                    fx1 = MyFunction.Calculate(x1);
                    Chart.Add(new Point { X = x1, Y = fx1 });
                }
                counter++;
                if (counter == n - 2) break;
            }
            Speedometer.Stop();
            return Chart;
        }

        public static ObservableCollection<Point> Newton()
        {
            ObservableCollection<Point> Chart = new ObservableCollection<Point>();
            double x1, x2;
            x1 = -1.3;

            Speedometer.Start();
            x2 = x1 - MyFunction.CalculateP1(x1) / MyFunction.CalculateP2(x1);
            x1 = x2;
            Chart.Add(new Point { X = x1, Y = MyFunction.Calculate(x1) });
            do
            {
                x2 = x1 - MyFunction.CalculateP1(x1) / MyFunction.CalculateP2(x1);
                x1 = x2;
                Chart.Add(new Point { X = x1, Y = MyFunction.Calculate(x1) });
            }
            while (x2-x1 > MyFunction.Mistake);
            Speedometer.Stop();
            return Chart;
        }

    }
}
