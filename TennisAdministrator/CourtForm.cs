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
            dataGridView1.DataSource = courts;
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
