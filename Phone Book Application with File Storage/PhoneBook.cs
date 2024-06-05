namespace Phone_Book_Application_with_File_Storage;
using Newtonsoft.Json;

/*
 *  Class PhoneBook - class for console application that functions as a phone book,
 *  allowing users to add, remove, update, search and list contacts.
 *  The application stores contact information in a file to maintain persistence across sessions
 */
public class PhoneBook
{
    private Dictionary<string, Contact> _contacts;  // stores contact data, contact name is the key
    private const string path = "C:\\Users\\asusVivo\\RiderProjects\\Phone Book Application with File Storage\\Phone Book Application with File Storage\\contacts.json";
    private IContactsHandlerForFile<Contact> _handlerForFile;
    private IValidation _validationHandler;
    
    
    
    /*
     *  This class is written for Json file format and Georgian phone numbers,
     *  Constructor initializes suitable ContactsHandlerForJson and GeorgianNumberValidation
     *  to the attributes _handlerForFile and _validationHandler respectively
     */ 
    public PhoneBook()
    {
        _contacts = new Dictionary<string, Contact>();
        _handlerForFile = new ContactsHandlerForJson(path);
        _validationHandler = new GeorgianNumberValidation();
    }

    
    
    
    /*
     *  AddContact(name, phoneNumber) simply maps name and contact.
     *  Stores into the dictionary and some file with path - 'path' 
     */
    public void AddContact(string name, string phoneNumber)
    {
        if (_contacts.ContainsKey(name) || !_validationHandler.Validate(phoneNumber))
        {
            throw new ArgumentException("Invalid name or phone number");
        }
        
        _contacts.Add(name, new Contact(name, phoneNumber));
        _handlerForFile.AddToFile(new Contact(name, phoneNumber));
    }

    
    
    
    /*
     *  RemoveContact(name) - Removes Contact with given name from dictionary and from the file as well 
     */
    public void RemoveContact(string name)
    {
        if (!_contacts.ContainsKey(name))
        {
            throw new ArgumentException("Invalid name");
        }

        _handlerForFile.RemoveFromFile(_contacts[name]);
        _contacts.Remove(name);
    }
    
    
    
    
    /*
     *  UpdateContact(name, newPhoneNumber) changes old phone number with new one
     *  For updating everything in the file at the same time, Remove and Add methods are used here
     */
    public void Update(string name, string newPhoneNumber)
    {
        RemoveContact(name);
        AddContact(name, newPhoneNumber);
    }
    
    
    
    /*
     *  Search(name) - searches and returns Contact with given name
     */
    public Contact search(string name)
    {
        return _contacts[name];
    }
    
    
    
    
    /*
     *  ListContacts() return contacts as a list
     */
    public List<Contact> ListContacts()
    {
        return _handlerForFile.List();
    }

    
    
    
    /*
     *  LoadContacts() displays all the contacts in the console
     */
    public void LoadContacts()
    {
        _handlerForFile.Load();
    }
}