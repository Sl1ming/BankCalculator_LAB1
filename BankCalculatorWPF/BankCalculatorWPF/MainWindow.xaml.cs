using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace BankCalculatorWPF
{
    public partial class MainWindow : Window
    {
        private string currentReportForSaving = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private (double total, double profit) CalculateSimpleDeposit(double P, double r, double t)
        {
            double profit = P * (r / 100) * (t / 12);
            double total = P + profit;
            return (total, profit);
        }

        private (double total, double profit) CalculateCompoundDeposit(double P, double r, double t)
        {
            double monthlyRate = r / 100 / 12;
            double total = P * Math.Pow(1 + monthlyRate, t);
            double profit = total - P;
            return (total, profit);
        }

        private (double totalPayable, double overpayment, double monthly) CalculateAnnuityLoan(double P, double r, double t)
        {
            double monthlyRate = r / 100 / 12;
            if (monthlyRate == 0) return (P, 0, P / t);
            double annuityRatio = (monthlyRate * Math.Pow(1 + monthlyRate, t)) / (Math.Pow(1 + monthlyRate, t) - 1);
            double monthlyPayment = P * annuityRatio;
            double totalPayable = monthlyPayment * t;
            double overpayment = totalPayable - P;
            return (totalPayable, overpayment, monthlyPayment);
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtAmount.Text, out double principal) || principal <= 0)
            {
                ShowError("Введіть коректну суму (додатне число).");
                return;
            }
            if (!double.TryParse(txtRate.Text, out double rate) || rate < 0)
            {
                ShowError("Введіть коректну ставку (не від'ємну).");
                return;
            }
            if (!double.TryParse(txtTerm.Text, out double months) || months <= 0)
            {
                ShowError("Введіть термін у місяцях (додатне число).");
                return;
            }

            string operationType = "";
            lblResultMain.Foreground = (Brush)new BrushConverter().ConvertFrom("#27AE60");

            switch (cmbType.SelectedIndex)
            {
                case 0:
                    operationType = "Депозит (Прості %)";
                    var simple = CalculateSimpleDeposit(principal, rate, months);
                    lblResultMain.Text = $"{simple.total:N2} грн";
                    lblResultDetails.Text = $"Початкова сума: {principal:N2} грн\nЧистий прибуток: {simple.profit:N2} грн";
                    break;
                case 1:
                    operationType = "Депозит (Складні %)";
                    var compound = CalculateCompoundDeposit(principal, rate, months);
                    lblResultMain.Text = $"{compound.total:N2} грн";
                    lblResultDetails.Text = $"Початкова сума: {principal:N2} грн\nПрибуток (капіталізація): {compound.profit:N2} грн";
                    break;
                case 2:
                    operationType = "Кредит (Ануїтет)";
                    lblResultMain.Foreground = (Brush)new BrushConverter().ConvertFrom("#C0392B");
                    var loan = CalculateAnnuityLoan(principal, rate, months);
                    lblResultMain.Text = $"{loan.totalPayable:N2} грн";
                    lblResultDetails.Text = $"Сума кредиту: {principal:N2} грн\nЩомісячний платіж: {loan.monthly:N2} грн\nПереплата банку: {loan.overpayment:N2} грн";
                    break;
            }

            resultBorder.Visibility = Visibility.Visible;
            btnSave.IsEnabled = true;

            currentReportForSaving = $"--- ЗВІТ BANKIQ ---\n" +
                                      $"Дата: {DateTime.Now:g}\n" +
                                      $"Тип: {operationType}\n" +
                                      $"-------------------\n" +
                                      $"Вхідні дані:\n" +
                                      $"  Сума: {principal:N2} грн\n" +
                                      $"  Ставка: {rate}% річних\n" +
                                      $"  Термін: {months} міс.\n" +
                                      $"-------------------\n" +
                                      $"РЕЗУЛЬТАТ:\n" +
                                      $"  Загальна сума: {lblResultMain.Text}\n" +
                                      $"{lblResultDetails.Text.Replace("\n", "\n  ")}\n" +
                                      $"-------------------";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentReportForSaving)) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовий файл (*.txt)|*.txt";
            saveFileDialog.Title = "Зберегти банківський звіт";
            saveFileDialog.FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmm}";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, currentReportForSaving);
                    MessageBox.Show("Звіт успішно збережено!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні файлу: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
            resultBorder.Visibility = Visibility.Collapsed;
            btnSave.IsEnabled = false;
        }
    }
}