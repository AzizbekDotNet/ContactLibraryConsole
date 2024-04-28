using ContactLibraryConsole.Interfaces;

namespace ContactLibraryConsole.Classes
{
    public class ContactOperation : IContactOperation
    {
         ISaveToFile stf = new SaveToFile();
         
         public bool CreateContact(string name, string number)
         {
            Contact contact =  new Contact(name, number);
          
            return stf.CreateContact(contact);
         }
         public bool DeleteContact(string number)
         { 
            return stf.DeleteContact(number);
         }
         public bool EditContact(string number_1, string name, string number_2)
         {
            if(stf.EditContact(number_1,name,number_2))
            {
               Contact contact = new Contact(name, number_2);
               return true;
            }
            return false;
         }
         public List<Contact> GetContacts()
         {
            return stf.GetContacts();
         }
         public List<Contact> GetByNameContacts(string name)
         {
            var lst = stf.GetContacts();
            var lst_1 = new List<Contact>();
            foreach(var ct in lst)
            {
               if(ct.Name.ToLower() == name.ToLower())
               {
                  lst_1.Add(ct);
               }
            }
            return lst_1;
         }
    }
}