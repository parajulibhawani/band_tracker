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
      Band.DeleteAll();
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
     Band testBand = new Band("The Band");

     testBand.Save();
     List<Band> result = Band.GetAll();
     List<Band> testList = new List<Band>{testBand};

     Assert.Equal(testList, result);
   }
   [Fact]
   public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
   {
     Band firstBand = new Band("The Band");
     Band secondBand = new Band("The Band");
     Assert.Equal(firstBand, secondBand);
   }
   [Fact]
   public void Test_FindFindsBandInDatabase()
   {
     Band testBand = new Band("The Band");
     testBand.Save();
     Band foundBand = Band.Find(testBand.GetId());
     Assert.Equal(testBand, foundBand);
   }
  }
}
