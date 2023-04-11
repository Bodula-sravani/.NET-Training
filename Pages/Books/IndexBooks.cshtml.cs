using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ASP.Net_application.Pages.Books
{
    public class IndexBooksModel : PageModel
    {
       public List<Books> booksList = new List<Books>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-8C83AOT;Initial Catalog=LMS_DB;Integrated Security=True;Encrypt=False;";

                
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string query = "select BOOK_CODE,BOOK_TITLE,AUTHOR,PRICE,PUBLICATION from LMS_BOOK_DETAILS";
                SqlCommand command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();

                while(reader.Read())
                { 

                    Books book = new Books();

                    book.Id = reader.GetString(0);
                    book.BookTitle = reader.GetString(1);
                    book.Author = reader.GetString(2);
                    book.Price = reader.GetDouble(3);
                    book.Publication=(string)reader["PUBLICATION"];

                    booksList.Add(book);
                }

            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
    }

    public class Books
    {
        public string Id { get; set; }
        public string BookTitle { get; set; }   
        public string Author { get; set; }
        public double Price { get; set; }
        public string Publication { get; set; } 
    }
}
