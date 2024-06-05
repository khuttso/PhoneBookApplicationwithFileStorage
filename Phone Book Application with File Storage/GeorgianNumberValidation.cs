namespace Phone_Book_Application_with_File_Storage;

/*
 * Class GeorgianNumberValidation - for checking if phone number is valid.
 * For Georgia - number must start with '+9955' and 8 digit
 */

public class GeorgianNumberValidation : IValidation
{
    public bool Validate(string number)
    {
        return number.Length == 13 && number.Substring(0, 5) == "+9955";
    }
}