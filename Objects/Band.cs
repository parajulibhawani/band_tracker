using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker
{
  public class Band
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
    public string GetBandName()
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
    public static List<Band> GetAll()
    {
      List<Band> allBands = new List<Band>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM bands;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        string bandName = rdr.GetString(1);
        Band newBand = new Band(bandName, bandId);
        allBands.Add(newBand);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allBands;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO bands (band_name) OUTPUT INSERTED.id VALUES (@BandName);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@BandName";
      nameParameter.Value = this.GetBandName();
      cmd.Parameters.Add(nameParameter);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }
    public static Band Find(int id)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM bands WHERE id = @BandId;", conn);
      SqlParameter bandIdParameter = new SqlParameter();
      bandIdParameter.ParameterName = "@BandId";
      bandIdParameter.Value = id.ToString();
      cmd.Parameters.Add(bandIdParameter);
      rdr = cmd.ExecuteReader();

      int foundBandId = 0;
      string foundBandName = null;

      while(rdr.Read())
      {
        foundBandId = rdr.GetInt32(0);
        foundBandName = rdr.GetString(1);
      }
      Band foundBand = new Band(foundBandName, foundBandId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundBand;
    }
    public void AddVenue(Venue newVenue)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO bands_venues (venue_id, band_id) VALUES (@VenueId, @BandId);", conn);

      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = newVenue.GetId();
      cmd.Parameters.Add(venueIdParameter);

      SqlParameter BandIdParameter = new SqlParameter();
      BandIdParameter.ParameterName = "@BandId";
      BandIdParameter.Value = this.GetId();
      cmd.Parameters.Add(BandIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
    public List<Venue> GetVenues()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT venues.* FROM bands JOIN bands_venues ON (bands.id = bands_venues.band_id) JOIN venues ON (bands_venues.venue_id= venues.id) WHERE bands.id = @BandId", conn);

      SqlParameter bandIdParameter = new SqlParameter();
      bandIdParameter.ParameterName = "@BandId";
      bandIdParameter.Value = this.GetId().ToString();
      cmd.Parameters.Add(bandIdParameter);

      rdr = cmd.ExecuteReader();

      List<Venue> venue = new List<Venue> {};


      while (rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueTitle = rdr.GetString(1);
        Venue newVenue = new Venue(venueTitle, venueId);
        venue.Add(newVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return venue;
    }

    public static void DeleteAll()
   {
     SqlConnection conn = DB.Connection();
     conn.Open();
     SqlCommand cmd = new SqlCommand("DELETE FROM bands;", conn);
     cmd.ExecuteNonQuery();
   }
  }
}
