namespace Phone_Book_Application_with_File_Storage;
using Newtonsoft.Json;

/// <summary>
///     class <c>Phonebook</c>> - class for console application that functions as a phone book,
///     allowing users to add, remove, update, search and list contacts.
///     The application stores contact information in a file to maintain persistence across sessions 
/// </summary>
/// 
public class PhoneBook
{
    private Dictionary<string, Contact> _contacts;  
    private const string path = "contacts.json";
    private IContactsHandlerForFile<Contact> _handlerForFile;
    private IValidation _validationHandler;
    
    
    
    /// <summary>
    ///     This class is written for Json file format and Georgian phone numbers,
    ///     Constructor initializes suitable ContactsHandlerForJson and GeorgianNumberValidation
    ///     to the attributes _handlerForFile and _validationHandler respectively     
    /// </summary>
    public PhoneBook() 
    {
        _contacts = new Dictionary<string, Contact>();
        _handlerForFile = new ContactsHandlerForJson(path);
        _validationHandler = new GeorgianNumberValidation();
    }

    
    
    
    /// <summary>
    ///     AddContact(name, phoneNumber) simply maps name and contact.
    ///     Stores into the dictionary and some file with path - 'path' 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="phoneNumber"></param>
    /// <exception cref="ArgumentException"></exception>
    /// thrown when name does not appear in contacts or phone number is not valid
    public void AddContact(string name, string phoneNumber)
    {
        if (_contacts.ContainsKey(name) || !_validationHandler.Validate(phoneNumber))
        {
            throw new ArgumentException("Invalid name or phone number");
        }
        
        _contacts.Add(name, new Contact(name, phoneNumber));
        _handlerForFile.AddToFile(new Contact(name, phoneNumber));
    }

    
    
    
    /// <summary>
    ///     RemoveContact(name) - Removes Contact with given name from dictionary and from the file as well
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="ArgumentException"></exception>
    /// thrown when name does not appear in contacts
    public void RemoveContact(string name)
    {
        if (!_contacts.ContainsKey(name))
        {
            throw new ArgumentException("Invalid name");
        }

        _handlerForFile.RemoveFromFile(_contacts[name]);
        _contacts.Remove(name);
    }
    
    
    
    
    /// <summary>
    ///     UpdateContact(name, newPhoneNumber) changes old phone number with new one
    ///     For updating everything in the file at the same time, Remove and Add methods are used here
    /// </summary>
    /// <param name="name"></param>
    /// <param name="newPhoneNumber"></param>
    public void Update(string name, string newPhoneNumber)
    {
        RemoveContact(name);
        AddContact(name, newPhoneNumber);
    }
    
    
    
    /// <summary>
    ///     Search(name) - searches and returns Contact with given name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Contact Search(string name)
    {
        return _contacts[name];
    }
    
    
    
    
    /// <summary>
    ///     ListContacts() return contacts as a list
    /// </summary>
    /// <returns></returns>
    public List<Contact> ListContacts()
    {
        return _handlerForFile.List();
    }

    
    
    
    /// <summary>
    ///     LoadContacts() displays all the contacts in the console
    /// </summary>
    public void LoadContacts()
    {
        _handlerForFile.Load();
    }
}