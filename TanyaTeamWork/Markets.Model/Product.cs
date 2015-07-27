﻿namespace Markets.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string ProductName { get; set; }

        public double Price { get; set; }

        public int VendorId { get; set; }
        public virtual Vendor Vendors { get; set; }

        public int MeasureId { get; set; }
        public virtual Measure Measure { get; set; }
    }
}