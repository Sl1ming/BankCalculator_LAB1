namespace BankCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtAmount = new TextBox();
            txtTerm = new TextBox();
            txtRate = new TextBox();
            lblResult = new Label();
            btnCalculate = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 45);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 0;
            label1.Text = "Сума";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(189, 45);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 1;
            label2.Text = "Річна ставка";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(326, 45);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Срок (міс)";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(37, 78);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(90, 27);
            txtAmount.TabIndex = 3;
            // 
            // txtTerm
            // 
            txtTerm.Location = new Point(326, 78);
            txtTerm.Name = "txtTerm";
            txtTerm.Size = new Size(90, 27);
            txtTerm.TabIndex = 4;
            txtTerm.TextChanged += textBox2_TextChanged;
            // 
            // txtRate
            // 
            txtRate.Location = new Point(189, 78);
            txtRate.Name = "txtRate";
            txtRate.Size = new Size(90, 27);
            txtRate.TabIndex = 5;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(539, 45);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(75, 20);
            lblResult.TabIndex = 6;
            lblResult.Text = "Результат";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(37, 155);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(106, 29);
            btnCalculate.TabIndex = 7;
            btnCalculate.Text = "Розрахувати";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(185, 155);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(btnCalculate);
            Controls.Add(lblResult);
            Controls.Add(txtRate);
            Controls.Add(txtTerm);
            Controls.Add(txtAmount);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtAmount;
        private TextBox txtTerm;
        private TextBox txtRate;
        private Label lblResult;
        private Button btnCalculate;
        private Button btnSave;
    }
}
