using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyCRUD.Models
{
    [Table("Owner_tbl")]
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Owner Number")]
        public String OwnerNo { get; set; }


        [Display(Name = "First Name")]
        public String Fname { get; set; }


        [Display(Name = "Last Name")]
        public String Lname { get; set; }


        public String Address { get; set; }


        [Display(Name = "Telephone Number")]
        public String TelNo { get; set; }


        public List<Rent> rent { get; set; }
    }
}