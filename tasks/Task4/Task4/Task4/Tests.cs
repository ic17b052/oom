using System;
using NUnit.Framework;
using Task4;

//Task4.2

namespace Task4
{
    [TestFixture]
    public class Tests
    {
        [Test]
         public void CanCreateMercedes()
        {
              var x  = new Mercedes("Mercedes", "CLA", 40000);
              Assert.IsTrue(x.Make == "Mercedes");
              Assert.IsTrue(x.Model == "CLA");
              Assert.IsTrue(x.Price == 40000);
         }

        [Test]
        public void CanCreateAudi()
        {
            var x = new Audi("Audi", "R8", "Roadster") ;
            Assert.IsTrue(x.Make == "Audi");
            Assert.IsTrue(x.Model == "R8");
            Assert.IsTrue(x.CarBodyDesign == "Roadster");
        }

        [Test]
        public void CannotCreateNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new Mercedes("Mercedes", "CLA", -40000);
            });
        }
        [Test]
        public void CannotCreateWithoutMake1()
        {
            Assert.Catch(() =>
            {
                var x = new Audi(null, "CLA", "Roadster");
            });
        }
        [Test]
        public void CannotCreateWithoutMake2()
        {
            Assert.Catch(() =>
            {
                var x = new Audi("", "CLA", "Roadster");
            });
        }
        [Test]
        public void CanUpdateMercedesPrice()
        {
            var x = new Mercedes("Mercedes", "CLA", 40000);
            Assert.IsTrue(x.Price == 40000);
            x.newPrice(70000);
            Assert.IsTrue(x.Price == 70000);
        }
        [Test]
        public void CannotUpdateNegativeMercedesPrice()
        {
            Assert.Catch(() =>
            {
                var x = new Mercedes("Mercedes", "CLA", 40000);
                x.newPrice(-70000);
            });
        }
        [Test]
        public void CannotCreateWithoutModel1()
        {
            Assert.Catch(() =>
            {
                var x = new Audi("Audi", null, "Roadster");
            });
        }
        [Test]
        public void CannotCreateWithoutModel2()
        {
            Assert.Catch(() =>
            {
                var x = new Audi("Audi","", "Roadster");
            });
        }
    }
}
