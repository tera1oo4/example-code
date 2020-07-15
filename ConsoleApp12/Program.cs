using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;


namespace collection
{
    public class Program
    {
        // обьявление списка обьектов payments
        public static List<Payment> payments = new List<Payment>();

        // Инициализация списка
        static void Init()
        {
            payments.AddRange(new Payment[]
           {new Payment(1, new DateTime(2019, 3, 9, 9, 23, 31), 92, 5.12, 001),
            new Payment(4, new DateTime(2019, 3, 9, 9, 42, 21), 92, 12.93, 002),
            new Payment(1, new DateTime(2019, 3, 9, 10, 1, 23), 95, 40.93, 003),
            new Payment(3, new DateTime(2019, 3, 9, 10, 32, 01), 95, 20.00, 004),
            new Payment(3, new DateTime(2019, 3, 9, 11, 42, 45), 92, 4.976, 005),
            new Payment(4, new DateTime(2019, 3, 9, 12, 12, 58), 92, 10.21, 006),
            new Payment(2, new DateTime(2019, 3, 9, 13, 15, 01), 80, 34, 007),
            new Payment(2, new DateTime(2019, 3, 9, 14, 22, 51), 92, 2.21, 008),
            new Payment(1, new DateTime(2019, 3, 9, 15, 03, 21), 95, 7.24, 009),
            new Payment(5, new DateTime(2019, 3, 9, 16, 54, 24), 92, 9.24, 010),
            new Payment(4, new DateTime(2019, 3, 9, 17, 02, 56), 80, 18.95, 011),
            new Payment(2, new DateTime(2019, 3, 9, 18, 24, 01), 92, 15.93, 012) });
        }
        // Метод, который удаляет платеж по заданному пользователем времени
        public static void ClearPayment()
        {
            Console.Write("Введите промежуток времени в часах от : ");
            int timestart = int.Parse(Console.ReadLine());
            Console.Write("\n и до ");
            int timeend = int.Parse(Console.ReadLine());
            payments.RemoveAll(p => p.Time.Hour > timestart - 1 && p.Time.Hour < timeend - 1);
            Console.Write("\n Указанные платежи удалены. \n\n");
                      
        }
        //Метод добавления нового элемента(платежа) в список
        public static Payment ReadPayment()
        {
            Console.Write("Введите марку бензина: ");
            int another_petrol = int.Parse(Console.ReadLine());
            Console.Write("Введите количество бензина в литрах: ");
            double another_volume = double.Parse(Console.ReadLine());
            Console.Write("Введите номер колонки: ");
            byte another_gasStation = byte.Parse(Console.ReadLine());
            Console.Write("Введите дату в формате dd.mm.yyyy  h:m:sec : ");
            DateTime another_time = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите код: ");
            byte another_id = byte.Parse(Console.ReadLine());

            return
                new Payment(another_gasStation, another_time, another_petrol, another_volume, another_id);

        }
        // Поиск платежа по заданному пользователем времени
        public static void Search()
        {
            Console.Write("Введите промежуток времени в часах от : ");
            int timestart = int.Parse(Console.ReadLine());
            Console.Write("\n и до ");
            int timeend = int.Parse(Console.ReadLine());
            foreach (Payment C in payments.FindAll(p => p.Time.Hour > timestart - 1 && p.Time.Hour < timeend - 1))
            {
                Console.WriteLine("\n Колонка: {0} \n" +
               "Дата:  {1}.{2}.{3} {4}:{5}:{6} \n" +
               "Марка бензина: {7} \n" +
               "Количество: {8} \n" +
               "Код платежа: {9}" +
               "\n===============================", C.GasStation, C.Time.Year, C.Time.Month, C.Time.Day, C.Time.Hour, C.Time.Minute, C.Time.Second, C.Petrol, C.Volume, C.Id);

            }

        }
        // Вывод в консоль всех доступных платежей
        public static void Show()
        {
            foreach (Payment item in payments)
            {
                Console.WriteLine($"Gas station={item.GasStation} | Date={item.Time} | Petrol={item.Petrol} | Volume={item.Volume} | Id={item.Id}");
            }
        }
        //Сохранение списка в CSV формате
        public static void Save()
        {
            File.WriteAllText("paymentsCSV.csv", SeriaLize());
        }
        //Выгрузка из файла всех доступных элементов
        public static void Load()
        {
            payments.Clear();
            foreach (string item in File.ReadAllLines("station.csv"))
            {
                string[] info = item.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                payments.Add(new Payment(byte.Parse(info[0]), DateTime.Parse(info[1]), int.Parse(info[2]), float.Parse(info[3]), byte.Parse(info[4])));
            }
        }
        //Сериализация
        public static string SeriaLize()
        {
            StringBuilder result = new StringBuilder();
            foreach (Payment item in payments)
            {
                result.AppendFormat("{0}|{1}|{2}|{3}|{4} \n", item.GasStation, item.Time, item.Petrol, item.Volume, item.Id);
            }

            return result.ToString();
        }
        // Метод меню, в котором вызываются методы для работы со списком
        public static void Menu()
            {
                bool right = false;
                while (!right)
                {
                    Console.Clear();
                    Console.WriteLine("1. История платежей");
                    Console.WriteLine("2. Добавить новый платеж");
                    Console.WriteLine("3. Удалить платеж из списка");
                    Console.WriteLine("4. Поиск платежа по времени");
                    Console.WriteLine("0. Выход из программы");
                    Console.Write("\n \nВведите номер пункта меню: ");
                    char choice = char.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case '1':
                            {
                             Show();
                             break;
                            }
                        case '2':
                            {
                                payments.Add(ReadPayment());
                                break;
                            }
                        case '3':
                            {
                             Load();
                             ClearPayment();
                             Save();
                             break;
                            }
                        case '4':
                            Search();
                            break;
                        case '0': right = true; break;
                    }
                // Ожидание нажатия любой клавиши для продолжения работы
                    if (!right)
                    {
                        Console.WriteLine("Нажмите на любую клавишу для возврата в меню");
                        Console.ReadKey(true);
                    }
                }
            }
        // Метод Main() является входной точкой работы программы
        public static void Main()
            {
                Init();
                Save();
                Load();
                Menu();
            }        
        }
    } 

