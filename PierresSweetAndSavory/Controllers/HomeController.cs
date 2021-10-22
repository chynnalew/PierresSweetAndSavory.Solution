using Microsoft.AspNetCore.Mvc;
using PierresSweetAndSavory.Models;

namespace PierresSweetAndSavory.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index() 
    { 
      return View(); 
    }
  }
}