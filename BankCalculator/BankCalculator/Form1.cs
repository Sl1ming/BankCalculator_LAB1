using System;
using System.IO;
using System.Windows.Forms;

namespace BankCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Перевірка правильності введених даних
            if (!double.TryParse(txtAmount.Text, out double principal) || principal <= 0)
            {
                MessageBox.Show("Помилка в полі 'Сума'!\nВведіть додатне число (більше 0).", "Увага");
                return; 
            }

            if (!double.TryParse(txtRate.Text, out double rate) || rate < 0)
            {
               MessageBox.Show("Помилка в полі 'Відсоток'!\nСтавка не може бути меншою за 0.", "Увага");
               return;
            }

            if (!int.TryParse(txtTerm.Text, out int months) || months <= 0)
            {
                MessageBox.Show("Помилка в полі 'Термін'!\nВведіть цілу кількість місяців (більше 0).", "Увага");
                return;
            }

            string resultText = "";
            double resultAmount = 0;

            // 1. РОЗРАХУНОК КРЕДИТУ
            if (rbLoan.Checked) 
            {
                double monthlyRate = (rate / 100) / 12;
                double monthlyPayment = principal * (monthlyRate * Math.Pow(1 + monthlyRate, months)) / (Math.Pow(1 + monthlyRate, months) - 1);
                
                resultAmount = monthlyPayment * months; 
                double overpayment = resultAmount - principal; 

                resultText = $"Тип: Кредит (Ануїтет)\n" +
                             $"Щомісячний платіж: {monthlyPayment:N2} грн\n" +
                             $"Переплата банку: {overpayment:N2} грн\n" +
                             $"Загальна сума до повернення: {resultAmount:N2} грн";
            }
            // 2. ДЕПОЗИТ - ПРОСТІ ВІДСОТКИ
            else if (rbSimple.Checked)
            {
                double profit = principal * (rate / 100) * ((double)months / 12);
                resultAmount = principal + profit;

                resultText = $"Тип: Депозит (Прості відсотки)\n" +
                             $"Чистий прибуток: {profit:N2} грн\n" +
                             $"Загальна сума на кінець: {resultAmount:N2} грн";
            }
            // 3. ДЕПОЗИТ - СКЛАДНІ ВІДСОТКИ
            else if (rbCompound.Checked)
            {
                double monthlyRate = (rate / 100) / 12;
                resultAmount = principal * Math.Pow(1 + monthlyRate, months);
                double profit = resultAmount - principal;

                resultText = $"Тип: Депозит (Складні відсотки, капіталізація)\n" +
                             $"Чистий прибуток: {profit:N2} грн\n" +
                             $"Загальна сума на кінець: {resultAmount:N2} грн";
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть тип розрахунку (Кредит або Депозит).", "Увага");
                return;
            }

            // Вивід результату на екран
            lblResult.Text = resultText;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи є що зберігати
            if (string.IsNullOrWhiteSpace(lblResult.Text) || lblResult.Text == "lblResult")
            {
                MessageBox.Show("Спочатку виконайте розрахунок!", "Увага");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовий файл|*.txt";
            saveFileDialog.Title = "Зберегти банківський звіт";
            saveFileDialog.FileName = "BankReport.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Формуємо красивий текст для файлу
                string report = $"=== БАНКІВСЬКИЙ ЗВІТ ===\n\n" +
                                $"Початкова сума: {txtAmount.Text} грн\n" +
                                $"Річна ставка: {txtRate.Text}%\n" +
                                $"Термін: {txtTerm.Text} міс.\n" +
                                $"---------------------------\n" +
                                $"{lblResult.Text}\n" +
                                $"===========================";

                File.WriteAllText(saveFileDialog.FileName, report);
                MessageBox.Show("Файл успішно збережено!", "Успіх");
            }
        }
    }
}
