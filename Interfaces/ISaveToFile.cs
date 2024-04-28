using ContactLibraryConsole.Classes;
namespace ContactLibraryConsole.Interfaces
{
    public interface ISaveToFile
    {
         bool CreateContact(Contact contact);
         bool DeleteContact(string number);
         bool EditContact(string number_1, string name, string number_2);
         List<Contact> GetContacts();
    }
}