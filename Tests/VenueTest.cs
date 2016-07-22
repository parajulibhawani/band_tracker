using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace VenueTracker
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Venue.GetAll().Count;

      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfVenueNamesAreTheSame()
    {
      Venue firstVenue = new Venue("Madison Square Garden");
      Venue secondVenue = new Venue("Madison Square Garden");
      Assert.Equal(firstVenue, secondVenue);
    }
    public void Dispose()
   {
    //  Venue.DeleteAll();
   }
  }
}
