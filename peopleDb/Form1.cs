namespace PeopleDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
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
            var dataTable = controller.Get();
            var people = GetPeopleFromDt(dataTable);

            var personToEdit = people.FirstOrDefault(x => x.FirstName == firstNameField.Text);
            personToEdit.FirstName = firstNameField.Text;
            personToEdit.LastName = lastNameField.Text;
            personToEdit.Age = int.Parse(ageField.Text);

            bool success = controller.Update(personToEdit);
            if (success)
            {
                MessageBox.Show("Person has been updated successfully.");
                //refresh datagrid
                dataTable = controller.Get();
                dataGrid.DataSource = dataTable;
                ClearFields(); 
            }
            else
            {
                MessageBox.Show("Failed to update person.Try again...");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var dataTable = controller.Get();
            var people = GetPeopleFromDt(dataTable);

            var personToDelete = people.FirstOrDefault(x => x.FirstName == firstNameField.Text);
            bool success = controller.Delete(personToDelete);
            if (success)
            {
                MessageBox.Show("Successfully deleted!");
                dataTable = controller.Get();
                dataGrid.DataSource = dataTable;
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to delete person. Try again...");
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
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
            int rowIndex = e.RowIndex;

            firstNameField.Text = dataGrid.Rows[rowIndex].Cells[1].Value.ToString();
            lastNameField.Text = dataGrid.Rows[rowIndex].Cells[2].Value.ToString();
            ageField.Text = dataGrid.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private List<Person> GetPeopleFromDt(DataTable dt)
        {

            var convertedList = (from rw in dt.AsEnumerable()
                                 select new Person()
                                 {
                                     Id = Convert.ToInt32(rw["PersonId"]),
                                     FirstName = Convert.ToString(rw["firstName"]),
                                     LastName = Convert.ToString(rw["lastName"]),
                                     Age = Convert.ToInt32(rw["age"])
                                 }).ToList();

            return convertedList;
        }
    }
}
