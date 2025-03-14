using EntityClasses;
using EntityClasses.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace TennisAdministrator
{
    public partial class TrainerForm : Form
    {
        ApplicationDbContext dbContext;

        public TrainerForm()
        {
            InitializeComponent();
            dbContext = new ApplicationDbContext();
            UpdateTable();
            AdjustTable();
        }

        private void UpdateTable()
        {
            List<TrainerType> trainerTypes = dbContext.TrainerTypes.ToList();
            List<Trainer> trainers = dbContext.Trainers.ToList();
            DataTable dt = new DataTable();
            dt.Clear();

            List<string> cols = [
                "Id",
                "TypeName",
                "LastName",
                "FirstName",
                "Price",
                "Birthday",
                "Phone",
                "Experience"
                ];
            foreach (string col in cols)
                dt.Columns.Add(col);

            foreach (TrainerType trainerType in trainerTypes)
            {
                var row = dt.Rows.Add(trainerType.Id, trainerType.Name);
                foreach (Trainer trainer in trainers.Where(t => t.TrainerTypeId == trainerType.Id))
                {
                    dt.Rows.Add(trainer.Id,
                        trainerType.Name,
                        trainer.LastName,
                        trainer.FirstName,
                        trainer.Price,
                        trainer.Birthday,
                        trainer.Phone,
                        trainer.Experience.Year);
                }
            }
            dataGridView1.DataSource = dt;
        }

        private void AdjustTable()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.SortMode = DataGridViewColumnSortMode.NotSortable);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.Columns["TypeName"].HeaderText = "Категория тренеров";
            dataGridView1.Columns["LastName"].HeaderText = "Фамилия";
            dataGridView1.Columns["FirstName"].HeaderText = "Имя";
            dataGridView1.Columns["Price"].HeaderText = "Стоимость/час";
            dataGridView1.Columns["Birthday"].HeaderText = "День рождения";
            dataGridView1.Columns["Phone"].HeaderText = "Телефон";
            dataGridView1.Columns["Experience"].HeaderText = "Тренерский стаж с";

            DataGridViewButtonColumn updateColumn =
            new DataGridViewButtonColumn();
            updateColumn.HeaderText = "Изменить";
            updateColumn.Name = "Update";
            updateColumn.Text = "✎";
            updateColumn.DefaultCellStyle.BackColor = Color.DarkBlue;
            updateColumn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn deleteColumn =
            new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "Удалить";
            deleteColumn.Name = "Delete";
            deleteColumn.Text = "🗑";
            deleteColumn.DefaultCellStyle.BackColor = Color.Red;
            deleteColumn.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.AddRange(updateColumn, deleteColumn);

            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["TypeName"].DisplayIndex = 1;
            dataGridView1.Columns["LastName"].DisplayIndex = 2;
            dataGridView1.Columns["FirstName"].DisplayIndex = 3;
            dataGridView1.Columns["Price"].DisplayIndex = 4;
            dataGridView1.Columns["Birthday"].DisplayIndex = 5;
            dataGridView1.Columns["Phone"].DisplayIndex = 6;
            dataGridView1.Columns["Experience"].DisplayIndex = 7;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form? mainForm = Application.OpenForms.Cast<Form>().ToList().Find(f => f.Name == "MainForm");
            if (mainForm != null)
                mainForm.Activate();
            this.Close();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (String.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[3].Value as String))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.ControlDark;
            }
        }

        private void TrainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext?.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrainerCreateDialogForm addDialogForm = new TrainerCreateDialogForm(dbContext);
            addDialogForm.ShowDialog();
            UpdateTable();
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
                    Trainer? trainer = dbContext.Trainers.FirstOrDefault(t => t.Id == id);

                    if (trainer is not null)
                    {
                        dbContext.Trainers.Remove(trainer);
                        dbContext.SaveChanges();
                    }
                    UpdateTable();
                }
            }
            if (senderGrid.Columns[e.ColumnIndex].Name == "Update" && e.RowIndex >= 0)
            {
                Guid id = Guid.Parse(senderGrid.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                Trainer? trainer = dbContext.Trainers.FirstOrDefault(t => t.Id == id);
                TrainerCreateDialogForm addDialogForm = new TrainerCreateDialogForm(dbContext, trainer);
                addDialogForm.ShowDialog();
                UpdateTable();
            }
        }
    }
}
