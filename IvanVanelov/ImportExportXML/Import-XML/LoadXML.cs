using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using DB_Mapping;

namespace Import_XML
{
    class LoadXML
    {
        static void Main()
        {
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\expenses.xml";
            var xmlDocument = new XDocument();
            try
            {
                xmlDocument = XDocument.Load(documentPath);
                Console.WriteLine("XML file has been found!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
            
            var nodes = xmlDocument.XPathSelectElements("//expenses-by-month/vendor");

            foreach (var vendor in nodes)
            {
                string vendorName = vendor.Attribute("name").Value;
                var expenses = vendor.Elements("expenses");

                foreach (var expense in expenses)
                {
                    DateTime month = DateTime.Parse(expense.Attribute("month").Value);
                    decimal amount = decimal.Parse(expense.Value);
                    AddVendorExpense(vendorName, month, amount);
                }    
            } 
        }

        private static void AddVendorExpense(string vendorName, DateTime expenseDate, decimal expenseAmount)
        {
            var context = new SupermarketChainEntities();
            var vendorId = context.Vendors
                .Where(v => v.VendorName.Trim() == vendorName)
                .Select(v => v.Id).First();

            Expense expenseEntity = new Expense();
            expenseEntity.VdendorId = vendorId;
            expenseEntity.Date = expenseDate;
            expenseEntity.Amount = expenseAmount;
            context.Expenses.Add(expenseEntity);
            context.SaveChanges();
            Console.WriteLine("Added expense for vendor: {0}", vendorName);
        }
    }
}
