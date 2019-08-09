namespace PeopleDatabase.Controllers
{
    using PeopleDatabase.People;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class MyTestDbController
    {
        private static string myConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public DataTable Get()
        {
            // Connection 
            SqlConnection connection = new SqlConnection(myConnectionString);

            // Create table which will be filled with the returned stuff from Db
            DataTable dataTable = new DataTable();

            try
            {
                // Sql query
                string sql = "SELECT * FROM table_MyTestDb";

                // command -> using sql and connection 
                SqlCommand command = new SqlCommand(sql, connection);

                // adapter -> using command
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

        public bool Add(Person person)
        {
            // Connection 
            SqlConnection connection = new SqlConnection(myConnectionString);

            bool isSuccess = false;

            try
            {
                // Sql query
                string sql = "INSERT INTO table_MyTestDb (FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age)";

                // command -> using sql and connection 
                SqlCommand command = new SqlCommand(sql, connection);

                // add data
                command.Parameters.AddWithValue("@FirstName", person.FirstName);
                command.Parameters.AddWithValue("@LastName", person.LastName);
                command.Parameters.AddWithValue("@Age", person.Age);

                connection.Open();
                int rows = command.ExecuteNonQuery(); // if query run successfully rows will be GREATER than 0 and opposite if failed LOWER or EQUAL to 0;

                if (rows > 0) isSuccess = true;
                else isSuccess = false;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return isSuccess;
        }

        public bool Update(Person person)
        {
            // Connection 
            SqlConnection connection = new SqlConnection(myConnectionString);

            bool isSuccess = false;

            try
            {
                // SQL query
                string sql = "UPDATE table_MyTestDb SET FirstName=@FirstName, LastName=@LastName, Age=@Age WHERE PersonId=@PersonId";

                // command -> using sql and connection 
                SqlCommand command = new SqlCommand(sql, connection);

                // update data
                command.Parameters.AddWithValue("@FirstName", person.FirstName);
                command.Parameters.AddWithValue("@LastName", person.LastName);
                command.Parameters.AddWithValue("@Age", person.Age);
                command.Parameters.AddWithValue("@PersonId", person.Id);

                connection.Open();
                int rows = command.ExecuteNonQuery(); // if query run successfully rows will be GREATER than 0 and opposite if failed LOWER or EQUAL to 0;

                if (rows > 0) isSuccess = true;
                else isSuccess = false;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return isSuccess;
        }

        public bool Delete(Person person)
        {
            // Connection 
            SqlConnection connection = new SqlConnection(myConnectionString);

            bool isSuccess = false;

            try
            {
                // SQL query
                string sql = "DELETE FROM table_MyTestDb WHERE PersonId=@Id";

                // command -> using sql and connection 
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", person.Id);

                connection.Open();
                int rows = command.ExecuteNonQuery(); // if query run successfully rows will be GREATER than 0 and opposite if failed LOWER or EQUAL to 0;

                if (rows > 0) isSuccess = true;
                else isSuccess = false;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return isSuccess;
        }
    }
}
