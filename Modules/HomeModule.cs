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

    }
  }
}
