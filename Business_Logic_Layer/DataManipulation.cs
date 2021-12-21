using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Business_Logic_Layer
{
    public class DataManipulation
    {
        [ExcludeFromCodeCoverage]
        public DataManipulation()
        {
        }
        [ExcludeFromCodeCoverage]
        public void SaveAllData()
        {
            ClientManagement cm = new ClientManagement(); // получаем экземпляры, через которые
            PropertyManagement pm = new PropertyManagement(); // будут вызываться методы сохранения
            cm.Save();
            pm.Save();
        }
        [ExcludeFromCodeCoverage]
        public void LoadAllData()
        {
            ClientManagement cm = new ClientManagement(); // получаем экземпляры, через которые
            PropertyManagement pm = new PropertyManagement(); // будут вызываться методы загрузки

            if (File.Exists("Clients.dat") && File.Exists("Properties.dat")) // проверка, существуют ли эти файлы
            { // если да, вызвать методы загрузки Клиентов и Недвижимостей.
                cm.Load();
                pm.Load();
            } // иначе - бросить исключение.
            else throw new FileNotFoundException("Files Properties.dat and/or Clients.dat were not found.");
        }
    }
}
