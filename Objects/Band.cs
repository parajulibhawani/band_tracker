using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker
{
  public class BandTracker
  {
    private int _id;
    private string _bandName;
    public Band(string bandName, int id = 0)
    {
      _id = id;
      _bandName = bandName;
    }
    public int GetId()
   {
     return _id;
   }
    public int GetBandName()
   {
     return _bandName;
   }
   public void SetBandName(string newBandName)
   {
     _bandName = newBandName;
   }
   public override bool Equals(System.Object otherBand)
    {
      if (!(otherBand is Band))
      {
        return false;
      }
      else
      {
        Band newBand = (Band) otherBand;
        bool idEquality = this.GetId() == newBand.GetId();
        bool nameEquality = this.GetBandName() == newBand.GetBandName();
        return (idEquality && nameEquality);
      }
    }
  }
}
