using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PierresSweetAndSavory.Models;
using System.Collections.Generic;
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
      List<Treat> model = _db.Treats.ToList();
      return View(model); 
    }
  }
}