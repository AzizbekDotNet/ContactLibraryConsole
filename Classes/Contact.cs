namespace ContactLibraryConsole.Classes
{
    public class Contact
    {
        public string ?Name {get; set;}
        public string PhoneNumber {get; set;}

        public Contact(string name, string phonenumber)
        {
            Name = name;
            PhoneNumber = phonenumber;
        }
    }
}