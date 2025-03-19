namespace TennisAdministrator
{
    partial class CourtForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            button2 = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.Controls.Add(button2, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 2);
            tableLayoutPanel1.Controls.Add(button1, 5, 1);
            tableLayoutPanel1.Controls.Add(button3, 4, 1);
            tableLayoutPanel1.Controls.Add(button4, 3, 1);
            tableLayoutPanel1.Controls.Add(button5, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1264, 681);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Font = new Font("Segoe UI", 9F);
            button2.Image = Properties.Resources.icons_go_back;
            button2.ImageAlign = ContentAlignment.MiddleRight;
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            tableLayoutPanel1.SetRowSpan(button2, 2);
            button2.Size = new Size(94, 54);
            button2.TabIndex = 9;
            button2.Text = "В меню";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 5);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(103, 0);
            label1.Name = "label1";
            label1.Size = new Size(1158, 30);
            label1.TabIndex = 8;
            label1.Text = "Список кортов";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dataGridView1, 6);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 63);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1258, 615);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Bottom;
            button1.Image = Properties.Resources.icons_add;
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.Location = new Point(1167, 34);
            button1.Name = "button1";
            button1.Size = new Size(94, 23);
            button1.TabIndex = 4;
            button1.Text = "Добавить";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Bottom;
            button3.Image = Properties.Resources.icons_trash;
            button3.ImageAlign = ContentAlignment.MiddleRight;
            button3.Location = new Point(1067, 34);
            button3.Name = "button3";
            button3.Size = new Size(94, 23);
            button3.TabIndex = 5;
            button3.Text = "Удалить";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Bottom;
            button4.Image = Properties.Resources.icons_edit;
            button4.ImageAlign = ContentAlignment.MiddleRight;
            button4.Location = new Point(967, 34);
            button4.Name = "button4";
            button4.Size = new Size(94, 23);
            button4.TabIndex = 6;
            button4.Text = "Изменить";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Bottom;
            button5.Image = Properties.Resources.icons_list;
            button5.ImageAlign = ContentAlignment.MiddleRight;
            button5.Location = new Point(817, 34);
            button5.Name = "button5";
            button5.Size = new Size(144, 23);
            button5.TabIndex = 7;
            button5.Text = "Свободные места";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            button5.Click += button5_Click;
            // 
            // CourtForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(640, 360);
            Name = "CourtForm";
            ShowIcon = false;
            Text = "Список кортов";
            FormClosing += CourtForm_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button2;
        private Label label1;
    }
}