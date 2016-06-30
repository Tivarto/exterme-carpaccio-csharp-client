using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;
using xCarpaccio.client;

namespace extreme_carpaccio_test
{
    [TestFixture]

    public class Class1
    {
        [Test]
        public void TestMethod()
        {
            Order order = new Order();
            order.Prices = new[] {4.1m, 8.03m, 86.83m, 65.62m, 44.82m};
            order.Quantities = new[] {10, 3, 5, 4, 5};
            order.Country = "AT";
            order.Reduction = "STANDARD";
            Bill bill = new Bill();
            decimal tempTotal = 0;
            for (var i = 0; i < order.Prices.Length; i++)
            {
                tempTotal += order.Prices[i] * order.Quantities[i];
            }
            double taxe = 0;
            switch (order.Country)
            {
                case "DE":
                    taxe = 1.20;
                    break;
                case "UK":
                    taxe = 1.21;
                    break;
                case "FR":
                    taxe = 1.20;
                    break;
                case "IT":
                    taxe = 1.25;
                    break;
                case "ES":
                    taxe = 1.19;
                    break;
                case "PL":
                    taxe = 1.21;
                    break;
                case "RO":
                    taxe = 1.20;
                    break;
                case "NL":
                    taxe = 1.20;
                    break;
                case "BE":
                    taxe = 1.24;
                    break;
                case "EL":
                    taxe = 1.20;
                    break;
                case "CZ":
                    taxe = 1.19;
                    break;
                case "PT":
                    taxe = 1.23;
                    break;
                case "HU":
                    taxe = 1.27;
                    break;
                case "SE":
                    taxe = 1.23;
                    break;
                case "AT":
                    taxe = 1.22;
                    break;
                case "BG":
                    taxe = 1.21;
                    break;
                case "DK":
                    taxe = 1.21;
                    break;
                case "FI":
                    taxe = 1.17;
                    break;
                case "SK":
                    taxe = 1.18;
                    break;
                case "IE":
                    taxe = 1.21;
                    break;
                case "HR":
                    taxe = 1.23;
                    break;
                case "LT":
                    taxe = 1.23;
                    break;
                case "SI":
                    taxe = 1.24;
                    break;
                case "LV":
                    taxe = 1.20;
                    break;
                case "EE":
                    taxe = 1.22;
                    break;
                case "CY":
                    taxe = 1.21;
                    break;
                case "LU":
                    taxe = 1.25;
                    break;
                case "MT":
                    taxe = 1.20;
                    break;
                default:
                    taxe = 0;
                    break;
            }
            tempTotal *= (decimal)taxe;

            if (order.Reduction == "STANDARD")
            {
                if (tempTotal >= 1000)
                    tempTotal *= (decimal)0.97;
                else if (tempTotal >= 5000)
                    tempTotal *= (decimal)0.95;
                else if (tempTotal >= 7000)
                    tempTotal *= (decimal)0.93;
                else if (tempTotal >= 10000)
                    tempTotal *= (decimal)0.90;
                else if (tempTotal >= 50000)
                    tempTotal *= (decimal)0.85;
                bill.total = Math.Round(tempTotal, 2);
            }
            Assert.AreEqual(1166.62, bill.total);
        }
    }
}
