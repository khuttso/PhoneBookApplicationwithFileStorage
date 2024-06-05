using System;
using Phone_Book_Application_with_File_Storage;
using Newtonsoft.Json;
namespace Run;

public class Program
{
    
    public static void Main(string[] args)
    {
        // Console.WriteLine(c.Name + " " + c.PhoneNumber);
        //
        //

        // string x = "abcd.Json";
        // Console.WriteLine(x.Substring(x.Length - 4));
        //

        Contact c = new Contact("asd","+995599310860");
        Contact c2 = new Contact("as1","+995599310861");
        Contact c3= new Contact("asd2","+995599310862");
        Contact c4 = new Contact("asd3","+995599310863");
        Contact c5 = new Contact("asd4","+995599310864");
        PhoneBook phoneBook = new PhoneBook();
        phoneBook.AddContact(c.Name, c.PhoneNumber);
        phoneBook.AddContact(c3.Name, c3.PhoneNumber);
        phoneBook.AddContact(c2.Name, c2.PhoneNumber);
        phoneBook.AddContact(c4.Name, c4.PhoneNumber);
        phoneBook.AddContact(c5.Name, c5.PhoneNumber);
        
        
        string path =
            "C:\\Users\\asusVivo\\RiderProjects\\Phone Book Application with File Storage\\Phone Book Application with File Storage\\contacts.json";


        // StreamWriter sw = new StreamWriter(path);
        // sw.Write(jsonString);
        // string jsonString = JsonConvert.SerializeObject(new Contact("abc", "+995599310860"));

        // using (StreamWriter writer = new StreamWriter(path, true))
        // {
        //     writer.WriteLine(jsonString);
        // }
        //
        // using (StreamReader sr = new StreamReader(path))
        // {
        //     string s = sr.ReadLine();
        //     while (s != null)
        //     {
        //         Console.WriteLine(s);
        //         s = sr.ReadLine();
        //     }
        // }
        //
        // File.WriteAllText(path, "");
        //
        // File.WriteAllText(path, jsonString);
        
        // PhoneBook phoneBook = new PhoneBook();
        // phoneBook.AddContact("Abcd", "+995599310860");
        // phoneBook.AddContact("Abcde", "+995599310861");
        // phoneBook.AddContact("Abcdef", "+995599310862");
        //
        // phoneBook.LoadContacts();
        //
        //
    }
}


