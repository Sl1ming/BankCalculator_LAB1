using System.IO;
namespace BankCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            
            double principal, rate, months;

            
            if (!double.TryParse(txtAmount.Text, out principal) || principal <= 0)
            {
                MessageBox.Show("Помилка в полі 'Сума'!\nВведіть додатне число (більше 0).", "Увага");
                return; 
            }

            
            if (!double.TryParse(txtRate.Text, out rate) || rate < 0)
            {
                MessageBox.Show("Помилка в полі 'Відсоток'!\nСтавка не може бути меншою за 0.", "Увага");
                return;
            }

           
            if (!double.TryParse(txtTerm.Text, out months) || months <= 0)
            {
                MessageBox.Show("Помилка в полі 'Термін'!\nВведіть кількість місяців (більше 0).", "Увага");
                return;
            }

            
            double result = principal * (1 + (rate / 100) * (months / 12));

            lblResult.Text = $"Загальна сума: {result:N2} грн";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовий файл|*.txt";
            saveFileDialog.Title = "Зберегти звіт";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                string report = $"Сума: {txtAmount.Text}\n" +
                                $"Ставка: {txtRate.Text}%\n" +
                                $"Срок: {txtTerm.Text} міс.\n" +
                                $"---------------------------\n" +
                                $"{lblResult.Text}";

               
                File.WriteAllText(saveFileDialog.FileName, report);
                MessageBox.Show("Файл успішно збережено!");
            }
        }
    }
}
