using EntityClasses;
using EntityClasses.Sales;
using System.ComponentModel;
using System.Data;

namespace TennisAdministrator
{
    public partial class SaleForm : Form
    {
        ApplicationDbContext dbContext;
        int activeCellIndex = 0;

        public SaleForm()
        {
            InitializeComponent();
            dbContext = new ApplicationDbContext();
            UpdateTable();
            AdjustTable();
            dataGridView1.Rows[activeCellIndex].DefaultCellStyle.BackColor = Color.LightGray;
        }
        private void UpdateTable()
        {
            List<Sale> sales = dbContext.Sales.ToList();
            DataTable dt = new DataTable();
            dt.Clear();

            List<string> cols = [
                "Id",
                "ClientLastName",
                "ClientFirstName",
                "SaleTime",
                "SaleRevenue"
                ];
            foreach (string col in cols)
                dt.Columns.Add(col);
            foreach (Sale sale in sales)
            {
                dt.Rows.Add(sale.Id,
                    sale.Client.LastName,
                    sale.Client.FirstName,
                    sale.SaleTime,
                    sale.Revenue);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Sort(dataGridView1.Columns["SaleTime"], ListSortDirection.Descending);
        }

        private void AdjustTable()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.Sort(dataGridView1.Columns["Name"], ListSortDirection.Ascending);

            dataGridView1.Columns["ClientLastName"].HeaderText = "Фамилия клиента";
            dataGridView1.Columns["ClientFirstName"].HeaderText = "Имя клиента";
            dataGridView1.Columns["SaleTime"].HeaderText = "Время продажи";
            dataGridView1.Columns["SaleRevenue"].HeaderText = "Выручка";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form? mainForm = Application.OpenForms.Cast<Form>().ToList().Find(f => f.Name == "MainForm");
            if (mainForm != null)
                mainForm.Activate();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CourtCreateDialogForm addDialogForm = new CourtCreateDialogForm(dbContext);
            addDialogForm.ShowDialog();
            UpdateTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[activeCellIndex].DefaultCellStyle.BackColor = Color.White;
                activeCellIndex = e.RowIndex;
                dataGridView1.Rows[activeCellIndex].DefaultCellStyle.BackColor = Color.LightGray;
                button3.Visible = true;
                button4.Visible = true;
            }
            else
            {
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Вы уверены, что желаете удалить объект?",
                                                    "Подтверждение удаления",
                                                    MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.OK)
            {
                Guid id = Guid.Parse(dataGridView1.Rows[activeCellIndex].Cells["Id"].Value.ToString());
                Sale? sale = dbContext.Sales.FirstOrDefault(s => s.Id == id);

                if (sale is not null)
                {
                    dbContext.Sales.Remove(sale);
                    dbContext.SaveChanges();
                }
                UpdateTable();
                activeCellIndex = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Guid id = Guid.Parse(dataGridView1.Rows[activeCellIndex].Cells["Id"].Value.ToString());
            Sale? sale = dbContext.Sales.FirstOrDefault(s => s.Id == id);
            CourtCreateDialogForm addDialogForm = new CourtCreateDialogForm(dbContext, court);
            addDialogForm.ShowDialog();
            UpdateTable();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void SaleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext?.Dispose();
        }
    }
}
