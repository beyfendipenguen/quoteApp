using Microsoft.AspNetCore.Mvc;
using _Umuly.WebMvc.Models;

namespace _Umuly.WebMvc.Controllers
{
    public class CountryController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Country> countryList;

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Country").Result;
            countryList = response.Content.ReadAsAsync<IEnumerable<Country>>().Result;
            return View(countryList);
        }
        // Post: Employee
  
        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)

                return View(new Country());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Country/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Country>().Result);

            }

        }
        [HttpPost]
        public ActionResult AddorEdit(Country country)
        {
            if (country.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Country", country).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Country/" +country.Id, country).Result;
                TempData["SuccessMessage"] = "Saved Successfully";

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Country/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfuly";
            return RedirectToAction("Index");
        }
        
    }
}
