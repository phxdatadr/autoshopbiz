namespace autoshopbiz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customer_vehicles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vehicle_id { get; set; }

        public int? customer_id { get; set; }

        public string vin { get; set; }

        [StringLength(50)]
        public string year { get; set; }

        [StringLength(50)]
        public string make { get; set; }

        public string model { get; set; }

        public bool? active { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] create_date { get; set; }

        public int? created_by { get; set; }

        public virtual customer customer { get; set; }
    }
}
