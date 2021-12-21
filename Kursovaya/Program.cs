using Business_Logic_Layer;
using System;
using System.IO;
namespace Kursovaya
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManipulation DM = new DataManipulation();

            try
            {
               DM.LoadAllData(); // загрузка всех данных при запуске.

                Menu.Start(); // запуск всего и вся.

                DM.SaveAllData(); // сохранение всех данных при выходе.
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
