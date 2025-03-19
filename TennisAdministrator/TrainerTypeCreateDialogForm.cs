using EntityClasses;
using EntityClasses.Person;

namespace TennisAdministrator
{
    public partial class TrainerTypeCreateDialogForm : Form
    {
        string errorText = "Введены некорректные данные";
        string? name;
        ApplicationDbContext _dbContext;
        TrainerType _trainerType;

        public TrainerTypeCreateDialogForm(ApplicationDbContext dbContext, TrainerType trainerType = null)
        {
            InitializeComponent();
            _dbContext = dbContext;
            if (trainerType is not null)
            {
                _trainerType = trainerType;
                label1.Text = "Изменить данные о типе тренеров";
                textBox1.Text = trainerType.Name;
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
                if (_trainerType is not null)
                    _trainerType.Update(name);
                else
                {
                    _trainerType = TrainerType.Create(name);
                    _dbContext.TrainerTypes.Add(_trainerType);
                }
                _dbContext.SaveChanges();
                this.Close();
            }
        }
    }
}
