using System.Windows.Forms;

namespace Safari
{
    public partial class WelcomeForm : Form
    {
        private List<int> lakes_capacity_list = new List<int>();
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
     
        }

        private void AddNewLakeButton_Click(object sender, EventArgs e)
        {
            if (AddNewLakeCapacityBox.Text == "")
                return;

            int new_lake_capacity = int.Parse(AddNewLakeCapacityBox.Text);
            if (new_lake_capacity < 1)
                return;
            lakes_capacity_list.Add(new_lake_capacity);

            LakesCapacityList.Items.Clear();
            foreach (int number in lakes_capacity_list)
            {
                LakesCapacityList.Items.Add(number);
            }

            AddNewLakeCapacityBox.Clear();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            MainForm main_form = new MainForm(this.lakes_capacity_list);
            main_form.ShowDialog();
            this.Close();
        }
    }
}
