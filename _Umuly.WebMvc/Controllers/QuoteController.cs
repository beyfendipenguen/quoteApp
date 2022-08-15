using _Umuly.WebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using _Umuly.WebMvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using _Umuly.WebMvc.Repository;

namespace _Umuly.WebMvc.Controllers
{
    public class QuoteController : Controller
    {
      
        public IActionResult IndexAsync()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
