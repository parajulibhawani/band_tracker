using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
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
    [Fact]
    public void Test_SaveVenueToDatabase()
    {
      Venue testVenue = new Venue("Madison Square Garden");

      testVenue.Save();
      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{testVenue};

      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_FindFindsVenueInDatabase()
    {
      Venue testVenue = new Venue("Madison Square Garden");
      testVenue.Save();
      Venue foundVenue = Venue.Find(testVenue.GetId());
      Assert.Equal(testVenue, foundVenue);
    }
    [Fact]
    public void Test_Update_UpdatesVenueInDatabase()
    {
      Venue testVenue = new Venue("Madison Square Garden");
      testVenue.Save();
      string newName = ("Oracle Arena");
      testVenue.Update(newName);
      Assert.Equal(newName, testVenue.GetVenueName());
    }
    [Fact]
    public void Test_Delete_RemovesVenueFromDatabase()
    {
      List<Venue> TestVenues = new List<Venue>{};

      Venue testVenue1 = new Venue("Madison Square Garden");
      testVenue1.Save();
      Venue testVenue2 = new Venue("Oracle Arena");
      testVenue2.Save();

      Band TestBand1 = new Band("The Band");
      TestBand1.Save();
      Band TestBand2 = new Band("A Band");
      TestBand2.Save();
      TestBand1.AddVenue(testVenue1);
      TestBand2.AddVenue(testVenue2);
      testVenue1.Delete();

      List<Venue> resultVenues = Venue.GetAll();
      List<Venue> testVenues = new List<Venue> {testVenue2};

      List<Band> resultBands = Band.GetAll();
      List<Band> testBands = new List<Band> {TestBand1, TestBand2};

      Assert.Equal(resultVenues, testVenues);
      Assert.Equal(resultBands, testBands);
    }
    [Fact]
    public void Test_Delete_DeletesVenuesFromDatabase()
    {

      Venue testVenue = new Venue("Oracle Arena");
      testVenue.Save();
      testVenue.Delete();
      List<Venue> resultVenues = Venue.GetAll();
      List<Venue> testVenues = new List<Venue> {};
      Assert.Equal(resultVenues, testVenues);
    }
    public void Dispose()
   {
     Venue.DeleteAll();
     Band.DeleteAll();
   }
  }
}
