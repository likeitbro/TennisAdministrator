using EntityClasses;
using System.ComponentModel;
using System.Data;

namespace TennisAdministrator
{
    public partial class CourtForm : Form
    {
        ApplicationDbContext dbContext;
        int activeCellIndex = -1;

        public CourtForm()
        {
            InitializeComponent();
            dbContext = new ApplicationDbContext();
            UpdateTable();
            AdjustTable();
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

            //DataGridViewButtonColumn updateColumn =
            //new DataGridViewButtonColumn();
            //updateColumn.HeaderText = "Изменить";
            //updateColumn.Name = "Update";
            //updateColumn.Text = "✎";
            //updateColumn.DefaultCellStyle.BackColor = Color.DarkBlue;
            //updateColumn.UseColumnTextForButtonValue = true;

            //DataGridViewButtonColumn deleteColumn =
            //new DataGridViewButtonColumn();
            //deleteColumn.HeaderText = "Удалить";
            //deleteColumn.Name = "Delete";
            //deleteColumn.Text = "🗑";
            //deleteColumn.DefaultCellStyle.BackColor = Color.Red;
            //deleteColumn.UseColumnTextForButtonValue = true;

            //dataGridView1.Columns.AddRange(updateColumn, deleteColumn);

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

            if (senderGrid.Columns[e.ColumnIndex].Name == "Delete" && e.RowIndex >= 0)
            {
                var confirmResult = MessageBox.Show("Вы уверены, что желаете удалить объект?",
                                                    "Подтверждение удаления",
                                                    MessageBoxButtons.OKCancel);
                if (confirmResult == DialogResult.OK)
                {
                    Guid id = Guid.Parse(senderGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                    Court? court = dbContext.Courts.FirstOrDefault(c => c.Id == id);

                    if (court is not null)
                    {
                        dbContext.Courts.Remove(court);
                        dbContext.SaveChanges();
                    }
                    UpdateTable();
                }
            }
            if (senderGrid.Columns[e.ColumnIndex].Name == "Update" && e.RowIndex >= 0)
            {
                Guid id = Guid.Parse(senderGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                Court? court = dbContext.Courts.FirstOrDefault(c => c.Id == id);
                CourtCreateDialogForm addDialogForm = new CourtCreateDialogForm(dbContext, court);
                addDialogForm.ShowDialog();
                UpdateTable();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var confirmResult = MessageBox.Show("Вы уверены, что желаете удалить объект?",
            //                                        "Подтверждение удаления",
            //                                        MessageBoxButtons.OKCancel);
            //if (confirmResult == DialogResult.OK)
            //{
            //    Guid id = Guid.Parse(senderGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            //    Court? court = dbContext.Courts.FirstOrDefault(c => c.Id == id);

            //    if (court is not null)
            //    {
            //        dbContext.Courts.Remove(court);
            //        dbContext.SaveChanges();
            //    }
            //    UpdateTable();
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Guid id = Guid.Parse(senderGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            //Court? court = dbContext.Courts.FirstOrDefault(c => c.Id == id);
            //CourtCreateDialogForm addDialogForm = new CourtCreateDialogForm(dbContext, court);
            //addDialogForm.ShowDialog();
            //UpdateTable();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
