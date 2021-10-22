using System.Collections.Generic;

namespace PierresSweetAndSavory.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.JoinEntities = new HashSet<TreatFlavors>();
    }

    public int FlavorId {get; set;}
    public string FlavorName {get; set;}

    public virtual ICollection<TreatFlavors> JoinEntities {get;}
  }
}