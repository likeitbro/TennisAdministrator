using EntityClasses;
using System.ComponentModel;
using System.Data;

namespace TennisAdministrator
{
    public partial class CourtForm : Form
    {
        ApplicationDbContext dbContext;
        int activeCellIndex = 0;

        public CourtForm()
        {
            InitializeComponent();
            dbContext = new ApplicationDbContext();
            UpdateTable();
            AdjustTable();
            dataGridView1.Rows[activeCellIndex].DefaultCellStyle.BackColor = Color.LightGray;
        }
        private void UpdateTable()
        {
            List<Court> courts = dbContext.Courts.ToList<Court>();
            dataGridView1.DataSource = ListToDataTable.Convert<Court>(courts);
            dataGridView1.Sort(dataGridView1.Columns["Name"], ListSortDirection.Ascending);
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

            dataGridView1.Columns["Name"].HeaderText = "Название";
            dataGridView1.Columns["Price"].HeaderText = "Стоимость/час";
            dataGridView1.Columns["Description"].HeaderText = "Описание";

            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Name"].DisplayIndex = 1;
            dataGridView1.Columns["Price"].DisplayIndex = 2;
            dataGridView1.Columns["Description"].DisplayIndex = 3;
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
            CourtCreateDialogForm addDialogForm = new CourtCreateDialogForm(dbContext);
            addDialogForm.ShowDialog();
            UpdateTable();
        }

        private void CourtForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext?.Dispose();
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
                button5.Visible = true;
            }
            else
            {
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
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
                Court? court = dbContext.Courts.FirstOrDefault(c => c.Id == id);

                if (court is not null)
                {
                    dbContext.Courts.Remove(court);
                    dbContext.SaveChanges();
                }
                UpdateTable();
                activeCellIndex = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Guid id = Guid.Parse(dataGridView1.Rows[activeCellIndex].Cells["Id"].Value.ToString());
            Court? court = dbContext.Courts.FirstOrDefault(c => c.Id == id);
            CourtCreateDialogForm addDialogForm = new CourtCreateDialogForm(dbContext, court);
            addDialogForm.ShowDialog();
            UpdateTable();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
