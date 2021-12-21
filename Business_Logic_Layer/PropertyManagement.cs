using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Business_Logic_Layer
{
    [Serializable]
    public class PropertyManagement
    {
        [Serializable]
        public enum SortingParameter { Type, Cost, ID }; // перечень возможных способов сортировки списка Недвижимости

        public PropertyManagement()
        {
            this.properties = new List<Property>();
        }
        private List<Property> properties;
        // 2.1. Добавить Недвижимость
        public void AddProperty(Property.PropertyType type, int cost)
        {
            int ID = -1;
            if (properties.Count == 0) ID = 1; // если к-во Недвижимостей == 0, то номер = 1, иначе номер = номер последней Недвижимости + 1.
            else ID = properties[properties.Count - 1].ID + 1;
            properties.Add(new Property(type, cost, ID));
        }
        // 2.2. Удалить Недвижимость

        
        public void DeleteProperty(int ID)
        {
            Property found = GetProperty(ID); // поиск Недвижимости по ID
            properties.Remove(found); // удалить её.
        }
        // 2.3. Изменить Недвижимость

        
        public void ChangePropertyInfo(int ID, Property.PropertyType newType, int newCost)
        {
            Property property = GetProperty(ID); // поиск Недвижимости по ID
            // изменить её данные на новые.
            property.SetType(newType);
            property.SetCost(newCost);
            // ID - уникально, менятся не должно.
        }
        // 2.4. Данные о Недвижимости

        
        public string GetPropertyInfo(int ID)
        {
            Property found = properties.Find(property => property.ID == ID);
            if (found == null) // если такая Недвижимость не найдена, то бросить исключение
                throw new Exception("Нерухомiсть з ID " + ID + " не iснує!");
            else // иначе получить данные из Property.ToString().
                return found.ToString();
        }
        // 2.5. Данные о всех Недвижимостях с сортировкой.
        
        public string GetAllPropertiesSortedInfo(SortingParameter param)
        {
            switch (param)
            {
                // сортировка List.Sort() https://msdn.microsoft.com/ru-ru/library/b0zbh7b6(v=vs.110).aspx
                // передавая сразу реализований через лямбда-выражение делегат, который сравнивает два объекта-Клиентов с помощью CompareTo()
                // https://msdn.microsoft.com/ru-ru/library/system.icomparable.compareto(v=vs.110).aspx
                case SortingParameter.Type: // если по имени:
                    properties.Sort((x, y) => x.Type.CompareTo(y.Type)); // через лямбду
                    // clients.Sort(delegate (Client x, Client y) { return x.Name.CompareTo(y.Name); }); // либо через делегат.
                    break;
                case SortingParameter.Cost: // если по фамилии:
                    properties.Sort((x, y) => x.Cost.CompareTo(y.Cost)); // через лямбду
                    break;
                case SortingParameter.ID: // если по номеру счета:
                    properties.Sort((x, y) => x.ID.CompareTo(y.ID)); // через лямбду
                    break;
                default: throw new ArgumentException("Sorting parameter error."); // если по какой-то черной магии что-то пошло не так
            }
            // создание строки с информацией в табличном виде
            string info = "ID\t|\tТип\t| Цiна\n";
            foreach (Property property in properties)
                info += (property.ID + "\t|\t" + property.Type + "\t|\t" + property.Cost + "\n");
            return info;
        }
        // 3.2. Поиск Недвижимости по заданым параметрам
        public Property[] GetPropertiesBy(Property.PropertyType type, int cost)
        {
            List<Property> props = properties.FindAll(property =>
                property.Type == type &&
                property.Cost == cost);
            return props.ToArray();
        }

        
        public Property GetProperty(int propertyID)
        {
            // ЦЕЛЬ метода - убедиться, что такая Недвижимость существует
            // и получить конкретный её экзмпляр, а никакую не её копию.
            // поиск Недвижимости по propertyID с использованием лямбда-выражения (=>).
            // https://msdn.microsoft.com/ru-ru/library/x0b5b5bc(v=vs.110).aspx - метод List.Find()
            Property found = properties.Find(property => property.ID == propertyID);
            if (found == null) // если такая Недвижимость не найдена, то бросить исключение
                throw new Exception("Нерухомiсть з ID " + propertyID + " не iснує!");
            else // если найдена, то всё хорошо, вернуть её.
                return found;
        }
        // 4.2. Поиск среди Недвижимостей по ключевому слову

        
        public string Search(string keyword)
        {
            string result = "";
            // List.FindAll() - тот же принцип, что и List.Find(),
            // но возвращаются все найденные объекты в виде списка, а не один.
            List<Property> found = properties.FindAll(property =>
                                property.Type.ToString().Equals(keyword) || // сравниваются все атрибуты Недвижимостей из 
                                property.Cost.ToString().Equals(keyword) ||
                                property.ID.ToString().Equals(keyword));
            foreach (Property property in found)
                result += property.ToString() + "\n\n";
            return
                found.Count > 0 ?       // если хоть кого-то нашло,
                result :                // то вернуть результат,
                "Нічого не знайдено.";  // иначе - вот это.
            // Структура [(условие) ? value_1 : value_2;] - то же самое, что if(условие) {value_1} else {value_2}.
        }
        
        internal void Save()
        {
            Serializator ser = new Serializator(); // получаем объект сериализатора
            ser.SaveData("Properties.dat", this.properties); // сериализуем объект(список) в файл.
        }
        internal void Load()
        {
            Serializator ser = new Serializator(); // получаем объект сериализатора
            object loadedObj = ser.LoadData("Properties.dat"); // десериализуем через него данные в объект loadedObj

            properties = (List<Property>)loadedObj;
            // изначально была сериализация объекта(списка) типа List<Property>, 
            // поэтому явно приводим loadedObj к этому типу. 
            // Получается список Недвижимостей, десериализованный с файла.
        }
    }
}
