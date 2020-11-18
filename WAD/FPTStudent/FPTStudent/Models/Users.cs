namespace FPTStudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int userID { get; set; }

        [StringLength(30)]
        public string username { get; set; }

        [StringLength(30)]
        public string password { get; set; }
    }
}
