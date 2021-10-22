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
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var model = _db.Flavors
        .Include(treat => treat.JoinEntities)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(model);
    }

    public ActionResult AddTreat(int id)
    {
      var model = _db.Flavors
        .Include(flavor => flavor.JoinEntities)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
      return View(model);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int TreatId)
    {
      if(TreatId != 0 && !_db.TreatFlavors.Any(model => model.FlavorId == flavor.FlavorId && model.TreatId == TreatId))
      {
        _db.TreatFlavors.Add(new TreatFlavors() {TreatId = TreatId, FlavorId = flavor.FlavorId});
        _db.SaveChanges();
      }
      return RedirectToAction("AddTreat");
    }

    [HttpPost]
    public ActionResult DeleteTreat(int joinId, int id) 
    {
      var joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorsId == joinId);
      _db.TreatFlavors.Remove(joinEntry);
      _db.SaveChanges();
      var model = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View("Details", model);
    }
  }
}