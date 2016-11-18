using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Address
  {
    private string _street;
    private string _city;
    private string _state;
    private int _id;
    private static List<Contact> _contacts = new List<Contact> {};

    public Contact(string name, string address, string phoneNumber, string details)
    {
      _name = name;
      _address = address;
      _phoneNumber = phoneNumber;
      _details = details;
      _id = _contacts.Count;
      _contacts.Add(this);
    }
  }
}
