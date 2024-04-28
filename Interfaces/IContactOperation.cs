using ContactLibraryConsole.Classes;
namespace ContactLibraryConsole.Interfaces
{
    public interface IContactOperation
    {
         bool CreateContact(string name, string number);
         bool DeleteContact(string number);
         bool EditContact(string number_1, string name, string number_2);
         List<Contact> GetContacts();
         List<Contact> GetByNameContacts(string name);
    }
}