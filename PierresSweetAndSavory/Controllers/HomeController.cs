using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PierresSweetAndSavory.Models;
using System.Dynamic;
using System.Linq;

namespace PierresSweetAndSavory.Controllers
{
  public class HomeController : Controller
  {
    private readonly PierresSweetAndSavoryContext _db;

    public HomeController(PierresSweetAndSavoryContext db)
    {
      _db = db;
    }
    [HttpGet("/")]
    public ActionResult Index() 
    { 
      dynamic model = new ExpandoObject();
      model.Treat = _db.Treats.ToList();
      model.Flavor = _db.Flavors.ToList();
      return View(model); 
    }
  }
}