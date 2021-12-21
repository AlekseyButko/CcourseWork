using Business_Logic_Layer;
using System;
namespace Kursovaya
{
    class Menu
    {
        private static ClientManagement CM; // объекты управления
        private static PropertyManagement PM;
        public static void Start()
        {
            CM = new ClientManagement();
            PM = new PropertyManagement();
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                                   "\t**********   Головне Меню   **********\n" +
                    "---------- Оберiть роздiл: ----------\n" +
                    "- 1) Управлiння системою\n" +
                    "- 2) Управлiння клiєнтом\n" +
                    "- 0) Вийти з програми\n"
                    );
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1": ManagementAsSystem(); break;
                        case "2": ManagementAsClient(); break;
                        case "0": isRunning = false; break;
                        default: throw new Exception();
                    }
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.WriteLine("\nНеправильне введення!\n");
                    Console.ReadKey();
                }
            }
        }
        private static void ManagementAsSystem()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "\t[Управлiння системою]\n" +
                    "Оберiть роздiл.\n" +
                    "-1) Управлiння клiєнтами\n" +
                    "-2) Управлiння даними про нерухомiсть\n" +
                    "-3) Управлiння пропозицiями клiєнтам\n" +
                    "-4) Пошук\n" +
                    "-0) Назад\n"
                    );
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1": Sys_ClientManagement(); break;
                        case "2": Sys_PropertyManagement(); break;
                        case "3": Sys_OffersManagement(); break;
                        case "4": Sys_Search(); break;
                        case "0": return;
                        default: throw new Exception();
                    }
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.WriteLine("\nНеправильне введення!\n");
                    Console.ReadKey();
                }
            }
        }
        private static void ManagementAsClient()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "\t---------- Управлiння клiєнтом ----------\n" +
                    "Укажiть номер клiєнта.\n"
                    );
                string number = Console.ReadLine();
                int accountNumber = -1;
                Client client = null;
                try
                {
                    accountNumber = int.Parse(number);
                    client = CM.GetClient(accountNumber);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    return;
                }
                Console.Clear();
                Console.WriteLine("Клiєнт: " + client.AccountNumber + "\n");
                Console.WriteLine(
                    "Вкажiть дiю:\n" +
                    "-1) Переглянути данi про нерухомiсть\n" +
                    "-2) Переглянути данi усiх нерухомостей\n" +
                    "-3) Перевiрити доступнiсть об'єкта нерухомостi\n" +
                    "-4) Переглянути список пропозицiй\n" +
                    "-5) Вiдхилити пропозицiю\n" +
                    "-0) Назад\n"
                    );
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1": Sys_PM_ShowProperty(); break;
                        case "2": Sys_PM_ShowAllProperties(); break;
                        case "3": CheckPropertyAvailability(); break;
                        case "4": Client_ShowOffers(client); break;
                        case "5": Client_RejectOffer(client); break;
                        case "0": return;
                        default: throw new Exception();
                    }
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.WriteLine("\nНеправильне введення!\n");
                    Console.ReadKey();
                }
            }
        }
        private static void Sys_ClientManagement()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "\t---------- Управлiння клiєнтами ----------\n" +
                    "Оберiть дiю: \n" +
                    "-1) Додати клiєнта\n" +
                    "-2) Видалити клiєнта\n" +
                    "-3) Змiнити данi клiєнта\n" +
                    "-4) Переглянути данi клiєнта\n" +
                    "-5) Переглянути данi усiх клiєнтiв\n" +
                    "-0) Назад\n"
                    );
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1": Sys_CM_AddClient(); break;
                        case "2": Sys_CM_RemoveClient(); break;
                        case "3": Sys_CM_ChangeClient(); break;
                        case "4": Sys_CM_ShowClient(); break;
                        case "5": Sys_CM_ShowAllClients(); break;
                        case "0": return;
                        default: throw new Exception();
                    }
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.WriteLine("\nНеправильне введення!\n");
                    Console.ReadKey();
                }
            }
        }
        private static void Sys_PropertyManagement()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "\t----------Управлiння клiєнтами----------\n" +
                    "Оберiть дiю.\n" +
                    "-1) Додати нерухомiсть\n" +
                    "-2) Видалити нерухомiсть\n" +
                    "-3) Змiнити данi нерухомостi\n" +
                    "-4) Переглянути данi про нерухомiсть\n" +
                    "-5) Переглянути данi усiх нерухомостей\n" +
                    "-0) Назад\n"
                    );
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1": Sys_PM_AddProperty(); break;
                        case "2": Sys_PM_RemoveProperty(); break;
                        case "3": Sys_PM_ChangeProperty(); break;
                        case "4": Sys_PM_ShowProperty(); break;
                        case "5": Sys_PM_ShowAllProperties(); break;
                        case "0": return;
                        default: throw new Exception();
                    }
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.WriteLine("\nНеправильне введення!\n");
                    Console.ReadKey();
                }
            }
        }
        private static void Sys_OffersManagement()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "\t---------- Управлiння пропозицiями ----------\n" +
                    "Оберiть дiю:\n" +
                    "-1) Додати пропозицiю клiєнтовi\n" +
                    "-0) Назад\n"
                    );
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1": Sys_OM_AddOfferToClient(); break;
                        case "0": return;
                        default: throw new Exception();
                    }
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.WriteLine("\nНеправильне введення!\n");
                    Console.ReadKey();
                }
            }
        }
        private static void Sys_Search()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "\t---------- Пошук ----------\n" +
                    "Оберiть дiю:\n" +
                    "-1) Пошук серед клiєнтiв\n" +
                    "-2) Пошук серед нерухомостей\n" +
                    "-3) Пошук серед клiєнтiв та нерухомостей\n" +
                    "-4) Розширений пошук серед клiєнтiв та пропозицiй\n" +
                    "-0) Назад\n"
                    );
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1": Sys_Search_Clients(); break;
                        case "2": Sys_Search_Propetries(); break;
                        case "3": Sys_Search_ClientsAndPropetries(); break;
                        case "4": Sys_Search_Extended(); break;
                        case "0": return;
                            //default: throw new Exception();
                    }
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.WriteLine("\nНеправильне введення!\n");
                    Console.ReadKey();
                }
            }
        }
        private static void Sys_CM_AddClient()
        {
            Console.Clear();
            Console.Write("Iм'я клiєнта: ");
            string name = Console.ReadLine();
            Console.Write("Прiзвище клiєнта: ");
            string surname = Console.ReadLine();
            CM.AddClient(name, surname);
            Console.WriteLine("Клiєнта додано.");
        }
        private static void Sys_CM_RemoveClient()
        {
            Console.Clear();
            Console.Write("Номер клiєнта: ");
            int number = -1;
            try
            {
                number = int.Parse(Console.ReadLine());
                CM.DeleteClient(number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Клiєнта " + number + " видалено.");
        }
        private static void Sys_CM_ChangeClient()
        {
            Console.Clear();
            Console.Write("Номер клiєнта: ");
            int number = -1;
            try
            {
                number = int.Parse(Console.ReadLine());
                Console.Write("Нове iм'я клiєнта: ");
                string name = Console.ReadLine();
                Console.Write("Нове прiзвище клiєнта: ");
                string surname = Console.ReadLine();
                CM.ChangeClientInfo(number, name, surname);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Данi клiєнта " + number + " змiнено.");
        }
        private static void Sys_CM_ShowClient()
        {
            Console.Clear();
            Console.Write("Номер клiєнта: ");
            int number = -1;
            try
            {
                number = int.Parse(Console.ReadLine());
                string info = CM.GetClientInfo(number);
                Console.WriteLine(info + "\n\nНатиснiть клавiшу...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void Sys_CM_ShowAllClients()
        {
            ClientManagement.SortingParameter param;
            string type = "";
            Console.WriteLine(
                "Вкажiть порядок сортування:\n" +
                "-1) За iменем\n" +
                "-2) За прiзвищем\n" +
                "-3) За номером\n"
                );
            switch (Console.ReadLine())
            {
                case "1": param = ClientManagement.SortingParameter.Name; type = "за iменем:"; break;
                case "2": param = ClientManagement.SortingParameter.Surname; type = "за прiзвищем:"; break;
                case "3": param = ClientManagement.SortingParameter.Number; type = "за номером:"; break;
                default: throw new Exception();
            }
            Console.Clear();
            Console.WriteLine("Усi клiєнти, " + type + "\n");
            string info = CM.GetAllClientsSortedInfo(param);
            Console.WriteLine(info + "\n\n");
        }
        private static void Sys_PM_AddProperty()
        {
            Console.Clear();
            Console.WriteLine(
                "Вкажiть тип нерухомостi:\n" +
                "-1) Замiський  будинок\n" +
                "-2) 1-кiмнатна квартира\n" +
                "-3) 2-кiмнатна квартира\n" +
                "-4) 3-кiмнатна квартира\n"
                );
            Property.PropertyType type;
            switch (Console.ReadLine())
            {
                case "1": type = Property.PropertyType.CountryHouse; break;
                case "2": type = Property.PropertyType.OneRoomApartment; break;
                case "3": type = Property.PropertyType.TwoRoomApartment; break;
                case "4": type = Property.PropertyType.ThreeRoomApartment; break;
                default: throw new Exception();
            }
            Console.Write("\nЦiна нерухомостi: ");
            int cost = int.Parse(Console.ReadLine());
            PM.AddProperty(type, cost);
            Console.WriteLine("Нерухомiсть додано.");
        }
        private static void Sys_PM_RemoveProperty()
        {
            Console.Clear();
            Console.Write("ID нерухомостi: ");
            int ID = -1;
            try
            {
                ID = int.Parse(Console.ReadLine());
                PM.DeleteProperty(ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Нерухомiсть з ID " + ID + " видалено.");
        }
        private static void Sys_PM_ChangeProperty()
        {
            Console.Clear();
            Console.Write("ID нерухомостi: ");
            int ID = int.Parse(Console.ReadLine());
            Console.WriteLine(
                "\nВкажiть новий тип нерухомостi:\n" +
                "-1) Замiський  будинок\n" +
                "-2) 1-кiмнатна квартира\n" +
                "-3) 2-кiмнатна квартира\n" +
                "-4) 3-кiмнатна квартира\n"
                );
            Property.PropertyType type;
            switch (Console.ReadLine())
            {
                case "1": type = Property.PropertyType.CountryHouse; break;
                case "2": type = Property.PropertyType.OneRoomApartment; break;
                case "3": type = Property.PropertyType.TwoRoomApartment; break;
                case "4": type = Property.PropertyType.ThreeRoomApartment; break;
                default: throw new Exception();
            }
            Console.Write("\nНова цiна нерухомостi: ");
            int cost = int.Parse(Console.ReadLine());
            PM.AddProperty(type, cost);
            Console.WriteLine("Нерухомiсть з ID " + ID + " змiнено.");
        }
        private static void Sys_PM_ShowProperty()
        {
            Console.Clear();
            Console.Write("ID нерухомостi: ");
            int ID = int.Parse(Console.ReadLine());
            string info = PM.GetPropertyInfo(ID);
            Console.WriteLine(info + "\n\nНатиснiть клавiшу...");
        }
        private static void Sys_PM_ShowAllProperties()
        {
            PropertyManagement.SortingParameter param;
            string type = "";
            Console.WriteLine(
                "Вкажiть порядок сортування:\n" +
                
                "1) За номером\n"
                );
            switch (Console.ReadLine())
            {
                case "1": param = PropertyManagement.SortingParameter.Type; type = "за типом:"; break;
                case "2": param = PropertyManagement.SortingParameter.Cost; type = "за цiною:"; break;
                case "3": param = PropertyManagement.SortingParameter.ID; type = "за номером:"; break;
                default: throw new Exception();
            }
            Console.Clear();
            Console.WriteLine("Усi нерухомостi, " + type + "\n");
            string info = PM.GetAllPropertiesSortedInfo(param);
            Console.WriteLine(info + "\n\n");
        }
        private static void Sys_OM_AddOfferToClient()
        {
            Console.Clear();
            Console.Write("Номер клiєнта: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("ID нерухомостi: ");
            int ID = int.Parse(Console.ReadLine());
            CM.AddOffer(number, ID, PM);
            Console.WriteLine("Нерухомiсть з ID " + ID + " додана до пропозицiй клiєнта " + number + ".");
        }
        private static void Sys_Search_Clients(bool b = true)
        {
            Console.Write("Введiть ключове слово: ");
            string keyword = Console.ReadLine();
            string info = CM.Search(keyword, true);
            Console.WriteLine(info + "\n\n");
            if (!b)
            {
                info = PM.Search(keyword);
                Console.WriteLine(info + "\n\n");
            }
            Console.WriteLine("Натиснiть клавiшу...");
        }
        private static void Sys_Search_Propetries()
        {
            Console.Write("Введiть ключове слово: ");
            string keyword = Console.ReadLine();
            string info = PM.Search(keyword);
            Console.WriteLine(info + "\n\nНатиснiть клавiшу...");
        }
        private static void Sys_Search_ClientsAndPropetries()
        {
            Sys_Search_Clients(false);
        }
        private static void Sys_Search_Extended()
        {
            Console.Write("Введiть ключове слово: ");
            string keyword = Console.ReadLine();
            string info = CM.Search(keyword, true);
            Console.WriteLine(info + "\n\nНатиснiть клавiшу...");
        }
        private static void CheckPropertyAvailability()
        {
            Console.Clear();
            Console.WriteLine(
                "\t---------- Пошук за параметрами ----------\n" +
                "Вкажiть тип нерухомостi: \n" +
                "-1) Замiський  будинок\n" +
                "-2) 1-кiмнатна квартира\n" +
                "-3) 2-кiмнатна квартира\n" +
                "-4) 3-кiмнатна квартира\n"
                );
            Property.PropertyType type;
            switch (Console.ReadLine())
            {
                case "1": type = Property.PropertyType.CountryHouse; break;
                case "2": type = Property.PropertyType.OneRoomApartment; break;
                case "3": type = Property.PropertyType.TwoRoomApartment; break;
                case "4": type = Property.PropertyType.ThreeRoomApartment; break;
                default: throw new Exception();
            }
            Console.Write("\nЦiна нерухомостi: ");
            int cost = int.Parse(Console.ReadLine());
            PM.GetPropertiesBy(type, cost);
        }
        private static void Client_ShowOffers(Client client)
        {
            Console.Clear();
            Console.WriteLine("Клiєнт: " + client.AccountNumber);
            Console.WriteLine("Список пропозицiй:\n");
            foreach (Property p in client.GetOffersList())
                Console.WriteLine(p.ToString() + "\n");
            Console.WriteLine("\nНатиснiть клавiшу...");
        }
        private static void Client_RejectOffer(Client client)
        {
            Console.Clear();
            Console.WriteLine("Клiєнт: " + client.AccountNumber);
            Console.Write("ID нерухомостi для вiдмови: ");
            int ID = int.Parse(Console.ReadLine());
            client.RemoveOffer(ID);
            Console.WriteLine("Нерухомiсть з ID " + ID + " видалена зi списку пропозицiй клiєнта " + client.AccountNumber + ".");
        }
    }
}
