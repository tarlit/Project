//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OracleDatabaseApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class MEASURE
    {
        public MEASURE()
        {
            this.PRODUCTS = new HashSet<PRODUCT>();
        }
    
        public decimal ID { get; set; }
        public string MEASURE_NAME { get; set; }
    
        public virtual ICollection<PRODUCT> PRODUCTS { get; set; }
    }
}
