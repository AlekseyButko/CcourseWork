using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Data_Access_Layer
{
    public class Serializator
    {
        public Serializator()
        {

        }
        public void SaveData(string fileName, object data)
        {
            // создание файлового потока по имени .dat-файла и указание создания/перезаписи файла.
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create))
            {
                binFormat.Serialize(fStream, data);
                fStream.Close();
            }
        }
        public object LoadData(string fileName)
        {
            // открытие .dat-файла по его имени и десериализация данных из него.
            return new BinaryFormatter().Deserialize(File.OpenRead(fileName));
        }
    }
}
