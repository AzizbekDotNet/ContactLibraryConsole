using ContactLibraryConsole.Interfaces;
using System.IO;

namespace ContactLibraryConsole.Classes
{
    public class SaveToFile : ISaveToFile
    {
         private string path = "Contacts.txt";
         
         public bool CreateContact(Contact contact)
         {
            try
            {
                using(StreamReader sr = new StreamReader(path))
                {
                   string line;
                   while((line = sr.ReadLine()) != null)
                   {
                      string[] strings = line.Split();

                      if(contact.PhoneNumber == strings[1])
                      {
                          return false;
                      }
                   }        
                }
                File.AppendAllText(path, $"{contact.Name} {contact.PhoneNumber}\n");
                return true;
            }
            catch
            {
                return false;
            }
         }
         public bool DeleteContact(string number)
         {
            try
            {
                List<Contact> contactList = new List<Contact>();
                using(StreamReader sr = new StreamReader(path))
                {
                   string line;
                   int i=0;
                   while((line = sr.ReadLine()) != null)
                   {
                      string[] strings = line.Split();
                     
                      if(number != strings[1])
                      {
                          Contact contact = new Contact(strings[0], strings[1]);
                          contactList.Add(contact);
                      }
                      else
                      {
                        i++;
                      } 
                   }  
                   if(i == 0) return false;      
                }
                using(StreamWriter sw = new StreamWriter(path))
                {
                    foreach(var contact in contactList)
                    {
                        sw.WriteLine($"{contact.Name} {contact.PhoneNumber}");
                    }
                }
                return true;
            }
            catch
            {
                return false;
            } 
         }
         public bool EditContact(string number_1, string name, string number_2)
         {
            try
            {
                List<Contact> contactList = new List<Contact>();
                using(StreamReader sr = new StreamReader(path))
                {
                   string line;
                   int i=0;
                   while((line = sr.ReadLine()) != null)
                   {
                      string[] strings = line.Split();
                      
                      if(number_1 != strings[1])
                      {
                          Contact contact = new Contact(strings[0], strings[1]);
                          contactList.Add(contact);
                      }
                      else
                      {
                        i++;
                      } 
                   }  
                   if(i==0)
                      {
                        return false;
                      }      
                }
                Contact contact1 = new Contact(name, number_2);
                contactList.Add(contact1);
                using(StreamWriter sw = new StreamWriter(path))
                {
                    foreach(var contact in contactList)
                    {
                        sw.WriteLine($"{contact.Name} {contact.PhoneNumber}");
                    }
                }
                return true;
            }
            catch
            {
                return false;
            } 
         }
         public List<Contact> GetContacts()
         {
            List<Contact> contactList = new List<Contact>();
            using(StreamReader sr = new StreamReader(path))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] strings = line.Split();
                    Contact contact = new Contact(strings[0], strings[1]);
                    contactList.Add(contact);
                }        
            }
            return contactList;
         }
    }
}