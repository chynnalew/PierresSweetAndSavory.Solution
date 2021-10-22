using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PierresSweetAndSavory.Models;
using System.Collections.Generic;
using System.Linq;

namespace PierresSweetAndSavory.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierresSweetAndSavoryContext _db;

    public TreatsController(PierresSweetAndSavoryContext db)
    {
      _db = db;
    }
    public ActionResult Index() 
    { 
      List<Treat> model = _db.Treats.ToList();
      return View(model); 
    }
  }
}