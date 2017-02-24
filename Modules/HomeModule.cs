using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalonApp
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                return View["index.cshtml"];
            };

            Get["/clients"] = _ => {
                List<Client> AllClients = Client.GetAll();
                return View["clients.cshtml", AllClients];
            };

            Get["/stylists"] = _ => {
                List<Stylist> AllStylists = Stylist.GetAll();
                return View["stylists.cshtml", AllStylists];
            };

            Get["/stylists/new"] = _ => {
                return View["new_stylist_form.cshtml"];
            };

            Post["/stylists/new"] = _ => {
                Stylist newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-experience"]);
                newStylist.Save();
                List<Stylist> AllStylists = Stylist.GetAll();
                return View["stylists.cshtml",AllStylists];
            };

            Get["/clients/new"] = _ => {
                List<Stylist> AllStylists = Stylist.GetAll();
                return View["new_client_form.cshtml", AllStylists];
            };

            Post["/clients/new"] = _ => {
                Client newClient = new Client(Request.Form["client-name"], Request.Form["client-hair-style"], Request.Form["stylist-id"]);
                newClient.Save();
                List<Client> AllClients = Client.GetAll();
                return View["clients.cshtml", AllClients];
            };

            Get["/stylists/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>{};
                var SelectedStylist = Stylist.Find(parameters.id);
                var StylistClients = SelectedStylist.GetClients();
                model.Add("stylist", SelectedStylist);
                model.Add("clients", StylistClients);
                return View["stylist.cshtml", model];
            };
        }
    }
}
