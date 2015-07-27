namespace Markets.ConsoleClient
{
    using System;
    using Markets.Data;
    using Markets.DataManipulation;

    internal class Program
    {
        internal static void Main()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChainOfSupermarketsContext, Configuration>());

            var db = new ChainOfSupermarketsContext();

            //var measure = new Measure { MeasureName = "liters" };
            //db.Measures.Add(measure);
            //var measure2 = new Measure { MeasureName = "pieces" };
            //db.Measures.Add(measure2);
            //var measure3 = new Measure { MeasureName = "kg" };
            //db.Measures.Add(measure3);

            //var v = new Vendor { VendorName = "Nestle Sofia Corp." };
            //db.Vendors.Add(v);
            //v = new Vendor { VendorName = "Zagorka Corp." };
            //db.Vendors.Add(v);
            //v = new Vendor { VendorName = "Targovishte Bottling Company Ltd." };
            //db.Vendors.Add(v);
            //v = new Vendor { VendorName = "Coca-Cola" };
            //db.Vendors.Add(v);
            //v = new Vendor { VendorName = "Simid A&D" };
            //db.Vendors.Add(v);
            //v = new Vendor { VendorName = "Bella AD" };
            //db.Vendors.Add(v);

            //var pr = new Product
            //{
            //    ProductName = "Beer \"Zagorka\"",
            //    Price = 0.86m,
            //    VendorId = 2,
            //    MeasureId = 1
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Vodka \"Targovishte\"",
            //    Price = 7.56m,
            //    VendorId = 3,
            //    MeasureId = 1
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Beer \"Beck's\"",
            //    Price = 1.03m,
            //    VendorId = 2,
            //    MeasureId = 1
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Chocolate \"Milka\"",
            //    Price = 2.80m,
            //    VendorId = 1,
            //    MeasureId = 3
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Soda \"Coca - Cola\"",
            //    Price = 1.20m,
            //    VendorId = 4,
            //    MeasureId = 1
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Bread \"Rustic Bread\"",
            //    Price = 1.00m,
            //    VendorId = 5,
            //    MeasureId = 3
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Cereal \"Nesquick\"",
            //    Price = 4.60m,
            //    VendorId = 1,
            //    MeasureId = 3
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Bread \"White Bread\"",
            //    Price = 0.80m,
            //    VendorId = 5,
            //    MeasureId = 3
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Soda \"Fanta\"",
            //    Price = 1.10m,
            //    VendorId = 4,
            //    MeasureId = 1
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Bread \"Brown Bread\"",
            //    Price = 0.90m,
            //    VendorId = 5,
            //    MeasureId = 3
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Ice Cream \"Magnum\"",
            //    Price = 2.99m,
            //    VendorId = 1,
            //    MeasureId = 2
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Soda \"Sprite\"",
            //    Price = 1.15m,
            //    VendorId = 4,
            //    MeasureId = 1
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Cider \"Strongbow\"",
            //    Price = 1.60m,
            //    VendorId = 2,
            //    MeasureId = 1
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Chocolate \"LZ\"",
            //    Price = 1.40m,
            //    VendorId = 1,
            //    MeasureId = 3
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Ham \"Leki\"",
            //    Price = 3.49m,
            //    VendorId = 6,
            //    MeasureId = 3
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Ice Tea \"Nestea\"",
            //    Price = 1.59m,
            //    VendorId = 4,
            //    MeasureId = 1
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Beer \"Amstel\"",
            //    Price = 0.90m,
            //    VendorId = 2,
            //    MeasureId = 1
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Mince \"Naroden\"",
            //    Price = 1.20m,
            //    VendorId = 6,
            //    MeasureId = 3
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Biscuits \"Zhiten Dar\"",
            //    Price = 2.25m,
            //    VendorId = 1,
            //    MeasureId = 2
            //};
            //db.Products.Add(pr);
            //pr = new Product
            //{
            //    ProductName = "Juice \"Cappy\"",
            //    Price = 1.19m,
            //    VendorId = 4,
            //    MeasureId = 1
            //};
            //db.Products.Add(pr);

            //var loc = new Location { Name = "Sofia" };
            //db.Locations.Add(loc);
            //loc = new Location { Name = "Plovdiv" };
            //db.Locations.Add(loc);
            //loc = new Location { Name = "Varna" };
            //db.Locations.Add(loc);
            //loc = new Location { Name = "Burgas" };
            //db.Locations.Add(loc);
            //loc = new Location { Name = "Ruse" };
            //db.Locations.Add(loc);
            //loc = new Location { Name = "Pleven" };
            //db.Locations.Add(loc);

            //var s = new Sale
            //{
            //    Quantity = 3,
            //    ProductId = 2,
            //    PricePerUnit = 7.56m,
            //    DateOfSale = DateTime.Now,
            //    LocationId = 1
            //};
            //db.Sales.Add(s);
            //s = new Sale
            //{
            //    Quantity = 10,
            //    ProductId = 4,
            //    PricePerUnit = 2.80m,
            //    DateOfSale = DateTime.Now,
            //    LocationId = 2
            //};
            //db.Sales.Add(s);
            //s = new Sale
            //{
            //    Quantity = 30,
            //    ProductId = 12,
            //    PricePerUnit = 1.15m,
            //    DateOfSale = DateTime.Now,
            //    LocationId = 4
            //};
            //db.Sales.Add(s);
            //s = new Sale
            //{
            //    Quantity = 22,
            //    ProductId = 8,
            //    PricePerUnit = 0.80m,
            //    DateOfSale = DateTime.Now,
            //    LocationId = 1
            //};
            //db.Sales.Add(s);
            //s = new Sale
            //{
            //    Quantity = 9,
            //    ProductId = 19,
            //    PricePerUnit = 1.20m,
            //    DateOfSale = DateTime.Now,
            //    LocationId = 3
            //};
            //db.Sales.Add(s);

            //db.SaveChanges();

            // JSON Reports
            string reportsDirectoryPath = @"..\..\Json-Reports";
            var json = new JsonReport(db, reportsDirectoryPath);
            DateTime start = new DateTime(27/7/2015);
            DateTime end = new DateTime(28/7/2015);
            json.ProductSalesForPeriod(start, end);
            Console.WriteLine("JSON reports generate.");

            Console.ReadLine();
        }
    }
}
