using System.Collections.Generic;
using System.Globalization;

namespace AddressBook.Objects
{
  public class Contact
  {
    private string _name;
    private string _phoneNumber;
    private string _details;
    private int _id;
    private static List<Contact> _contacts = new List<Contact> {};

    public Contact(string name, string phoneNumber, string details)
    {
      TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
      string titleName = textInfo.ToTitleCase(name);
      _name = titleName;
      _phoneNumber = phoneNumber;
      _details = details;
      _id = _contacts.Count;
      _contacts.Add(this);

    }

    public string GetName()
    {
      return _name;
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
    public static void DeleteContact(int searchId)
    {
      _contacts.RemoveAt(searchId);
    }
    public static List<Contact> FilterContact(string searchContact)
    {
      TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
      string searchName = textInfo.ToTitleCase(searchContact);
      List<Contact> matches = new List<Contact> {};
      foreach(Contact c in _contacts)
      {
        if(c._name == searchName)
        {
          matches.Add(c);
        }
      }
      return matches;
    }
  }
}
