using EntityClasses;
using System.ComponentModel;
using System.Data;

namespace TennisAdministrator
{
    public partial class SportForm : Form
    {
        ApplicationDbContext dbContext;
        int activeCellIndex = 0;

        public SportForm()
        {
            InitializeComponent();
            dbContext = new ApplicationDbContext();
            UpdateTable();
            AdjustTable();
            dataGridView1.Rows[activeCellIndex].DefaultCellStyle.BackColor = Color.LightGray;
        }
        private void UpdateTable()
        {
            List<Sport> sports = dbContext.Sports.ToList<Sport>();
            dataGridView1.DataSource = ListToDataTable.Convert<Sport>(sports);
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

            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Name"].DisplayIndex = 1;
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
            SportCreateDialogForm addDialogForm = new SportCreateDialogForm(dbContext);
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
                Sport? sport = dbContext.Sports.FirstOrDefault(s => s.Id == id);

                if (sport is not null)
                {
                    dbContext.Sports.Remove(sport);
                    dbContext.SaveChanges();
                }
                UpdateTable();
                activeCellIndex = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Guid id = Guid.Parse(dataGridView1.Rows[activeCellIndex].Cells["Id"].Value.ToString());
            Sport? sport = dbContext.Sports.FirstOrDefault(s => s.Id == id);
            SportCreateDialogForm addDialogForm = new SportCreateDialogForm(dbContext, sport);
            addDialogForm.ShowDialog();
            UpdateTable();
        }

        private void SportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext?.Dispose();
        }
    }
}
