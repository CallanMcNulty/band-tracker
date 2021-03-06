
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
      Get["/bands/{id}"] = parameters => {
        return View["band.cshtml", new List<object> {Band.Find(parameters.id), Venue.GetAll()}];
      };
      Get["/venues/{id}"] = parameters => {
        return View["venue.cshtml", new List<object> {Venue.Find(parameters.id), Band.GetAll()}];
      };
      Post["/bands/{id}"] = parameters => {
        Venue selectedVenue = Venue.Find((int)Request.Form["venue"]);
        Band selectedBand = Band.Find(parameters.id);
        selectedBand.AddPerformance(selectedVenue.id);
        return View["band.cshtml", new List<object> {Band.Find(parameters.id), Venue.GetAll()}];
      };
      Patch["/bands/{id}"] = parameters => {
        Band selectedBand = Band.Find(parameters.id);
        selectedBand.Update(new List<string> {"name", "genre"}, new List<object> {(string)Request.Form["name"], (string)Request.Form["genre"]});
        return View["band.cshtml", new List<object> {Band.Find(parameters.id), Venue.GetAll()}];
      };
      Delete["/bands/{id}"] = parameters => {
        Band selectedBand = Band.Find(parameters.id);
        selectedBand.Delete(new string[] {"performances"}, new string[] {"band_id"});
        return View["bands.cshtml", Band.GetAll()];
      };
      Post["/venues/{id}"] = parameters => {
        Band selectedBand = Band.Find((int)Request.Form["band"]);
        selectedBand.AddPerformance(parameters.id);
        return View["venue.cshtml", new List<object> {Venue.Find(parameters.id), Band.GetAll()}];
      };
      Patch["/venues/{id}"] = parameters => {
        Venue selectedVenue = Venue.Find(parameters.id);
        selectedVenue.Update(new List<string> {"name", "location"}, new List<object> {(string)Request.Form["name"], (string)Request.Form["location"]});
        return View["venue.cshtml", new List<object> {Venue.Find(parameters.id), Band.GetAll()}];
      };
      Delete["/venues/{id}"] = parameters => {
        Venue selectedVenue = Venue.Find(parameters.id);
        selectedVenue.Delete(new string[] {"performances"}, new string[] {"venue_id"});
        return View["venues.cshtml", Venue.GetAll()];
      };
    }
  }
}
