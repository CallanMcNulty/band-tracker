using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Band : CRUDObject<Band>
  {
    private string _genre;
    private string _name;
    public static string table
    {
      get
      {
        return "bands";
      }
    }
    public string genre
    {
      get
      {
        return _genre;
      }
      set
      {
        _genre = value;
      }
    }
    public string name
    {
      get
      {
        return _name;
      }
      set
      {
        _name = value;
      }
    }
    public Band( string Genre, string Name, int Id=0)
    {
      id = Id;
      _genre = Genre;
      _name = Name;
    }
    public void AddPerformance(int venueId)
    {
      DBObjects dbo = DBObjects.CreateCommand("INSERT INTO performances (band_id, venue_id) VALUES (@Id, @VenueId);", new List<string> {"@Id", "@VenueId"}, new List<object> {id, venueId});
      dbo.CMD.ExecuteNonQuery();
      dbo.Close();
    }
    public List<Venue> GetVenues()
    {
      DBObjects dbo = DBObjects.CreateCommand("SELECT venues.* FROM venues JOIN performances ON (venues.id=performances.venue_id) JOIN bands ON (performances.band_id=bands.id) WHERE bands.id=@Id;", new List<string> {"@Id"}, new List<object> {id});
      SqlDataReader rdr = dbo.RDR;
      rdr = dbo.CMD.ExecuteReader();

      List<Venue> venues = new List<Venue> {};
      while(rdr.Read())
      {
        venues.Add(new Venue(rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(0)));
      }
      dbo.Close();
      return venues;
    }
  }
}
