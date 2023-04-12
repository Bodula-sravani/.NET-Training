using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace ASP.Net_application.Pages.Books
{
    public class UpdateBookModel : PageModel
    {
       public Books book = new Books();
       public string message = "";
       
        public void OnGet()
        {
            string bookId = Request.Query["Id"];
            
            string connectionString = "Data Source=DESKTOP-8C83AOT;Initial Catalog=LMS_DB;Integrated Security=True;Encrypt=False;";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string query = $"select * from LMS_BOOK_DETAILS where BOOK_CODE='{bookId}'";

            Console.WriteLine("query is executes");
            SqlCommand command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            while(reader.Read())
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
        }


        public void OnPost()
        {
            string connectionString = "Data Source=DESKTOP-8C83AOT;Initial Catalog=LMS_DB;Integrated Security=True;Encrypt=False;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string bookId = Request.Query["Id"];
            book.BookTitle = Request.Form["Title"];
            book.category = Request.Form["Category"];
            book.Author = Request.Form["Author"];
            book.Publication = Request.Form["Publication"];
            book.publishDate = Convert.ToDateTime(Request.Form["Publish Date"]);
            book.bookEdition = Convert.ToInt32(Request.Form["Book Edition"]);
            book.Price = Convert.ToDouble(Request.Form["Price"]);
            book.rackNum = "A2";
            book.dateArrival = DateTime.Now;
            book.supplierId = "S01";

            try
            {
                string query = $"update LMS_BOOK_DETAILS set book_title='{book.BookTitle}',author='{book.Author}'," +
                    $"category ='{book.category}',publication='{book.Publication}'," +
                    $"publish_date='{book.publishDate}',book_edition={book.bookEdition},price={book.Price}" +
                    $"where book_code='{bookId}'";
              
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                message = "Book updated successfully";

            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
               message = ex.Message;
            }


        }
    }
}
