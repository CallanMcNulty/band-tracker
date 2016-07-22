using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venue : CRUDObject<Venue>
  {
    private string _location;
    private string _name;
    public static string table
    {
      get
      {
        return "venues";
      }
    }
    public string location
    {
      get
      {
        return _location;
      }
      set
      {
        _location = value;
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
    public Venue(string Location, string Name, int Id=0)
    {
      id = Id;
      _location = Location;
      _name = Name;
    }
    public List<Band> GetBands()
    {
      DBObjects dbo = DBObjects.CreateCommand("SELECT bands.* FROM venues JOIN performances ON (venues.id=performances.venue_id) JOIN bands ON (performances.band_id=bands.id) WHERE venues.id=@Id;", new List<string> {"@Id"}, new List<object> {id});
      SqlDataReader rdr = dbo.RDR;
      rdr = dbo.CMD.ExecuteReader();

      List<Band> bands = new List<Band> {};
      while(rdr.Read())
      {
        bands.Add(new Band(rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(0)));
      }
      dbo.Close();
      return bands;
    }
  }
}
