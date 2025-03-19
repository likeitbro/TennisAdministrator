using EntityClasses;
using EntityClasses.Person;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Linq;

namespace TennisAdministrator
{
    public partial class TrainerCreateDialogForm : Form
    {
        string errorText = "Введены некорректные данные";
        string? firstName;
        string? lastName;
        string? description;
        DateOnly birthday = DateOnly.MinValue;
        string? phone;
        DateOnly experience = DateOnly.MinValue;
        float price = 0;
        List<TrainerType> trainerTypes;
        List<Specialization> specializations;
        ApplicationDbContext _dbContext;
        Trainer _trainer;

        public TrainerCreateDialogForm(ApplicationDbContext dbContext, Trainer trainer = null)
        {
            InitializeComponent();
            _dbContext = dbContext;
            trainerTypes = dbContext.TrainerTypes.ToList();
            foreach (var trainerType in trainerTypes)
                comboBox1.Items.Add(trainerType.Name);
            comboBox1.SelectedIndex = 1;
            List<Sport> sports = dbContext.Sports.ToList();
            foreach (var sport in sports)
                checkedListBox1.Items.Add(sport.Name);
            if (trainer is not null)
            {
                _trainer = trainer;
                specializations = _dbContext.Specializations.Where(s => s.TrainerId == _trainer.Id).ToList();
                label1.Text = "Изменить данные о тренере";
                textBox1.Text = trainer.FirstName;
                textBox2.Text = trainer.LastName;
                textBox3.Text = trainer.Description;
                textBox4.Text = trainer.Birthday.ToString();
                textBox5.Text = trainer.Phone;
                textBox6.Text = trainer.Experience.ToString();
                textBox7.Text = trainer.Price.ToString();
                comboBox1.SelectedItem = trainer.TrainerType.Name;
                if (specializations is not null)
                    foreach (var specialization in specializations)
                        checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(specialization.Sport.Name), true);
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
                firstName = textBox1.Text;
            }

            if (textBox2.Text.Length == 0 || textBox1.Text.Length > 50)
            {
                errorLabel2.Text = errorText;
                errorLabel2.Visible = true;
                success = false;
            }
            else
            {
                errorLabel2.Visible = false;
                lastName = textBox2.Text;
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

            if (!DateOnly.TryParse(textBox4.Text, out birthday) || birthday == DateOnly.MinValue)
            {
                errorLabel4.Text = errorText;
                errorLabel4.Visible = true;
                birthday = DateOnly.MinValue;
                success = false;
            }
            else
            {
                errorLabel4.Visible = false;
            }

            if (textBox5.Text.Length == 0 || 
                textBox5.Text.Length > 15 || 
                !System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, @"^[0-9]*$"))
            {
                errorLabel5.Text = errorText;
                errorLabel5.Visible = true;
                success = false;
            }
            else
            {
                errorLabel5.Visible = false;
                phone = textBox5.Text;
            }

            if (!DateOnly.TryParse(textBox6.Text, out experience) || experience == DateOnly.MinValue)
            {
                errorLabel6.Text = errorText;
                errorLabel6.Visible = true;
                experience = DateOnly.MinValue;
                success = false;
            }
            else
            {
                errorLabel6.Visible = false;
            }

            if (!float.TryParse(textBox7.Text, out price) || price <= 0)
            {
                errorLabel7.Text = errorText;
                errorLabel7.Visible = true;
                price = 0;
                success = false;
            }
            else
            {
                errorLabel7.Visible = false;
            }

            if (checkedListBox1.CheckedItems.Count == 0)
            {
                errorLabel8.Text = "Выберите хотя бы один спорт";
                errorLabel8.Visible = true;
                success = false;
            }
            else
            {
                errorLabel8.Visible = false;
            }

            return success;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (_trainer is not null)
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        string item = checkedListBox1.Items[i].ToString();
                        if (checkedListBox1.GetItemChecked(i))
                        {
                            if (specializations.Where(s => s.Sport.Name == item).IsNullOrEmpty())
                                _dbContext.Specializations.Add(Specialization.Create(
                                    _trainer.Id,
                                    _dbContext.Sports.Where(s => s.Name == item).First().Id));
                        }
                        else
                        {
                            if (specializations.Where(s => s.Sport.Name == item).Any())
                                _dbContext.Specializations.Remove(
                                    _dbContext.Specializations.Where(
                                        s => s.Sport.Name == item && s.TrainerId == _trainer.Id).First());
                        }
                    }
                    _trainer.Update(
                        _dbContext.TrainerTypes.Where(tt => tt.Name == comboBox1.SelectedItem.ToString()).First().Id,
                        firstName,
                        lastName,
                        birthday,
                        phone,
                        experience,
                        description,
                        price);

                }
                else
                {
                    _trainer = Trainer.Create(
                        _dbContext.TrainerTypes.Where(tt => tt.Name == comboBox1.SelectedItem.ToString()).First().Id,
                        firstName,
                        lastName,
                        birthday,
                        phone,
                        experience,
                        description,
                        price);
                    _dbContext.Trainers.Add(_trainer);
                    foreach (var item in checkedListBox1.CheckedItems.Cast<String>())
                    {
                        _dbContext.Specializations.Add(Specialization.Create(
                                    _trainer.Id,
                                    _dbContext.Sports.Where(s => s.Name == item).First().Id));
                    }
                }
                _dbContext.SaveChanges();
                this.Close();
            }
        }
    }
}
