using EntityClasses;

namespace TennisAdministrator
{
    public partial class CourtCreateDialogForm : Form
    {
        string errorText = "Введены некорректные данные";
        string? name;
        float price = 0;
        string? description;
        ApplicationDbContext _dbContext;
        Court _court;

        public CourtCreateDialogForm(ApplicationDbContext dbContext, Court court = null)
        {
            InitializeComponent();
            _dbContext = dbContext;
            if (court is not null)
            {
                _court = court;
                label1.Text = "Изменить данные о корте";
                textBox1.Text = court.Name;
                textBox2.Text = court.Price.ToString();
                textBox3.Text = court.Description;
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

            if (!float.TryParse(textBox2.Text, out price) || price <= 0)
            {
                errorLabel2.Text = errorText;
                errorLabel2.Visible = true;
                price = 0;
                success = false;
            }
            else
            {
                errorLabel2.Visible = false;
            }

            if (textBox3.Text.Length == 0 || textBox3.Text.Length > 100)
            {
                errorLabel3.Text = errorText;
                errorLabel3.Visible = true;
                success = false;
            }
            else
            {
                errorLabel3.Visible = false;
                description = textBox3.Text;
            }

            return success;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (_court is not null)
                    _court.Update(name, description, price);
                else
                {
                    _court = Court.Create(name, description, price);
                    _dbContext.Courts.Add(_court);
                }
                _dbContext.SaveChanges();
                this.Close();
            }
        }
    }
}
