using ContactLibraryConsole.Interfaces;

namespace ContactLibraryConsole.Classes
{
    public class Exeptions : IExeptions
    {
        public string NullExpection()
        {
            return "Ma'lumot topilmadi !!!";
        }
        public string FileExpection()
        {
            return "File ga saqlashda xatolik !!!";
        }
        public string TypeExpection()
        {
            return "Noto'g'ri tip !!!";
        }
    }
}