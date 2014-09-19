namespace autoshopbiz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customer
    {
        public customer()
        {
            customer_vehicles = new HashSet<customer_vehicles>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customerid { get; set; }

        public string external_key { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] create_date { get; set; }

        public int? createdby { get; set; }

        [Column(TypeName = "date")]
        public DateTime? modify_date { get; set; }

        public int? modify_by { get; set; }

        [StringLength(50)]
        public string ffirst_name { get; set; }

        [StringLength(50)]
        public string last_name { get; set; }

        [StringLength(50)]
        public string user_name { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public bool? marketable { get; set; }

        public bool? active { get; set; }

        public string email_address { get; set; }

        [Column(TypeName = "text")]
        public string customer_comment { get; set; }

        public int? shop_id { get; set; }

        public virtual ICollection<customer_vehicles> customer_vehicles { get; set; }
    }
}
