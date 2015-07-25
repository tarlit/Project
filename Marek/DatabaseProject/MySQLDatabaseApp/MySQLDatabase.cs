namespace MySQLDatabaseApp
{
    using System;
    using System.IO;
    using System.Linq;

    using MySql.Data.MySqlClient;
    using Markets.Data;

    public class MySQLDatabase
    {
        private const string CONNECTION_STRING = "Server=localhost;Port=3306;Uid=root;Pwd=123456;";
        private const string MYSQL_DATABASE_SCHEMA_FILE = "../../../mysql_schema.sql";
        
        private MySqlConnection mysqlConnection;
        private ChainOfSupermarketsContext sqlServerContext;

        public MySQLDatabase(ChainOfSupermarketsContext context)
        {
            this.mysqlConnection = new MySqlConnection(CONNECTION_STRING);
            this.sqlServerContext = context;
        }

        public void Migrate()
        {
            this.CreateDbSchema();
            this.ImportDataFromSqlServer();
        }

        private void CreateDbSchema()
        {
            var queries = File.ReadAllText(MYSQL_DATABASE_SCHEMA_FILE);

            this.mysqlConnection.Open();

            using (this.mysqlConnection)
            {
                using (var command = new MySqlCommand(queries, mysqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ImportDataFromSqlServer()
        {
            this.mysqlConnection.Open();

            using (this.mysqlConnection)
            {
                using (var sqlServerDb = this.sqlServerContext)
                {
                    this.ImportVendors();
                    this.ImportMeasures();
                    this.ImportProducts();
                }
            }
        }

        private void ImportVendors()
        {
            var vendorNames = this.sqlServerContext.Vendors.Select(v => "('" + v.VendorName + "')");
            var query = string.Format(
                @"USE `chain_of_supermarkets`;
                INSERT IGNORE INTO `vendors` (`name`) VALUES {0};",
                string.Join(",", vendorNames));

            using (var command = new MySqlCommand(query, this.mysqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void ImportMeasures()
        {
            var measureNames = this.sqlServerContext.Measures.Select(m => "('" + m.MeasureName + "')");
            var query = string.Format(
                @"USE `chain_of_supermarkets`;
                INSERT IGNORE INTO `measures` (`name`) VALUES {0};",
                string.Join(",", measureNames));

            using (var command = new MySqlCommand(query, this.mysqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void ImportProducts()
        {
            var products = this.sqlServerContext.Products.Select(p => new
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
                    @"USE `chain_of_supermarkets`;
                    INSERT INTO `products` (`name`, `price`, `vendor_id`, `measure_id`)
                    VALUES('{0}', {1}, {2}, {3});",
                    product.ProductName,
                    product.Price,
                    vendorId,
                    measureId);

                using (var command = new MySqlCommand(query, this.mysqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private int GetVendorId(string vendorName)
        {
            var query = string.Format(
                @"USE `chain_of_supermarkets`;
                SELECT `id` FROM `vendors` WHERE `name`='{0}'",
                vendorName);

            using (var command = new MySqlCommand(query, this.mysqlConnection))
            {
                return (int)command.ExecuteScalar();
            }
        }

        private int GetMeasureId(string measureName)
        {
            var query = string.Format(
                @"USE `chain_of_supermarkets`;
                SELECT `id` FROM `measures` WHERE `name`='{0}'",
                measureName);

            using (var command = new MySqlCommand(query, this.mysqlConnection))
            {
                return (int)command.ExecuteScalar();
            }
        }
    }
}