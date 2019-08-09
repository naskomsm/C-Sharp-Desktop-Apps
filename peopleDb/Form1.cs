namespace PeopleDatabase
{
    using System;
    using System.Data;
    using System.Windows.Forms;
    using PeopleDatabase.Controllers;
    using PeopleDatabase.People;

    public partial class userLogo : Form
    {
        private MyTestDbController controller;

        public userLogo()
        {
            InitializeComponent();
            this.controller = new MyTestDbController();
        }


        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void HeaderLabel_Click(object sender, EventArgs e)
        {

        }

        private void UserLogo_Load(object sender, EventArgs e)
        {
            DataTable dataTable = controller.Get();
            dataGrid.DataSource = dataTable;
        }

        // CRUD

        private void AddBtn_Click(object sender, EventArgs e)
        {
            // Get values and create the class
            Person person = new Person();
            person.FirstName = firstNameField.Text;
            person.LastName = lastNameField.Text;
            person.Age = int.Parse(ageField.Text);

            // add in Database with the method from the controller
            bool success = controller.Add(person);
            if (success)
            {
                MessageBox.Show("New person successfully added!");
            }
            else
            {
                MessageBox.Show("Failed to add person.Try again..");
            }

            ClearFields();

            //load people on peopleGRID
            DataTable dataTable = controller.Get();
            dataGrid.DataSource = dataTable;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            firstNameField.Text = string.Empty;
            lastNameField.Text = string.Empty;
            ageField.Text = string.Empty;
        }

        private void DataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
