namespace BandTracker
{
  public class Venue : CRUDObject<Venue>
  {
    private string _location;
    private string _name;
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
    public Venue(string Location, string Name)
    {
      _location = Location;
      _name = Name;
    }
  }
}
