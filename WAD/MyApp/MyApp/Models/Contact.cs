namespace MyApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        [Required]
        [StringLength(56)]
        public string ContactName { get; set; }

        public int ContactNumber { get; set; }

        [Required]
        [StringLength(56)]
        public string GroupName { get; set; }

        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
    }
}
