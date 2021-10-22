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

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var model = _db.Treats
        .Include(treat => treat.JoinEntities)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(treat => treat.TreatId == id);
      return View(model);
    }

    public ActionResult AddFlavor(int id)
    {
      var model = _db.Treats
        .Include(treat => treat.JoinEntities)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
      return View(model);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int FlavorId)
    {
      if(FlavorId != 0 && !_db.TreatFlavors.Any(model => model.TreatId == treat.TreatId && model.FlavorId == FlavorId))
      {
        _db.TreatFlavors.Add(new TreatFlavors() {FlavorId = FlavorId, TreatId = treat.TreatId});
        _db.SaveChanges();
      }
      return RedirectToAction("AddFlavor");
    }

    [HttpPost]
    public ActionResult DeleteFlavor(int joinId, int id) 
    {
      var joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorsId == joinId);
      _db.TreatFlavors.Remove(joinEntry);
      _db.SaveChanges();
      var model = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View("Details", model);
    }

    public ActionResult Edit(int id)
    {
      var model = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}