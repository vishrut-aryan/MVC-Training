using _30July.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _30July.Controllers
{
    public class LocationController : Controller
    {
        private readonly EFexpEntities _context;

        public LocationController(EFexpEntities context)
        {
            _context = context;
        }

        public ActionResult Index() 
        {
            return View();
        }

        public JsonResult GetCountries(int continentId)
        {
            var countries = _context.Countries.Where(c => c.ContinentID == continentId)
                                              .Select(c => new { c.CountryID, c.CountryName })
                                              .ToList();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStates(int countryId)
        {
            var states = _context.States.Where(s => s.CountryID == countryId)
                                        .Select(s => new { s.StateID, s.StateName })
                                        .ToList();
            return Json(states, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCities(int stateId)
        {
            var cities = _context.Cities.Where(c => c.StateID == stateId)
                                        .Select(c => new { c.CityID, c.CityName })
                                        .ToList();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNeighborhoods(int cityId)
        {
            var neighborhoods = _context.Neighborhoods.Where(n => n.CityID == cityId)
                                                      .Select(n => new { n.NeighborhoodID, n.NeighborhoodName })
                                                      .ToList();
            return Json(neighborhoods, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRegions(int cityId)
        {
            var regions = _context.Regions.Where(r => r.CityID == cityId)
                                          .Select(r => new { r.RegionID, r.RegionName })
                                          .ToList();
            return Json(regions, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSpecialAreas(int regionId)
        {
            var specialAreas = _context.SpecialAreas.Where(sa => sa.RegionID == regionId)
                                                    .Select(sa => new { sa.SpecialAreaID, sa.SpecialAreaName })
                                                    .ToList();
            return Json(specialAreas, JsonRequestBehavior.AllowGet);
        }
    }

}