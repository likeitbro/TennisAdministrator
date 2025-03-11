namespace TennisAdministrator
{
    partial class CourtCreateDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            errorLabel1 = new Label();
            errorLabel2 = new Label();
            errorLabel3 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 5);
            tableLayoutPanel1.Controls.Add(textBox1, 1, 1);
            tableLayoutPanel1.Controls.Add(textBox2, 1, 3);
            tableLayoutPanel1.Controls.Add(textBox3, 1, 5);
            tableLayoutPanel1.Controls.Add(button1, 1, 7);
            tableLayoutPanel1.Controls.Add(errorLabel1, 1, 2);
            tableLayoutPanel1.Controls.Add(errorLabel2, 1, 4);
            tableLayoutPanel1.Controls.Add(errorLabel3, 1, 6);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(468, 196);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 2);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(462, 30);
            label1.TabIndex = 0;
            label1.Text = "Добавить новый корт";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(111, 30);
            label2.TabIndex = 1;
            label2.Text = "Название";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 75);
            label3.Name = "label3";
            label3.Size = new Size(111, 30);
            label3.TabIndex = 2;
            label3.Text = "Стоимость/час";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 120);
            label4.Name = "label4";
            label4.Size = new Size(111, 30);
            label4.TabIndex = 3;
            label4.Text = "Описание";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(120, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(345, 23);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(120, 78);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(345, 23);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(120, 123);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(345, 23);
            textBox3.TabIndex = 6;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Right;
            button1.Location = new Point(359, 168);
            button1.Name = "button1";
            button1.Size = new Size(106, 25);
            button1.TabIndex = 7;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            // 
            // errorLabel1
            // 
            errorLabel1.AutoSize = true;
            errorLabel1.Dock = DockStyle.Fill;
            errorLabel1.ForeColor = Color.Red;
            errorLabel1.Location = new Point(120, 60);
            errorLabel1.Name = "errorLabel1";
            errorLabel1.Size = new Size(345, 15);
            errorLabel1.TabIndex = 8;
            errorLabel1.Text = "errorLabel1";
            errorLabel1.Visible = false;
            // 
            // errorLabel2
            // 
            errorLabel2.AutoSize = true;
            errorLabel2.Dock = DockStyle.Fill;
            errorLabel2.ForeColor = Color.Red;
            errorLabel2.Location = new Point(120, 105);
            errorLabel2.Name = "errorLabel2";
            errorLabel2.Size = new Size(345, 15);
            errorLabel2.TabIndex = 9;
            errorLabel2.Text = "errorLabel2";
            errorLabel2.Visible = false;
            // 
            // errorLabel3
            // 
            errorLabel3.AutoSize = true;
            errorLabel3.Dock = DockStyle.Fill;
            errorLabel3.ForeColor = Color.Red;
            errorLabel3.Location = new Point(120, 150);
            errorLabel3.Name = "errorLabel3";
            errorLabel3.Size = new Size(345, 15);
            errorLabel3.TabIndex = 10;
            errorLabel3.Text = "errorLabel3";
            errorLabel3.Visible = false;
            // 
            // CourtCreateDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 196);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CourtCreateDialogForm";
            ShowIcon = false;
            Text = "Изменениие данных о кортах";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private Label errorLabel1;
        private Label errorLabel2;
        private Label errorLabel3;
    }
}