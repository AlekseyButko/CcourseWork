using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    [Serializable]
    public class Client
    {
        public Client(string name, string surname, int accountNumber)
        {
            this.name = name;
            this.surname = surname;
            this.accountNumber = accountNumber;
            this.propertyOffers = new List<Property>();
        }

        public Client()
        {
        }

        private string name;
        private string surname;
        private int accountNumber;
        private List<Property> propertyOffers; // список Предложений для этого Клиента
        public string Name
        {
            get { return this.name; }
        }
        public string Surname
        {
            get { return this.surname; }
        }
        public int AccountNumber
        {
            get { return this.accountNumber; }
        }
        public Property[] GetOffersList()
        {
            // возвращение массива-копии списка.
            // таким образом будет невозможно несанкционированно изменять сам список из любого места программы.
            return propertyOffers.ToArray();
        }
        // 3.1. Добавление предложения Недвижимости
        
        public void AddOffer(int propertyID, PropertyManagement pm)
        {
            Property foundOffer = propertyOffers.Find(prop => prop.ID == propertyID); // поиск предложения Недвижимости в списке этого Клиента
            if (foundOffer != null) // если такое предложение уже есть, то кинуть исключение.
                throw new Exception("Пропозицiя з ID нерухомостi " + propertyID + " уже наявна у списку!" );
            // если такого нету, то продолжить.
            Property property = pm.GetProperty(propertyID); // получить Недвижимость по ID
            if (propertyOffers.Count < 5) // если к-во предложений в списке этого Клиента < 5
                propertyOffers.Add(property); // то добавить эту Недвижимость в список предложений.
        }
        // 3.3. Удаление предложения Недвижимости
        [ExcludeFromCodeCoverage]
        public void RemoveOffer(int propertyID)
        {
            Property foundOffer = propertyOffers.Find(prop => prop.ID == propertyID); // поиск предложения Недвижимости в списке этого Клиента
            if (foundOffer != null) // если такого предложения в списке нет, то кинуть исключение.
                throw new Exception("Пропозицiї з ID нерухомостi " + propertyID + " не знайдено.");
            else
                propertyOffers.Remove(foundOffer); // если есть, то удалить его из списка.
        }
        
        public void SetName(string newName)
        {
            this.name = newName;
        }
        
        public void SetSurname(string newSurname)
        {
            this.surname = newSurname;
        }
      
        public void SetAccountNumber(int newAccountNumber)
        {
            this.accountNumber = newAccountNumber;
        }

        public override string ToString()
        {
            return
                "Iм'я:           " + this.name + "\n" +
                "Прiзвище:       " + this.surname + "\n" +
                "Номер рахунку:  " + this.accountNumber;
        }
    }
}

