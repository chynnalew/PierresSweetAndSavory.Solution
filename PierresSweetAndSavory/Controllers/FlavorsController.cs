using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PierresSweetAndSavory.Models;
using System.Collections.Generic;
using System.Linq;

namespace PierresSweetAndSavory.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly PierresSweetAndSavoryContext _db;

    public FlavorsController(PierresSweetAndSavoryContext db)
    {
      _db = db;
    }
    public ActionResult Index() 
    { 
      List<Flavor> model = _db.Flavors.ToList();
      return View(model); 
    }
  }
}