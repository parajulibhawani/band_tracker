using System.Collections.Generic;
using System;
using Nancy;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
    Get ["/"]= _ =>{
      return View ["index.cshtml"];
    };
    Post["/venue/new"]= _ =>{
      Venue newVenue = new Venue(Request.Form["venue_name"]);
      newVenue.Save();
      return View ["venues.cshtml", Venue.GetAll()];
    };
    Get ["/band/new"]= _ =>{
      return View ["bands.cshtml", Band.GetAll()];
    };
    Get ["/bands/all"]= _ =>{
      return View ["bands.cshtml", Band.GetAll()];
    };
    Post["/bands/new"]= _ =>{
      Band newBand = new Band(Request.Form["band_name"]);
      newBand.Save();
      return View ["bands.cshtml", Band.GetAll()];
    };
    Get ["/venues/all"]= _ =>{
      return View ["venues.cshtml", Venue.GetAll()];
    };
    Get ["/venue/{id}"]= parameter =>{
      Venue selectedVenue = Venue.Find(parameter.id);
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Band> bandAtVenue = selectedVenue.GetBands();
      model.Add("venue", selectedVenue);
      model.Add("bandAtVenue", bandAtVenue);
      model.Add("allBands", Band.GetAll());
      return View ["venue.cshtml", model];
    };
    Post ["/band/{id}"]= parameter =>{
      Venue selectedVenue = Venue.Find(parameter.id);
      Band selectedBand = Band.Find(Request.Form["add_new_band"]);
      selectedVenue.AddBand(selectedBand);
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Band> bandAtVenue = selectedVenue.GetBands();
      model.Add("venue", selectedVenue);
      model.Add("bandAtVenue", bandAtVenue);
      model.Add("allBands", Band.GetAll());
      return View ["venue.cshtml", model];
    };
    }
  }
}
