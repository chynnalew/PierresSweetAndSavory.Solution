using System.Collections.Generic;

namespace PierresSweetAndSavory.Models
{
  public class Treat
  {
    public Treat()
    {
      this.JoinEntities = new HashSet<TreatFlavors>();
    }

    public int TreatId {get; set;}
    public string TreatName {get; set;}
    public string Description {get; set;}

    public virtual ICollection<TreatFlavors> JoinEntities {get;}
  }
}