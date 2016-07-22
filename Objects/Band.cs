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
  }
}
