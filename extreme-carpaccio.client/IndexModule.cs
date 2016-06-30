using System.Diagnostics;
using System.IO;
using System.Text;

namespace xCarpaccio.client
{
    using Nancy;
    using System;
    using Nancy.ModelBinding;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => "It works !!! You need to register your server on main server.";

            Post["/order"] = _ =>
            {
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Console.WriteLine("Order received: {0}", reader.ReadToEnd());
                }

                var order = this.Bind<Order>();
                Bill bill = new Bill();
                //return null;
                decimal tempTotal = 0;
                if (order.Prices.Length < order.Quantities.Length)
                {
                    return null;
                }
                for (var i = 0; i < order.Prices.Length; i++)
                {
                    tempTotal += order.Prices[i]*order.Quantities[i];
                }
                double taxe=0;
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
                if (taxe == 0)
                {
                    return null;
                }
                else
                {
                    tempTotal *= (decimal)taxe;
                }

                if (order.Reduction == "STANDARD")
                {
                    if (tempTotal >= 1000)
                        tempTotal *= (decimal) 0.97;
                    else if (tempTotal >= 5000)
                        tempTotal *= (decimal) 0.95;
                    else if (tempTotal >= 7000)
                        tempTotal *= (decimal) 0.93;
                    else if (tempTotal >= 10000)
                        tempTotal *= (decimal) 0.90;
                    else if (tempTotal >= 50000)
                        tempTotal *= (decimal) 0.85;
                    bill.total = Math.Round(tempTotal, 2);
                    return bill;
                }
                else
                {
                    return null;
                }
                return null;
            };

            Post["/feedback"] = _ =>
            {
                var feedback = this.Bind<Feedback>();
                Console.Write("Type: {0}: ", feedback.Type);
                Console.WriteLine(feedback.Content);
                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            };
        }
    }
}