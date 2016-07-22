using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTrackerTests : IDisposable
  {
    public BandTrackerTests()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DeleteAll_GetAll()
    {
      Assert.Equal(0, Venue.GetAll().Count);
    }
    [Fact]
    public void Test_Save_Find_Update()
    {
      Venue testVenue = new Venue("123 Fakestreet", "Fakename Center");
      testVenue.Save();
      testVenue.Update(new List<string> {"name"}, new List<object> {"The Fakename Center"});
      Assert.Equal("The Fakename Center", Venue.Find(testVenue.id).name);
    }
    [Fact]
    public void Test_Save_Find_Delete()
    {
      Band testBand = new Band("Pazz", "Jeff and the Baboons");
      testBand.Save();
      testBand.Delete(new string[] {"performances"}, new string[] {"band_id"});
      Assert.Equal(null, Band.Find(testBand.id));
    }
    [Fact]
    public void Test_GetBands()
    {
      this.Dispose();
      Venue testVenue = new Venue("123 Fakestreet", "Fakename Center");
      testVenue.Save();
      Band testBand = new Band("Pazz", "Jeff and the Baboons");
      testBand.Save();
      testBand.AddPerformance(testVenue.id);
      Assert.Equal(testBand.id, testVenue.GetBands()[0].id);
    }
    public void Dispose()
    {
      Band.DeleteAll(new string[] {"performances"});
      Venue.DeleteAll(new string[] {"performances"});
    }
  }
}
