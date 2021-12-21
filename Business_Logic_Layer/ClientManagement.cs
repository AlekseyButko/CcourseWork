using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Business_Logic_Layer
{
    [Serializable]
    public class ClientManagement
    {
        [Serializable]
        public enum SortingParameter { Name, Surname, Number }; // перечень возможных способов сортировки списка Клиентов
        public ClientManagement()
        {
            this.clients = new List<Client>();
        }
        private List<Client> clients;
        // 1.1. Добавить Клиента
        public void AddClient(string name, string surname)
        {
            int accountNumber = -1;
            if (clients.Count == 0) accountNumber = 1; // если к-во Клиентов == 0, то номер = 1, иначе номер = номер последнего Клиента + 1.
            else accountNumber = clients[clients.Count - 1].AccountNumber + 1;
            clients.Add(new Client(name, surname, accountNumber));
        }
        // 1.2. Удалить Клиента
        public void DeleteClient(int accountNumber)
        {
            Client client = GetClient(accountNumber); // поиск Клиента
            clients.Remove(client); // удаление
        }
        // 1.3. Изменить Клиента
        public void ChangeClientInfo(int accountNumber, string newName, string newSurname)
        {
            Client found = GetClient(accountNumber); // поиск Клиента
            // изменение данных на новые.
            found.SetName(newName);
            found.SetSurname(newSurname);
            // AccountNumber - уникальный, меняться не должен.
        }
        // 1.4. Данные о Клиенте
        public string GetClientInfo(int accountNumber)
        {
            Client found = clients.Find(client => client.AccountNumber == accountNumber);
            if (found == null) // если такой Клиент не найден, то бросить исключение
                throw new Exception("Клiєнт з номером рахунку " + accountNumber + " не iснує!");
            else // иначе получить данные из Client.ToString().
                return found.ToString();
        }
        // 1.5. Данные о всех Клиентах с сортировкой.
        [ExcludeFromCodeCoverage]
        public string GetAllClientsSortedInfo(SortingParameter param)
        {
            switch (param)
            {
               

                case SortingParameter.Name: // если по имени:
                    clients.Sort((x, y) => x.Name.CompareTo(y.Name)); // через лямбду
                    // clients.Sort(delegate (Client x, Client y) { return x.Name.CompareTo(y.Name); }); // либо через делегат.
                    break;
                case SortingParameter.Surname: // если по фамилии:
                    clients.Sort((x, y) => x.Surname.CompareTo(y.Surname)); // через лямбду
                    break;
                case SortingParameter.Number: // если по номеру счета:
                    clients.Sort((x, y) => x.AccountNumber.CompareTo(y.AccountNumber)); // через лямбду
                    break;
                default: throw new ArgumentException("Sorting parameter error."); // если по какой-то черной магии что-то пошло не так
            }
            // создание строки с информацией в табличном виде
            string info = "Iм'я\t|\tПрiзвище\t| Номер\n";

            foreach (Client client in clients)
                info += (client.Name + "\t|\t" + client.Surname + "\t|\t" + client.AccountNumber + "\n");
            return info;
        }
        // 3.1 Добавление Предложения Клиенту
        [ExcludeFromCodeCoverage]
        public void AddOffer(int accountNumber, int propertyID, PropertyManagement pm)
        {
            Client client = GetClient(accountNumber);
            client.AddOffer(propertyID, pm);
            // все проверки выполняются в методе AddOffer().
        }
        public Client GetClient(int accountNumber)
        {
            // ЦЕЛЬ метода - убедиться, что такой Клиент существует
            // и получить конкретный его экзмпляр, а никакую не его копию.
            // поиск Клиента по accountNumber с использованием лямбда-выражения (=>).
            // https://msdn.microsoft.com/ru-ru/library/x0b5b5bc(v=vs.110).aspx - метод List.Find()
            Client found = clients.Find(client => client.AccountNumber == accountNumber);
            if (found == null) // если такой Клиент не найден, то бросить исключение
                throw new Exception("Клiєнт з номером рахунку " + accountNumber + " не iснує!");
            else // если найден, то всё хорошо, вернуть его.
                return found;
        }
        // 4.1, 4.4. Поиск среди Клиентов по ключевому слову
        [ExcludeFromCodeCoverage]
        public string Search(string keyword, bool extendedSearch)
        {
            string result = "";
            if (extendedSearch == false) // если поиск только по самому Клиенту
            {
                // List.FindAll() - тот же принцип, что и List.Find(),
                // но возвращаются все найденные объекты в виде списка, а не один.
                List<Client> found = clients.FindAll(client => client.Name.Equals(keyword) || client.Surname == keyword);
                foreach (Client client in found)
                    result += client.ToString() + "\n\n";
                return
                    found.Count > 0 ?       // если хоть кого-то нашло,
                    result :                // то вернуть результат,
                    "Нічого не знайдено.";  // иначе - вот это.
                // Структура [(условие) ? value_1 : value_2;] - то же самое, что if(условие) {value_1} else {value_2}.
            }
            else // а если поиск расширенный
            {
                foreach (Client client in clients)
                {
                    if (client.Name.Equals(keyword) || // сравниваются все атрибуты Клиента
                        client.Surname.Equals(keyword) ||
                        client.AccountNumber.Equals(keyword))
                    {
                        result += client.ToString() + "\n\n"; // добавить к результату
                    }
                    else
                    {
                        foreach (Property property in client.GetOffersList()) // проверить предложения каждого Клиента
                        {
                            if (property.Type.ToString().Equals(keyword) ||// сравниваются все атрибуты Недвижимостей из 
                                property.Cost.ToString().Equals(keyword) ||
                                property.ID.ToString().Equals(keyword))
                                result += (client.ToString() + "\n\nСписок пропозицiй:\n" + property.ToString());
                            // добавить к результату Клиента и найденные по keyword предложения
                        }
                    }
                }
                return result;
            }
        }
        [ExcludeFromCodeCoverage]
        internal void Save()
        {
            Serializator ser = new Serializator(); // получаем объект сериализатора
            ser.SaveData("Clients.dat", this.clients); // сериализуем объект(список) в файл.
        }
        [ExcludeFromCodeCoverage]
        internal void Load()
        {
            Serializator ser = new Serializator(); // получаем объект сериализатора
            object loadedObj = ser.LoadData("Clients.dat"); // десериализуем через него данные в объект loadedObj

            this.clients = (List<Client>)loadedObj;
            // изначально была сериализация объекта(списка) типа List<Client>, 
            // поэтому явно приводим loadedObj к этому типу. 
            // Получается список Клиентов, десериализованный с файла.
        }
    }
}