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
        Contact newContact = new Contact(Request.Form["name"], Request.Form["address"], Request.Form["phone"], Request.Form["details"]);
        return View["contact-added.cshtml", newContact];
      };
      Get["/contacts/{id}/view-details"] = parameters =>
      {
        var selectedContact = Contact.Find(parameters.id);
        return View["view-details.cshtml", selectedContact];
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
