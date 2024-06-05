using System.Collections;

namespace Phone_Book_Application_with_File_Storage;
using Newtonsoft.Json;

/*
 * Class ContactsHandlerForJson - class based on IContactsHandledForFile.
 * interface methods are implemented for Json file.
 *
 * JsonConvert.SerializeObject(...); and JsonConvert.DeserializeObject(...); methods of the package
 * Newtonsoft.Json are used to do standard serialization of the data;
 *
 * Class is written for Json file and all the cases(other file type) that may cause error are handled
 * 
 */

public class ContactsHandlerForJson : IContactsHandlerForFile<Contact>
{
    private readonly string path; 

    
    
    /*
     * Constructor receives string path, which is supposed to be Json file location.
     * Here is simply checked if the path is incompatible for format Json
     */
    public ContactsHandlerForJson(string path)
    {
        if (path.Substring(path.Length-5) != ".json")
        {
            throw new ArgumentException("Incompatible File Path");

        }
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File does not exist");
        }

        this.path = path;
    }
    
    public string Path { get; }
    
    
    
    
    /*
     *  By calling AddToFile(obj) - Based on task description Serialized data of obj
     *  is added into the file
     */
    public void AddToFile(Contact obj)
    {
        string readJsonData = File.ReadAllText(path);
        List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(readJsonData);
        if (contacts == null) contacts = new List<Contact>();
        
        contacts.Add(obj);
        string serializedContacts = JsonConvert.SerializeObject(contacts);
        Clear();
        using (StreamWriter sw = new StreamWriter(path, true))
        {
            sw.WriteLine(serializedContacts);                        
        }
    }

    
    
    
    /*
     *  RemoveFromFile(obj) removes object from the file by using following steps:
     *  Reads data from the file.
     *  Deserializes read data and stores in collection.
     *  Removes Data From the collection
     *  Writes updated data into the file
     */
    public void RemoveFromFile(Contact obj)
    {
        // making list of contact objects from Json file
        string jsonData = File.ReadAllText(path);
        List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonData);
        contacts.RemoveAll(c => c.Equals(obj));
        
        this.Clear();

        using (StreamWriter sw = new StreamWriter(path, true)) 
        {
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }
    }

    
    
    
    /*
     * List() - deserializes json data and returns it as list 
     */
    public List<Contact> List()
    {
        string jsonData = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<Contact>>(jsonData);
    }

    
    
    
    /*
     *  Load() - iterates over deserialized data and print
     */
    public void Load()
    {
        foreach (Contact c in List()) 
        {
            Console.WriteLine(c.ToString());
        }
    }

    
    
    public void Clear()
    {
        File.WriteAllText(path, "");
    }
}