using ContactLibraryConsole.Interfaces;

namespace ContactLibraryConsole.Classes
{
    public class ShowUI : IShowUI
    {
        IContactOperation operation = new ContactOperation();
        IExeptions exeptions = new Exeptions();
        public void MainMenu()
        {
            try
            {
                Console.Clear();
            Console.WriteLine("\t\tBosh Menyu");
            Console.WriteLine("1. Kontakt qo'shish");
            Console.WriteLine("2. Kontakt o'chirish");
            Console.WriteLine("3. Kontakt tahrirlash");
            Console.WriteLine("4. Kontaktlar ro'yxati");
            Console.WriteLine("5. Kontakt qidirish");
            Console.Write("Buyuruq kiriting: ");
            int n = int.Parse(Console.ReadLine());
            switch(n)
            {
                case 1: CreateMenu(); break;
                case 2: DeleteMenu(); break;
                case 3: EditMenu(); break;
                case 4: GetDataMenu(); break;
                case 5: GetNameMenu(); break;
                default: Console.WriteLine("Buyuruq xato kiritildi !!!"); break;
            }
            Console.WriteLine("Press to anyway !"); 
            Console.ReadKey(); 
            MainMenu();
            }
            catch
            {
                MainMenu();
            }
        }
        public void CreateMenu()
        {
            Console.Clear();
            Console.Write("Ism: ");
            string ?name = Console.ReadLine();
            Console.Write("Nomer: ");
            string number = Console.ReadLine();
            if(operation.CreateContact(name,number))
            {
                Console.WriteLine("Kontakt muaffaqiyatli qo'shildi !!!");
            }
            else
            {
                Console.WriteLine(exeptions.FileExpection());
            } 
            Console.WriteLine("Press to anyway !"); 
            Console.ReadKey(); 
            MainMenu();
        }
        public void DeleteMenu()
        {
            Console.Clear();
            Console.Write("Nomer: ");
            string number = Console.ReadLine();
            if(operation.DeleteContact(number))
            {
                Console.WriteLine("Kontakt muaffaqiyatli o'chirildi !!!");
            }
            else
            {
                Console.WriteLine(exeptions.FileExpection());
            } 
            Console.WriteLine("Press to anyway !"); 
            Console.ReadKey(); 
            MainMenu();
        }
        public void EditMenu()
        {
            Console.Clear();
            Console.Write("Kontakt raqam kiriting: ");
            string number_1 = Console.ReadLine();
            Console.Write("Ism: ");
            string ?name = Console.ReadLine();
            Console.Write("Nomer: ");
            string number_2 = Console.ReadLine();
            
            if(operation.EditContact(number_1,name,number_2))
            {
                Console.WriteLine("Kontakt muaffaqiyatli o'zgartirildi !!!");
            }
            else
            {
                Console.WriteLine(exeptions.FileExpection());
            } 
            Console.WriteLine("Press to anyway !"); 
            Console.ReadKey(); 
            MainMenu();
        }
        public void GetDataMenu()
        {
            Console.Clear();
            var ls = operation.GetContacts();
            if(ls.Count == 0)
            {
                Console.WriteLine(exeptions.NullExpection());
                Console.WriteLine("Press to anyway !");
                Console.ReadKey();
                MainMenu();
            }
            foreach (var item in ls)
            {
                Console.WriteLine($"Ism: {item.Name}\tNomer: {item.PhoneNumber}");
            }
            Console.WriteLine("Press to anyway !"); 
            Console.ReadKey(); 
            MainMenu();
        }
        public void GetNameMenu()
        {
            Console.Clear();
            Console.Write("Ism: ");
            string ?name = Console.ReadLine();
            var ls = operation.GetByNameContacts(name);
            if(ls.Count == 0)
            {
                string errorMessage = exeptions.NullExpection();
                Console.WriteLine(errorMessage);
                Console.WriteLine("Press to anyway !");
                Console.ReadKey();
                MainMenu();
            }
            foreach (var item in ls)
            {
                Console.WriteLine($"Ism: {item.Name}\tNomer: {item.PhoneNumber}");
            }
            Console.WriteLine("Press to anyway !"); 
            Console.ReadKey(); 
            MainMenu();
        }
    }
}