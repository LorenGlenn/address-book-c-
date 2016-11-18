using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Address
  {
    private string _street;
    private string _city;
    private string _state;
    private int _id;
    private static List<Address> _addresses = new List<Address> {};

    public Address(string street, string city, string state)
    {
      _street = street;
      _city = city;
      _state = state;
      _id = _addresses.Count;
      _addresses.Add(this);
    }

    public static Address Find(int searchId)
    {
      return _addresses[searchId];
    }
  }
}
