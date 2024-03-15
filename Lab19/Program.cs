using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Lab19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>
            {
            new Computer { Code = "PC1", Brand = "Brand1", ProcessorType = "Intel", ProcessorFrequency = 3.2, RAMSize = 8, HDDSize = 1000, GPUSize = 4, Price = 1000, Quantity = 20 },
            new Computer { Code = "PC2", Brand = "Brand2", ProcessorType = "AMD", ProcessorFrequency = 3.5, RAMSize = 16, HDDSize = 2000, GPUSize = 6, Price = 1200, Quantity = 25 },
            new Computer { Code = "PC3", Brand = "Brand3", ProcessorType = "Intel", ProcessorFrequency = 2.8, RAMSize = 32, HDDSize = 1500, GPUSize = 8, Price = 1500, Quantity = 15 },
            new Computer { Code = "PC4", Brand = "Brand4", ProcessorType = "AMD", ProcessorFrequency = 3.3, RAMSize = 64, HDDSize = 2000, GPUSize = 10, Price = 2300, Quantity = 25 },
            new Computer { Code = "PC5", Brand = "Brand5", ProcessorType = "AMD", ProcessorFrequency = 2.3, RAMSize = 32, HDDSize = 500, GPUSize = 12, Price = 1000, Quantity = 20 },
            new Computer { Code = "PC6", Brand = "Brand6", ProcessorType = "Intel", ProcessorFrequency = 2.4, RAMSize = 16, HDDSize = 1500, GPUSize = 6, Price = 900, Quantity = 15 },
            new Computer { Code = "PC7", Brand = "Brand7", ProcessorType = "Intel", ProcessorFrequency = 2.5, RAMSize = 8, HDDSize = 1000, GPUSize = 4, Price = 800, Quantity = 30 },
            };

            Console.WriteLine("Введите тип процессора:");
            string processorType = Console.ReadLine();
            List<Computer> computer1 = computers.Where(x => x.ProcessorType == processorType).ToList();
            Print(computer1);

            Console.WriteLine("Введите минимальный объем ОЗУ:");
            int minRAMSize = Convert.ToInt32(Console.ReadLine());
            List<Computer> computer2 = computers.Where(x => x.RAMSize >= minRAMSize).ToList();
            Print(computer2);


            List<Computer> computer3 = computers.OrderBy(x => x.Price).ToList();
            Print(computer3);

            List<Computer> computer4 = computers.OrderBy(x => x.ProcessorType).ToList();
            Print(computer4);

            IEnumerable<IGrouping<string, Computer>> computer5 = computers.GroupBy(x => x.ProcessorType);
            foreach (IGrouping<string, Computer> gr in computer5)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer с in gr)
                {
                    Console.WriteLine($"{с.Code} {с.Brand} {с.ProcessorType} {с.ProcessorFrequency} {с.RAMSize} {с.HDDSize} {с.GPUSize} {с.Price} {с.Quantity}");
                }
            }

            Computer computer6 = computers.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine($"Самый дорогой компьютер: Code: {computer6.Code} {computer6.Brand} {computer6.ProcessorType} {computer6.ProcessorFrequency} {computer6.RAMSize} {computer6.HDDSize} {computer6.GPUSize} {computer6.Price} {computer6.Quantity}");

            Computer computer7 = computers.OrderBy(x => x.Price).FirstOrDefault();
            Console.WriteLine($"Самый бюджетный компьютер: Code: {computer7.Code} {computer7.Brand} {computer7.ProcessorType} {computer7.ProcessorFrequency} {computer7.RAMSize} {computer7.HDDSize} {computer7.GPUSize} {computer7.Price} {computer7.Quantity}");

            Console.WriteLine(computers.Any(x => x.Quantity >= 30));

            Console.ReadKey();
        }
        static void Print(List<Computer> computers)
        {
            foreach (Computer с in computers)
            {
                Console.WriteLine($"{с.Code} {с.Brand} {с.ProcessorType} {с.ProcessorFrequency} {с.RAMSize} {с.HDDSize} {с.GPUSize} {с.Price} {с.Quantity}");
            }
            Console.WriteLine();
        }
    }
}
