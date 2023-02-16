﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private DispatcherTimer _timer;

        public Page1()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 3);
            _timer.Tick += IdleTick;
            _timer.Start();
        }

        private void IdleTick(object sender, EventArgs e)
        {
            var idle = GetIdle();
            if (idle.Seconds >= 5) // время бездейстия в сек.
            {
                MessageBox.Show("Приложение не используется, можете его закрыть!");
            }
        }
        TimeSpan GetIdle()
        {
            var lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);

            GetLastInputInfo(ref lastInputInfo);

            var lastInput = DateTime.Now.AddMilliseconds(
                -(Environment.TickCount - lastInputInfo.dwTime));
            return DateTime.Now - lastInput;
        }

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }
        static int counter = 0; //статическое поле формы
        async void Enter_Click(object sender, RoutedEventArgs e)
        {

            counter++;
            if (Password.Text == "пароль" && Login.Text == "логин") // проверяем пароль так или другими способами
            {
                
                NavigationService.Navigate(new Page2());
            }
            else if (counter >= 3) // лимит превышен
            {
                MessageBox.Show("Данные введены неправильно, поля заблокированы на определенное время!!!");
                Login.IsEnabled = false;
                Password.IsEnabled = false;
                await Task.Delay(10000);
                MessageBox.Show("Поле разблокировано, попробуйте еще раз!");
                Login.IsEnabled = true;
                Password.IsEnabled = true;
            }
        }
        private void Exitt_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
        }
    }
}
