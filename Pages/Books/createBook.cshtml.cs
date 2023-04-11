using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ASP.Net_application.Pages.Books
{
    public class createBookModel : PageModel
    {
        Books book = new Books();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            string connectionString = "Data Source=DESKTOP-8C83AOT;Initial Catalog=LMS_DB;Integrated Security=True;Encrypt=False;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            book.Id = Request.Form["Id"];
            book.BookTitle = Request.Form["Title"]; 
            book.category= Request.Form["Category"];
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
                string query = $"insert into LMS_BOOK_DETAILS values" +
                                $"('{book.Id}','{book.BookTitle}','{book.category}','{book.Author}','{book.Publication}','{book.publishDate}'," +
                                $"{book.bookEdition},{book.Price},'{book.rackNum}','{book.dateArrival}','{book.supplierId}')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                successMessage = "Book added successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                errorMessage=ex.Message;
            }
            

        }
    }
}
