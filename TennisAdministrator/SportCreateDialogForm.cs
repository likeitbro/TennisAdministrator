using EntityClasses;

namespace TennisAdministrator
{
    public partial class SportCreateDialogForm : Form
    {
        string errorText = "Введены некорректные данные";
        string? name;
        ApplicationDbContext _dbContext;
        Sport _sport;

        public SportCreateDialogForm(ApplicationDbContext dbContext, Sport sport = null)
        {
            InitializeComponent();
            _dbContext = dbContext;
            if (sport is not null)
            {
                _sport = sport;
                label1.Text = "Изменить данные о типе тренеров";
                textBox1.Text = sport.Name;
            }
        }

        private bool ValidateInput()
        {
            bool success = true;
            if (textBox1.Text.Length == 0 || textBox1.Text.Length > 50)
            {
                errorLabel1.Text = errorText;
                errorLabel1.Visible = true;
                success = false;
            }
            else
            {
                errorLabel1.Visible = false;
                name = textBox1.Text;
            }

            return success;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (_sport is not null)
                    _sport.Update(name);
                else
                {
                    _sport = Sport.Create(name);
                    _dbContext.Sports.Add(_sport);
                }
                _dbContext.SaveChanges();
                this.Close();
            }
        }
    }
}
