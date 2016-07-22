using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      // Band.DeleteAll();
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Band.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
   public void Test_SaveBandToDatabase()
   {
     Band testBand = new Band("Mark Twain");

     testBand.Save();
     List<Band> result = Band.GetAll();
     List<Band> testList = new List<Band>{testBand};

     Assert.Equal(testList, result);
   }
  }
}
