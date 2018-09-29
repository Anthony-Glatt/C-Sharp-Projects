using NewsLetterMVC.Models;
using NewsLetterMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetterMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] //a marker for anytime you are performing a post method(good practice)
        public ActionResult SignUp(string firstName, string lastName, string emailAddress)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shard/Error.cshtml");
            }
            else
            {
                using (NewsletterEntities db = new NewsletterEntities())
                {
                    var signup = new SignUp();
                    signup.FirstName = firstName;
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;

                    db.SignUps.Add(signup);
                    db.SaveChanges();
                }
                return View("Success");
            }
        }


        //ADO.net method for Posting user input into the db. Instead using Entity Framework.

        //string queryString = @"INSERT INTO SignUps (FirstName, LastName, EmailAddress) VALUES
        //                     (@FirstName, @LastName, @EmailAddress)";

        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        //    SqlCommand command = new SqlCommand(queryString, connection);
        //    command.Parameters.Add("@FirstName", SqlDbType.VarChar);
        //    command.Parameters.Add("@LastName", SqlDbType.VarChar);
        //    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);

        //    command.Parameters["@FirstName"].Value = firstName;
        //    command.Parameters["@LastName"].Value = lastName;
        //    command.Parameters["@EmailAddress"].Value = emailAddress;

        //    connection.Open();
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //}



        //ADO.net method for linking sql server back to C#. An easier method is to use Entity Framework which is what is done above.

        //string queryString = @"SELECT Id, FirstName, LastName, EmailAddress, SocialSecurityNumber FROM SignUps";
        //List<NewsletterSignUp> signups = new List<NewsletterSignUp>();

        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        //    SqlCommand command = new SqlCommand(queryString, connection);

        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        var signup = new NewsletterSignUp();
        //        signup.Id = Convert.ToInt32(reader["Id"]);
        //        signup.FirstName = reader["FirstName"].ToString();
        //        signup.LastName = reader["LastName"].ToString();
        //        signup.EmailAddress = reader["EmailAddress"].ToString();
        //        signup.SocialSecurityNumber = reader["SocialSecurityNumber"].ToString();

        //        signups.Add(signup);
        //    }
        //}
    }
}