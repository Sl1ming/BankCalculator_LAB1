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
            groupBox1 = new GroupBox();
            rbCompound = new RadioButton();
            rbSimple = new RadioButton();
            rbLoan = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(130, 133);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 0;
            label1.Text = "Сума (грн)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(307, 133);
            label2.Name = "label2";
            label2.Size = new Size(139, 25);
            label2.TabIndex = 1;
            label2.Text = "Річна ставка (%)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(496, 133);
            label3.Name = "label3";
            label3.Size = new Size(90, 25);
            label3.TabIndex = 2;
            label3.Text = "Срок (міс)";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(130, 171);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(101, 30);
            txtAmount.TabIndex = 3;
            // 
            // txtTerm
            // 
            txtTerm.Location = new Point(496, 171);
            txtTerm.Name = "txtTerm";
            txtTerm.Size = new Size(101, 30);
            txtTerm.TabIndex = 4;
            // 
            // txtRate
            // 
            txtRate.Location = new Point(307, 171);
            txtRate.Name = "txtRate";
            txtRate.Size = new Size(110, 30);
            txtRate.TabIndex = 5;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.BorderStyle = BorderStyle.FixedSingle;
            lblResult.Location = new Point(496, 242);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(88, 25);
            lblResult.TabIndex = 6;
            lblResult.Text = "Результат";
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.DarkTurquoise;
            btnCalculate.FlatAppearance.BorderSize = 0;
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCalculate.ForeColor = SystemColors.ControlText;
            btnCalculate.Location = new Point(207, 403);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(250, 52);
            btnCalculate.TabIndex = 7;
            btnCalculate.Text = "Розрахувати";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(496, 352);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(106, 33);
            btnSave.TabIndex = 8;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbCompound);
            groupBox1.Controls.Add(rbSimple);
            groupBox1.Controls.Add(rbLoan);
            groupBox1.Location = new Point(207, 233);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 152);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Тип операції";
            // 
            // rbCompound
            // 
            rbCompound.AutoSize = true;
            rbCompound.Location = new Point(0, 109);
            rbCompound.Name = "rbCompound";
            rbCompound.Size = new Size(242, 27);
            rbCompound.TabIndex = 12;
            rbCompound.TabStop = true;
            rbCompound.Text = "Депозит (Складні відсотки)";
            rbCompound.UseVisualStyleBackColor = true;
            // 
            // rbSimple
            // 
            rbSimple.AutoSize = true;
            rbSimple.Location = new Point(0, 76);
            rbSimple.Name = "rbSimple";
            rbSimple.Size = new Size(233, 27);
            rbSimple.TabIndex = 11;
            rbSimple.TabStop = true;
            rbSimple.Text = "Депозит (Прості відсотки)";
            rbSimple.UseVisualStyleBackColor = true;
            // 
            // rbLoan
            // 
            rbLoan.AutoSize = true;
            rbLoan.Location = new Point(0, 43);
            rbLoan.Name = "rbLoan";
            rbLoan.Size = new Size(86, 27);
            rbLoan.TabIndex = 10;
            rbLoan.TabStop = true;
            rbLoan.Text = "Кредит";
            rbLoan.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(900, 518);
            Controls.Add(groupBox1);
            Controls.Add(btnSave);
            Controls.Add(btnCalculate);
            Controls.Add(lblResult);
            Controls.Add(txtRate);
            Controls.Add(txtTerm);
            Controls.Add(txtAmount);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private GroupBox groupBox1;
        private RadioButton rbSimple;
        private RadioButton rbLoan;
        private RadioButton rbCompound;
    }
}
