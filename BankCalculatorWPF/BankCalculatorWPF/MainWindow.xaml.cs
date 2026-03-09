using System;
using System.IO;            // Для роботи з файлами (File.WriteAllText)
using System.Windows;       // Базові класи WPF
using Microsoft.Win32;      // ВАЖЛИВО! Це потрібно для SaveFileDialog у WPF

namespace BankCalculatorWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Логіка кнопки "Розрахувати"
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double principal, rate, months;

            // Ваша перевірка даних (Валідація)
            if (!double.TryParse(txtAmount.Text, out principal) || principal <= 0)
            {
                MessageBox.Show("Помилка в полі 'Сума'!\nВведіть додатне число.", "Увага");
                return;
            }

            if (!double.TryParse(txtRate.Text, out rate) || rate < 0)
            {
                MessageBox.Show("Помилка в полі 'Відсоток'!\nСтавка не може бути від'ємною.", "Увага");
                return;
            }

            if (!double.TryParse(txtTerm.Text, out months) || months <= 0)
            {
                MessageBox.Show("Помилка в полі 'Термін'!\nВведіть кількість місяців.", "Увага");
                return;
            }

            // Ваш розрахунок (річна ставка ділиться на 12)
            double result = principal * (1 + (rate / 100) * (months / 12));

            // Виведення результату
            lblResult.Text = $"Загальна сума: {result:N2} грн";
        }

        // Логіка кнопки "Зберегти"
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // У WPF SaveFileDialog знаходиться в просторі Microsoft.Win32
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовий файл (*.txt)|*.txt";
            saveFileDialog.Title = "Зберегти звіт";

            // У WPF метод ShowDialog повертає true/false (bool?), а не DialogResult
            if (saveFileDialog.ShowDialog() == true)
            {
                string report = $"Сума: {txtAmount.Text}\n" +
                                $"Ставка: {txtRate.Text}%\n" +
                                $"Термін: {txtTerm.Text} міс.\n" +
                                $"---------------------------\n" +
                                $"{lblResult.Text}";

                File.WriteAllText(saveFileDialog.FileName, report);
                MessageBox.Show("Файл успішно збережено!");
            }
        }
    }
}