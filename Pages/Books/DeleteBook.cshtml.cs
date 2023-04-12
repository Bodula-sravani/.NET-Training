using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ASP.Net_application.Pages.Books
{
    public class DeleteBookModel : PageModel
    {

        public Books book = new Books();
        public string message = "";

        public void OnGet()
        {
            try
            {
                string bookId = Request.Query["Id"];

                string connectionString = "Data Source=DESKTOP-8C83AOT;Initial Catalog=LMS_DB;Integrated Security=True;Encrypt=False;";
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string query = $"select * from LMS_BOOK_DETAILS where BOOK_CODE='{bookId}'";

                Console.WriteLine("get method in delete");
                SqlCommand command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {

                    book.BookTitle = (string)reader["book_title"];
                    book.Author = (string)reader["Author"];
                    book.Price = (double)reader["price"];
                    book.Publication = (string)reader["PUBLICATION"];
                    book.publishDate = (DateTime)reader["publish_date"];
                    book.bookEdition = (int)reader["book_edition"];
                    book.Price = (double)reader["Price"];
                    book.category = (string)reader["category"];
                }
                reader.Close();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
                message = e.Message;
            }
        }


        public void OnPost()
        {
            try
            {
                string bookId = Request.Query["Id"];
                Console.WriteLine(bookId);
                string connectionString = "Data Source=DESKTOP-8C83AOT;Initial Catalog=LMS_DB;Integrated Security=True;Encrypt=False;";
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"delete from LMS_BOOK_DETAILS where BOOK_CODE='{bookId}'";
                //SqlCommand command = new SqlCommand(query, connection);
               
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected);
                if (rowsAffected > 0)
                {
                    Response.Redirect("/Books/IndexBooks");
                }
                
            }
            catch(SqlException e)
            {
                message = e.Message;
            }
        }
    }
}
