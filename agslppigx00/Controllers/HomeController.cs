using agslppigx00.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace agslppigx00.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var tosqlmy = new TalktoSQL();
          //  tosqlmy.PushtoSQL();
            return View();
        }

        public async Task<ActionResult> About()
        {
            //Simulate test user data and login timestamp
            var userId = "deploynetliz";
            var currentLoginTime = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");

            //Save non identifying data to Firebase
            
            var currentUserLogin = new LoginData() { TimestampUtc = currentLoginTime };
            var firebaseClient = new FirebaseClient("https://deploynetapplication.appspot.com");
            var result = await firebaseClient
              .Child("Users/" + userId + "/Logins")
              .PostAsync(currentUserLogin);

            //Retrieve data from Firebase
            var dbLogins = await firebaseClient
              .Child("Users")
              .Child(userId)
              .Child("Logins")
              .OnceAsync<LoginData>();

            var timestampList = new List<DateTime>();

            //Convert JSON data to original datatype
            foreach (var login in dbLogins)
            {
                timestampList.Add(Convert.ToDateTime(login.Object.TimestampUtc).ToLocalTime());
            }

            //Pass data to the view
            ViewBag.CurrentUser = userId;
            ViewBag.Logins = timestampList.OrderByDescending(x => x);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}