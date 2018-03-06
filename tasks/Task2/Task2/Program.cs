using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Car
    {
        private decimal Price;
        public string Make;
        public string Model;

        public Car (string make, string model, decimal price)
        {
            if (string.IsNullOrWhiteSpace(make)) throw new ArgumentException("Make must not be empty.", nameof(make));
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Model must not be empty.", nameof(model));
            Make = make;
            Model = model;
            newPrice(price);
        }

        public string getMake() => Make;
        public string getModel() => Model;
        public decimal getPrice() { return Price; }



        public void newPrice(decimal price)
        {
            if (price < 0) throw new ArgumentException("Price must not be negative.", nameof(price));
            Price = price;
        }
    }
    class Programm
    {
        static void Main(string[] args)
        {
            try
            {
                Car a = new Car("Mazda", "Drei", 20000);
                Car b = new Car("Audi", "A4", 30000);
                Console.WriteLine($"Auto: { a.getMake()} {a.getModel()} {a.getPrice()}");
                Console.WriteLine($"Auto: { b.getMake()} {b.getModel()} {b.getPrice()}");
                a.newPrice(15555);
                Console.WriteLine($"Auto: { a.getMake()} {a.getModel()} {a.getPrice()}");
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error({ error.Message})");
            }
        }

    }

}
