using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Globalization;
using Newtonsoft.Json;

namespace Task4
{

    interface Car //Task 3.1
    {
        void Print();
    }
    public class Mercedes : Car //Task 3.2
    {
        public string Make;
        public string Model;
        public decimal Price;

        public Mercedes(string make, string model, decimal price)
        {
            if (string.IsNullOrWhiteSpace(make)) throw new ArgumentException("Model must not be empty.", nameof(make));
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Model must not be empty.", nameof(model));
            if (price <= 0) throw new ArgumentException("Wrong Price", nameof(price));
            Make = make;
            Model = model;
            newPrice(price);
        }

        public string GetMake => Make;
        public string GetModel => Model;
        public decimal GetPrice => Price;
        public void newPrice(decimal price)
        {
            if (price < 0) throw new ArgumentException("Price must not be negative.", nameof(price));
            Price = price;
        }
        public void Print()
        {
            Console.WriteLine($"Dies ist ein:  { GetMake } - {GetModel} um {GetPrice} Euro");
        }
    }

    class Audi : Car //Task 3.3
    {
        public string Make;
        public string Model;
        public string CarBodyDesign;

        public Audi(string make, string model, string carbodydesign)
        {
            if (string.IsNullOrWhiteSpace(make)) throw new ArgumentException("Model must not be empty.", nameof(make));
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Model must not be empty.", nameof(model));
            if (string.IsNullOrWhiteSpace(carbodydesign)) throw new ArgumentException("Model must not be empty.", nameof(carbodydesign));
            Make = make;
            Model = model;
            CarBodyDesign = carbodydesign;

        }

        public string GetMake => Make;
        public string GetModel => Model;
        public string GetCarBodyDesign => CarBodyDesign;

        public void Print()
        {
            Console.WriteLine($"Dies ist ein:  { GetMake } - {GetModel} - {GetCarBodyDesign}");
        }
    }
    class Programm
    {
        static void Main(string[] args)
        {
            try
            {
                Mercedes a = new Mercedes("Mercedes", "CLA", 40000);
                a.Print();
                a.newPrice(15555);
                Mercedes b = new Mercedes("Mercedes", "Vito", 54587);
                Audi c = new Audi("Audi", "A4", "Shooting Brake");
                Audi d = new Audi("Audi", "R8", "Roadster");
                Car[] CarArray = { a, b, new Mercedes("Mercedes", "A180", 16734), c, d, new Audi("TestAudi", "TestModel", "TestCarBodyDesign") }; //Task 3.4.1

                foreach (Car Car in CarArray) //Task 3.4.2
                {
                    Car.Print();
                }
                
                var jsonsettings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto }; //Task 4.3
                var json = JsonConvert.SerializeObject(CarArray, jsonsettings);
                Console.WriteLine(json);
                                
                var itemsfromjson = JsonConvert.DeserializeObject<Car[]>(json, jsonsettings); //Task 4.3
                foreach (var Actuator in itemsfromjson)
                {
                    Actuator.Print();
                }
                
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error({ error.Message})");
            }
        }

    }

}
