   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	    MO_Lab_1   MO_Lab_1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   �charting{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$>  8Одномерные методы оптимизации��5   	   $	��489��6/   $	��748��6<    � DataContext 5   	   ��  �� RelativeSource �� *Self+.��5      �  � ColumnDefinitions 5   
   �� 5	      $
��561* �6   �� 5
      $
��165* �6    � RowDefinitions 5   
   �� 5      $	��134 �6   �� 5      $
��334* �6   .+�5   
   >   8System.Windows.Controls.DataVisualization.Charting.Chart  -   5          Name$ Charts��5   6   $��0��6   $��1��6)   $��Stretch=�6F   $��Stretch=�6b      Axes 5      C   =System.Windows.Controls.DataVisualization.Charting.LinearAxis  =   7System.Windows.Controls.DataVisualization.Charting.Axis   Orientation$ Y=�6&   D   >System.Windows.Controls.DataVisualization.Charting.NumericAxis   Minimum�   �System.Windows.Controls.DataVisualization.Charting.NullableConverter`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]$ -1 66   	   Maximum$	 1 6C   D   >System.Windows.Controls.DataVisualization.Charting.DisplayAxis
   Title$
 Y��6O      ShowGridLines . 6Y     5      $ X=�6&   $ -4 66   $	 2 6C   $
 X��6O    . 6Y   5      �� 5   
   -   5        $��	groupBox1��5   r   $7��1Выберите метод для расчёта��6   $	��105��67   $
��Left=�6D   $��	12,12,0,0q�6_   $	��Top=�6�   $	��386��6�   .��5      �  5      �� 5      $��* �6'   �� 5      $��* �6'    5      �� 5      $��* �6$   �� 5       $��* �6$   .+�5"      	� -   5        $��rbtnDichotomy��5"   a   $#��Метод Дихотомии��6   $��0��68   $��0��6H   $��16��6U   $��10q�6v   	� 5#      -   5        $��rbtnGold��5#   h   $0��*Метод Золотого сечения��6   $��0��6?   $��1��6O   $��16��6\   $��10q�6x   	� 5$      -   5        $��rbtnFibonacci��5$   a   $#��Метод Фибоначчи��6   $��1��68   $��0��6H   $��16��6U   $��10q�6v   	� 5%      -   5        $��
rbtnNewton��5%   _   $��Метод Ньютона��6   $��1��66   $��1��6F   $��16��6S   $��10q�6q   5&      5'      �� 5(   
   -   5        $��btnStart��5(   ]   $��Расчёт��6   $��25��6"   $
��Left=�6.   $��
413,12,0,0q�6I   $	��Top=�6m   $	��115��6�   6�   �� 5)   
   -   5        $��btnClear��5)   f   $#��Очистить график��6   $��25��6+   $
��Left=�67   $��
413,42,0,0q�6R   $	��Top=�6v   $	��115��6�   6�   �� 5*   
   -	   5        $
��list��5*   �   $��1��69   $��2��6I   $��15,55,15,15q�6Z   $��Stretch=�6o   $��Stretch=�6�   ��6   �� *tempVariables+ �� View 5+      �� 5,      .P�5-      ��  �� Width$ 52��6%   $��x��60    �� DisplayMemberBinding 6;   �� *X+�� 5.      $ 52��6%   $
��F(x)��60    6>   �� *Y+5/      51      �� 52   
   -
   5        $��
textBlock1��52   ^   $��1��6   $��20��6$   $
��Left=�60   $��	15,12,0,0q�6K   $ ��Промежуточные��6p   $	��Top=�6�   $	��111��6�   �� 53   
   -   5        $��
textBlock2��53   ^   $��1��6   $��20��6$   $
��Left=�60   $��	62,29,0,0q�6K   $��результаты��6p   $	��Top=�6�   $��64��6�   �� 54   
   -   5        $��txtIteracii��54   O   $��42��6   $
��Left=�6    $��
413,75,0,0q�6;   $�� ��6b   $	��Top=�6j   $	��133��6�   55      56      