using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DB_Mapping;


namespace Export_XML
{
    class ExportReportAsXML
    {
        static void Main()
        {
            var context = new SupermarketChainEntities();
            var vendors = context.Vendors
                .OrderBy(v => v.VendorName)
                .Select(v => new
                {
                    v.VendorName,
                    Products = v.Products
                        .OrderBy(p => p.ProductName)
                        .Select(p => p.ProductName)
                });

            var xmlreport = new XElement("report");
            foreach (var vendor in vendors)
            {
                var xmlvendor = new XElement("vendor");
                xmlvendor.Add(new XAttribute("name", vendor.VendorName.Trim()));
                xmlreport.Add(xmlvendor);
                foreach (var product in vendor.Products)
                {
                    xmlvendor.Add(new XElement("product", product.Trim()));
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var xmlDocument = new XDocument(xmlreport);
            xmlDocument.Save(path + "\\report.xml");
        }
    }
}
