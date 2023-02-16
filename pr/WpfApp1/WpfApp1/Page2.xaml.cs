﻿using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }
        // кнопка выход
        void CloseWindow(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainWindow());
        }
        // кнопка сохранения в файл
        void SaveWindow(object sender, EventArgs e)
        {
            int EmptyTxt = 0;
            string str1 = "";
            string str2 = "";
            int same = 0;
            using (StreamReader SR = new StreamReader("employee.txt", true))
            {
                if (SR.ReadLine() != "")
                {
                    EmptyTxt = 1;
                }
            }
            if (ID.Text == "" || Surname.Text == "" || Name.Text == "" || Otch.Text == "" || Pasport.Text == "" || Phone.Text == "" || Email.Text == "")
            {
                MessageBox.Show("Одно из полей пустое, его небходимо заполнить!!!");
            }
            else if (EmptyTxt == 0)
            {
                using (StreamWriter SW = new StreamWriter("employee.txt", true))
                {
                    SW.Write(ID.Text + "\t" + Surname.Text + "\t" + Name.Text + "\t" + Otch.Text + "\t" + Pasport.Text + "\t" + Phone.Text + " \t" + Email.Text + "@firma.ru\n");
                }
            }
            else
            {
                using (StreamReader SR = new StreamReader("employee.txt", true))
                {
                    while (!SR.EndOfStream)
                    {
                        str2 = "";
                        str1 = "";
                        str1 = SR.ReadLine();
                        int i = 0;
                        while (str1[i] != ' ')
                        {
                            str2 += str1[i];
                            i++;
                        }
                        MessageBox.Show(str2);
                        if (str2 == ID.Text)
                        {
                            MessageBox.Show("Уже есть сотрудник с таким идентификатором");
                            same = 1;
                            break;
                        }
                    }
                }
                if (same == 0)
                {
                    using (StreamWriter SW = new StreamWriter(@"employee.txt", true))
                    {
                        SW.WriteLine(ID.Text + "\t" + Surname.Text + "\t" + Name.Text + "\t" + Otch.Text + "\t" + Pasport.Text + "\t" + Phone.Text + "\t" + Email.Text + "@firma.ru");
                    }
                }
                same = 0;
            }
        }

        // идентификатор
        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            i = ID.Text.Length - 1;
            if (ID.Text == "")
            {
                i = 1;
            }
            else if (ID.Text.Length > 0)
            {
                if (!(ID.Text[i] <= '9' && ID.Text[i] >= '0'))
                {
                    MessageBox.Show("Неверный символ, допускается использование только арабских цифр!!!");
                }
            }
        }
        // Фамилия
        private void Surname_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            int i;
            if (Surname.Text == "")
            {
                i = 0;
            }
            else if (!(Surname.Text[0] >= 'А' && Surname.Text[0] <= 'Я'))
            {
                MessageBox.Show("Фамилию необходимо писать с заглавной буквы!!!");
            }
            i = Surname.Text.Length - 1;
            if (i > 0)
            {
                if (!(Surname.Text[i] >= 'а' && Surname.Text[i] <= 'я'))
                {
                    MessageBox.Show("Проверьте правильность написания фамилии(Возможно в фамилии присутствуют ошибки/заглавные буквы!!!)");
                }
            }
        }
        // Имя
        private void Name_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            int i;
            if (Name.Text == "")
            {
                i = 0;
            }
            else if (!(Name.Text[0] >= 'А' && Name.Text[0] <= 'Я'))
            {
                MessageBox.Show("Имя необходимо писать с заглавной буквы!!!");
            }
            i = Name.Text.Length - 1;
            if (i > 0)
            {
                if (!(Name.Text[i] >= 'а' && Name.Text[i] <= 'я'))
                {
                    MessageBox.Show("Проверьте правильность написания имени(Возможно в имени присутствуют ошибки/заглавные буквы!!!)");
                }
            }
        }
        // Отчество
        private void Otch_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            if (Otch.Text == "")
            {
                i = 0;
            }
            else if (!(Otch.Text[0] >= 'А' && Otch.Text[0] <= 'Я'))
            {
                MessageBox.Show("Отчество необходимо писать с заглавной буквы!!!");
            }
            i = Otch.Text.Length - 1;
            if (i > 0)
            {
                if (!(Otch.Text[i] >= 'а' && Otch.Text[i] <= 'я'))
                {
                    MessageBox.Show("Проверьте правильность написания отчества(Возможно в отчестве присутствуют ошибки/заглавные буквы!!!)");
                }
            }
        }
        // Паспорт
        private void Pasport_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            i = Pasport.Text.Length - 1;
            if (Pasport.Text == "")
            {
                i = 0;
            }
            else if (Pasport.Text.Length > 0)
            {
                if (!(Pasport.Text[i] <= '9' && Pasport.Text[i] >= '0'))
                {
                    MessageBox.Show("Неверный символ, допускается использование только арабских цифр!!!");
                }
                else if (Pasport.Text.Length == 10)
                {
                    MessageBox.Show("Номер и серия имеют объем 10 символов!!!");
                }
            }
        }
        // Мобильный телефон
        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            i = Phone.Text.Length - 1;
            if (Phone.Text == "")
            {
                i = 0;
            }
            else if (Phone.Text[0] != '8' && Phone.Text[0] != '+')
            {
                MessageBox.Show("Номер телефона должен начинаться с 8 или с +7");
            }
            else if (i > 0 && Phone.Text[0] == '+' && Phone.Text[1] != '7')
            {
                MessageBox.Show("Номер телефона должен начинаться с 8 или с +7");
            }
            if (i > 0)
            {
                if (!(Phone.Text[i] <= '9' && Phone.Text[i] >= '0'))
                {
                    MessageBox.Show("Неверный символ, номер телефона может состоять только из арабских цифр");
                }
                else if (Phone.Text[0] == '8' && Phone.Text.Length == 12)
                {
                    MessageBox.Show("Лишняя цифра!!!");
                }
                else if (Phone.Text[0] == '+' && Phone.Text[1] == '7' && Phone.Text.Length == 13)
                {
                    MessageBox.Show("Лишняя цифра!!!");
                }
            }
        }
        // Email
        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;
            if (Email.Text == "")
            {
                i = 0;
            }
            else if (!(Email.Text[0] >= 'A' && Email.Text[0] <= 'Z' || Email.Text[0] >= 'a' && Email.Text[0] <= 'z'))
            {
                MessageBox.Show("Email должен начинаться с латинской буквы");
            }
            i = Email.Text.Length - 1;
            if (i > 0)
            {
                if (!(Email.Text[i] >= 'A' && Email.Text[i] <= 'Z' || Email.Text[i] >= 'a' && Email.Text[i] <= 'z') && !(Email.Text[i] <= '9' && Email.Text[i] >= '0') && Email.Text[i] != '_')
                {
                    MessageBox.Show("Неверный символ, Email может состоять только из латинских букв, арабских цифр и знака подчеркивания");
                }
            }

        }
    }
}
