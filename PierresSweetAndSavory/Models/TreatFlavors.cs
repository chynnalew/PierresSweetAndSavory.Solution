namespace PierresSweetAndSavory.Models
{
  public class TreatFlavors
  {
    public int TreatFlavorsId {get; set;}
    public int TreatId {get; set;}
    public int FlavorId {get; set;}
    public virtual Treat Treat {get; set;}
    public virtual Flavor Flavor {get; set;}
  }
}