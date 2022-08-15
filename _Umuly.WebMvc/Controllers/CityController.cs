using _Umuly.WebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _Umuly.WebMvc.Controllers
{
    public class CityController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<CityDto> cityList;

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("City").Result;
            cityList = response.Content.ReadAsAsync<IEnumerable<CityDto>>().Result;
            return View(cityList);
        }
        

        public ActionResult AddorEdit(int id = 0, int countryId = 0)
        {
            IEnumerable<Country> countryList;
            HttpResponseMessage res = GlobalVariables.WebApiClient.GetAsync("Country").Result;
            countryList = res.Content.ReadAsAsync<IEnumerable<Country>>().Result;
            #region ViewBag
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (Country country in countryList)
            {
                items.Add(new SelectListItem(text: country.CountryName, value: country.Id.ToString()));
            }

            Console.WriteLine("id",id);
           // items.First(x => x.Value == id.ToString()).Selected = true;

            ViewBag.country = items;
            #endregion
            if (id == 0)

                return View(new City());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("City/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<City>().Result);

            }

        }
        [HttpPost]
        public ActionResult AddorEdit(City city)
        {
            if (city.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("City", city).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("City/" + city.Id, city).Result;
                TempData["SuccessMessage"] = "Saved Successfully";

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("City/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfuly";
            return RedirectToAction("Index");
        }

    }
}

