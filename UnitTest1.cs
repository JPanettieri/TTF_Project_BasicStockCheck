using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Binary_Price_Search_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var lines = File.ReadAllLines("TTFproducts.csv");
            lines = lines.Skip(1).ToArray();
            var list = new List<Product>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length == 3)
                {
                    var product = new Product()
                    {
                        Id = int.Parse(values[0]),
                        ProductName = values[1],
                        Price = double.Parse(values[2])
                    };
                    list.Add(product);
                    list.Sort((x, y) => x.Price.CompareTo(y.Price));
                }
            }
            //Find the centre of the list and start searching, depending on its value
            var min = 0;
            var max = list.Count - 1;
            var mid = (max - min) / 2;
            double searchPrice = double.Parse("5.49");
            while (list[mid].Price < searchPrice)
            {
                if (mid < max)
                {
                    mid += 1;
                }
                else break;
            }
            while (list[mid].Price > searchPrice)
            {
                if (mid > min)
                {
                    mid -= 1;
                }
                else break;
            }
            if (list[mid].Price == searchPrice)
            {
                var priceSearched = new List<Product>() { list[mid] };
                //show searched price
                Console.WriteLine(priceSearched);
            }
            //If no products with the price searched is found, pop up a message for the user
            else Console.WriteLine("No Products with this Price");
        }
    }
}
