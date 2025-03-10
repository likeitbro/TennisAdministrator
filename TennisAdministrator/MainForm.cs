namespace TennisAdministrator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CourtForm courtForm = new CourtForm();
            courtForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReservationForm reaservationForm = new ReservationForm();
            reaservationForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaleForm saleForm = new SaleForm();
            saleForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StorageForm storageForm = new StorageForm();
            storageForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TrainerForm trainerForm = new TrainerForm();
            trainerForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TournamentForm tournamentForm = new TournamentForm();
            tournamentForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SportForm sportForm = new SportForm();
            sportForm.Show();
        }
    }
}
