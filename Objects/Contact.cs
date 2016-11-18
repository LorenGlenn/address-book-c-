using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private string _name;
    private string _address;
    private string _phoneNumber;
    private string _details;
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

    public string GetName()
    {
      return _name;
    }
    public string GetAddress()
    {
      return _address;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public string GetDetails()
    {
      return _details;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Contact> GetAllContacts()
    {
      return _contacts;
    }
    public static Contact Find(int searchId)
    {
      return _contacts[searchId];
    }
    public static void ClearContacts()
    {
      _contacts.Clear();
    }
    public void DeleteContact()
    {
      _contacts.[searchId].Remove();
    }
  }
}
