using SystemSecurityModel;
using System.Collections.Generic;

namespace SystemSecurityService
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Customer> Customers { get; set; }

        public List<Element> Elements { get; set; }

        public List<Executor> Executors { get; set; }

        public List<Order> Orders { get; set; }

        public List<Systemm> Systemms { get; set; }

        public List<ElementRequirement> ElementRequirements { get; set; }

        public List<Storage> Storages { get; set; }

        public List<ElementStorage> ElementStorages { get; set; }

        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Elements = new List<Element>();
            Executors = new List<Executor>();
            Orders = new List<Order>();
            Systemms = new List<Systemm>();
            ElementRequirements = new List<ElementRequirement>();
            Storages = new List<Storage>();
            ElementStorages = new List<ElementStorage>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }

            return instance;
        }
    }
}