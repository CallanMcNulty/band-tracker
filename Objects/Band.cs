namespace BandTracker
{
  public class Band : CRUDObject<Band>
  {
    private string _genre;
    private string _name;
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
    public Venue( string Genre, string Name)
    {
      _genre = Genre;
      _name = Name;
    }
  }
}
