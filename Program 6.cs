using System.Collections.Concurrent;
using System.Collections.Generic;
using System;


using System.Collections.Concurrent;
using System.Collections.Generic;
using System;



namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var market = new Market();
            market.StartMarket();
        }
    }

    public class Market
    {
        private List<Product> _products;
        private ConcurrentQueue<Customer> _customersQueue;
        private List<string> _uniqueNames;

        public Market()
        {
            _products = new List<Product>
            {
                new Product("Творог", 180),
                new Product("Вода", 65),
                new Product("Колбаса", 320),
                new Product("Белый Хлеб", 30)
            };

            _customersQueue = new ConcurrentQueue<Customer>();

            _uniqueNames = new List<string> { "Андрей", "Мария", "Илья", "Елена", "Генадий", "Светлана" };
        }

        public void StartMarket()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Добро пожаловать в магазин! ");
            Console.WriteLine("Нажмите (space) чтобы продолжить...");
            Console.WriteLine(" ");
            InitializeCustomers();
            ProcessCustomers();
        }

        private void InitializeCustomers()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (_uniqueNames.Count > 0)
                {
                    var random = new Random();
                    var nameIndex = random.Next(_uniqueNames.Count);
                    var name = _uniqueNames[nameIndex];

                    _uniqueNames.RemoveAt(nameIndex);

                    _customersQueue.Enqueue(new Customer(i, name, _products));
                }
            }
        }

        private void ProcessCustomers()
        {
            while (!_customersQueue.IsEmpty)
            {
                DisplayCustomers();

                ConsoleKeyInfo keyInfo = GetUserInput();

                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    ServeFirstCustomer();
                }
                else
                {
                    Console.WriteLine("Неправильный ввод. Попробуйте еще раз.");
                }
            }
        }

        private void DisplayCustomers()
        {
            Console.WriteLine("\nПокупатели в очереди:");
            foreach (var customer in _customersQueue)
            {
                Console.WriteLine($"{customer.ID}. {customer.Name}");
            }
        }

        private ConsoleKeyInfo GetUserInput()
        {
            return Console.ReadKey(true);
        }

        private void ServeFirstCustomer()
        {
            if (_customersQueue.TryDequeue(out var customer))
            {
                var product = ChooseProduct(customer);
                customer.BuyProducts(product);
            }
        }

        private Product ChooseProduct(Customer customer)
        {
            Console.WriteLine($"\nВыберите продукт для покупателя {customer.Name}:");
            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_products[i].Name} - {_products[i].Price} руб");
            }

            int choice;
            do
            {
                Console.Write("Введите номер продукта: ");
            }

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > _products.Count);



            return _products[choice - 1];


        }
    }

    public class Customer
    {
        private int _id;
        private string _name;
        private decimal _money;
        private readonly List<Product> _products;

        public int ID => _id;
        public string Name => _name;
        public decimal Money => _money;

        public Customer(int id, string name, List<Product> products)
        {
            _name = name;
            _money = new Random().Next(100, 1001);
            _products = products;
        }
        public void BuyProducts(Product product)
        {
            int quantity = Math.Min((int)(_money / product.Price), 10);
            decimal totalCost = quantity * product.Price;


            Console.WriteLine($"{_name} (№{_id}) купил {quantity} {product.Name}(-ов) на сумму {totalCost} рублей.");
            _money -= totalCost;
            Console.WriteLine($"У {_name} (№{_id}) осталось {_money} руб.\n");
        }
    }

    public class Product
    {
        private string _name;
        private decimal _price;

        public string Name => _name;
        public decimal Price => _price;

        public Product(string name, decimal price)
        {
            _name = name;
            _price = price;
        }
    }
}