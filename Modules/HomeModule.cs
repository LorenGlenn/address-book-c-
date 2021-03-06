using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        var viewAll = Contact.GetAllContacts();
        return View["index.cshtml", viewAll];
      };
      Get["/contacts/new"] =_=> View["new-contact-form.cshtml"];
      Post["/contacts/contact-added"] =_=>
      {
        Contact newContact = new Contact(Request.Form["name"], Request.Form["phone"], Request.Form["details"]);
        Address newAddress = new Address(Request.Form["street"], Request.Form["city"], Request.Form["state"]);
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("contact", newContact);
        model.Add("address", newAddress);
        return View["contact-added.cshtml", model];
      };
      Get["/contacts/{id}/view-details"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        var contactAddress = Address.Find(parameters.id);
        model.Add("contact", selectedContact);
        model.Add("address", contactAddress);
        return View["view-details.cshtml", model];
      };
      Post["/contacts/clear"] =_=>
      {
        Contact.ClearContacts();
        return View["cleared.cshtml"];
      };
      Post["/contacts/{id}/remove"] = parameters =>
      {
        Contact.DeleteContact(parameters.id);
        var viewAll = Contact.GetAllContacts();
        return View["index.cshtml", viewAll];
      };
      Post["/search"] =_=>
      {
        var search = Request.Form["searchContact"];
        List<Contact> matchingContacts = Contact.FilterContact(search);
        return View["index.cshtml", matchingContacts];
      };
    }
  }
}
