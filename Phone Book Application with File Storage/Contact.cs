using Newtonsoft.Json;

namespace Phone_Book_Application_with_File_Storage;
using System.Text.Json;
/*
 *  Data class contact with attributes: string name, string phoneNumber
 *  Because of Data class, the methods int GetHashCode(), bool Equals(Object? obj), ToString()
 *  are overrided here and fields name and phoneNumber are readonly.
 *  
 */
public class Contact
{
    private readonly string name;
    private readonly string phoneNumber;
    
    public string Name
    {
        get { return name; }
    } 
    public string PhoneNumber
    {
        get { return phoneNumber; }
    }

    public Contact(string name, string phoneNumber)
    {
        this.name = name;
        this.phoneNumber = phoneNumber;
    }

    
    public override bool Equals(object? obj)
    {
        if (obj is Contact other) 
        {
            return other.PhoneNumber.Equals(PhoneNumber) && other.Name.Equals(Name);
        }
        
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, PhoneNumber); 
    }

    public override string ToString()
    {
        return $"Name: {Name}, PhoneNumber: {PhoneNumber}.";
    }
}