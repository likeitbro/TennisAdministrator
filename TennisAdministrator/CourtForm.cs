using EntityClasses;
using System.ComponentModel;
using System.Data;

namespace TennisAdministrator
{
    public partial class CourtForm : Form
    {
        ApplicationDbContext dbContext;

        public CourtForm()
        {
            InitializeComponent();
            dbContext = new ApplicationDbContext();
            List<Court> courts = dbContext.Courts.ToList<Court>();
            DataTable dt = ListToDataTable.Convert<Court>(courts);
            dataGridView1.DataSource = dt;
            AdjustTable();
        }

        private void AdjustTable()
        {
            dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.Columns["Name"].DisplayIndex = 0;
            dataGridView1.Columns["Price"].DisplayIndex = 1;
            dataGridView1.Columns["Description"].DisplayIndex = 2;

            dataGridView1.Sort(dataGridView1.Columns["Name"], ListSortDirection.Ascending);

            dataGridView1.Columns["Name"].HeaderText = "Название";
            dataGridView1.Columns["Price"].HeaderText = "Стоимость/час";
            dataGridView1.Columns["Description"].HeaderText = "Описание";

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form? mainForm = Application.OpenForms.Cast<Form>().ToList().Find(f => f.Name == "MainForm");
            if (mainForm != null)
                mainForm.Activate();
            this.Close();
        }

        private void CourtForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext?.Dispose();
            dbContext = null;
        }
    }
}
