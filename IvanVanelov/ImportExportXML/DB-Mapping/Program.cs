using System;
using System.Linq;

namespace DB_Mapping
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SupermarketChainEntities();
            var product = from vendor in context.Vendors
                          where vendor.VendorName == "Coca-Cola"
                select vendor.VendorName;
            foreach (var p in product)
            {
                Console.WriteLine(p);
            }
        }
    }
}
