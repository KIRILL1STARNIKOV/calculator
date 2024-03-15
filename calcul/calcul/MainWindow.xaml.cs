using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calcul
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private double firstNumber;
        private char operation;
        private bool isNewNumber = true;
        //фкнция на добавления циферки 
        private void Number_Click(object sender, RoutedEventArgs e)
        {

            if (isNewNumber==true)
            {
                resultTextBox.Clear();
                isNewNumber = false;
            }

            Button button = (Button)sender;
            resultTextBox.Text += button.Content.ToString();
        }
        //код на сохранения циферки и выбор операции
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(resultTextBox.Text))
            {
                resultTextBox.Text = "Ошибка: введите первое число";
                return;
            }
            Button buttonopers = (Button)sender;
            firstNumber = double.Parse(resultTextBox.Text);
            operation = char.Parse(buttonopers.Content.ToString());
            isNewNumber = true;
        }

        private void buttonEqual_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(resultTextBox.Text))
            {
                resultTextBox.Text = "Ошибка: введите первое число";
                return;
            }
            double secondNumber = double.Parse(resultTextBox.Text);
            double result = 0;
            switch (operation)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    break;
                case '/':
                    if (secondNumber == 0)
                    {
                        resultTextBox.Text = "Ошибка: деление на ноль";
                        return;
                    }
                    else
                    {
                        result = firstNumber / secondNumber;
                    }
                    break;
            }
            resultTextBox.Text = result.ToString();
            isNewNumber = true;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Clear();
            isNewNumber = true;
        }
    }
}
