using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridView gridView = new GridView();

        private enum WeekDay { SUNDAY, MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GridViewColumn gridViewColumn = new GridViewColumn();
            gridView.AllowsColumnReorder = false;
            gridViewColumn.DisplayMemberBinding = new Binding("DayName");
            gridViewColumn.Width = 180;
            gridViewColumn.Header = "День недели";
            gridView.Columns.Add(gridViewColumn);
            gridViewColumn = new GridViewColumn();
            gridViewColumn.DisplayMemberBinding = new Binding("DayNumber");
            gridViewColumn.Width = 100;
            gridViewColumn.Header = "Число";
            gridView.Columns.Add(gridViewColumn);
        }

        private void monthChoice_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem selectedItem = (TreeViewItem)monthChoice.SelectedItem;
            List<DayOfMonth> daysOfMonthList = new List<DayOfMonth>();
            DateTime date;
            string dayName = null;
            if (selectedItem.Parent.GetType() == selectedItem.GetType())
            {
                date = new DateTime(DateTime.Now.Year, Convert.ToInt32(selectedItem.Uid), 1);
                do
                {
                    switch ((int)date.DayOfWeek)
                    {
                        case (int)WeekDay.MONDAY:
                            dayName = "Понедельник";
                            break;
                        case (int)WeekDay.TUESDAY:
                            dayName = "Вторник";
                            break;
                        case (int)WeekDay.WEDNESDAY:
                            dayName = "Среда";
                            break;
                        case (int)WeekDay.THURSDAY:
                            dayName = "Четверг";
                            break;
                        case (int)WeekDay.FRIDAY:
                            dayName = "Пятница";
                            break;
                        case (int)WeekDay.SATURDAY:
                            dayName = "Суббота";
                            break;
                        case (int)WeekDay.SUNDAY:
                            dayName = "Воскресенье";
                            break;
                    }
                    daysOfMonthList.Add(new DayOfMonth(dayName, date.Day));
                    date = date.AddDays(1);
                }
                while (date.Day != 1);
                calendarView.ItemsSource = daysOfMonthList;
                calendarView.View = gridView;
            }
            else
            {
                calendarView.ItemsSource = null;
                calendarView.View = null;
            }
        }
    }
}