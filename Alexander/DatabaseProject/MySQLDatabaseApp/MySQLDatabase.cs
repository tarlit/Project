namespace MySQLDatabaseApp
{
    using System;
    using System.IO;
    using System.Linq;

    using MySql.Data.MySqlClient;
    using Markets.Data;

    public static class MySQLDatabase
    {
        private const string CONNECTION_STRING = "Server=localhost;Port=3306;Uid=root;Pwd=123456;";
        
        private static MySqlConnection mysqlConnection;

        private static ChainOfSupermarketsContext SQLServerContext;

        public static void MigrateToMySql(ChainOfSupermarketsContext sqlServerContext)
        {
            mysqlConnection = new MySqlConnection(CONNECTION_STRING);
            SQLServerContext = sqlServerContext;

            CreateDbSchema();
            ImportDataFromSqlServer();
        }

        private static void CreateDbSchema()
        {
            var queries = File.ReadAllText("../../../mysql_schema.sql");

            mysqlConnection.Open();

            using (mysqlConnection)
            {
                using (var command = new MySqlCommand(queries, mysqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void ImportDataFromSqlServer()
        {
            mysqlConnection.Open();

            using (mysqlConnection)
            {
                using (var sqlServerDb = SQLServerContext)
                {
                    ImportVendors();
                    ImportMeasures();
                    ImportProducts();
                }
            }
        }

        private static void ImportVendors()
        {
            var vendorNames = SQLServerContext.Vendors.Select(v => "('" + v.VendorName + "')");
            var query = string.Format(
                "USE `chain_of_supermarkets`; INSERT IGNORE INTO `vendors` (`name`) VALUES {0};",
                string.Join(",", vendorNames));

            using (var command = new MySqlCommand(query, mysqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static void ImportMeasures()
        {
            var measureNames = SQLServerContext.Measures.Select(m => "('" + m.MeasureName + "')");
            var query = string.Format(
                "USE `chain_of_supermarkets`; INSERT IGNORE INTO `measures` (`name`) VALUES {0};",
                string.Join(",", measureNames));

            using (var command = new MySqlCommand(query, mysqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static void ImportProducts()
        {
            var products = SQLServerContext.Products.Select(p => new
            {
                p.ProductName,
                p.Price,
                VendorName = p.Vendors.VendorName,
                MeasureName = p.Measures.MeasureName
            });

            foreach (var product in products)
            {
                int vendorId = GetVendorId(product.VendorName);
                int measureId = GetMeasureId(product.MeasureName);

                var query = string.Format(
                    "USE `chain_of_supermarkets`; INSERT INTO `products` (`name`, `price`, `vendor_id`, `measure_id`) VALUES('{0}', {1}, {2}, {3});",
                    product.ProductName,
                    product.Price,
                    vendorId,
                    measureId);

                using (var command = new MySqlCommand(query, mysqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static int GetVendorId(string vendorName)
        {
            var query = string.Format("USE `chain_of_supermarkets`; SELECT `id` FROM `vendors` WHERE `name`='{0}'", vendorName);

            using (var command = new MySqlCommand(query, mysqlConnection))
            {
                return (int)command.ExecuteScalar();
            }
        }

        private static int GetMeasureId(string measureName)
        {
            var query = string.Format("USE `chain_of_supermarkets`; SELECT `id` FROM `measures` WHERE `name`='{0}'", measureName);

            using (var command = new MySqlCommand(query, mysqlConnection))
            {
                return (int)command.ExecuteScalar();
            }
        }
    }
}