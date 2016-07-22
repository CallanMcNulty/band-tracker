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
      _genre = Genre;
      _name = Name;
    }
  }
}
