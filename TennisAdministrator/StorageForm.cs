using System.Data;

namespace TennisAdministrator
{
    public partial class StorageForm : Form
    {
        public StorageForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form? mainForm = Application.OpenForms.Cast<Form>().ToList().Find(f => f.Name == "MainForm");
            if (mainForm != null)
                mainForm.Activate();
            this.Close();
        }
    }
}
