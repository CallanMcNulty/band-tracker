
using System.Collections.Generic;
using System;
using Nancy;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/bands"] = _ => {
        return View["bands.cshtml", Band.GetAll()];
      };
      Get["/venues"] = _ => {
        return View["venues.cshtml", Venue.GetAll()];
      };
      Post["/bands"] = _ => {
        Band newBand = new Band(Request.Form["genre"], Request.Form["name"]);
        newBand.Save();
        return View["bands.cshtml", Band.GetAll()];
      };
      Post["/venues"] = _ => {
        Venue newVenue = new Venue(Request.Form["location"], Request.Form["name"]);
        newVenue.Save();
        return View["venues.cshtml", Venue.GetAll()];
      };
    }
  }
}
