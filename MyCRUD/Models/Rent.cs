using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyCRUD.Models
{
    [Table("Rent_tbl")]
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Property Number")]
        public String PropertyNo { get; set; }


        public String Street { get; set; }


        public String City { get; set; }


        [Display(Name = "Property Type")]
        public String Ptype { get; set; }


        public int Rooms { get; set; }


        [ForeignKey("owner")]
        [Display(Name = "Owner Number")]
        public String OwnerNoRef { get; set; }


        [ForeignKey("staff")]
        [Display(Name = "Staff Number")]
        public String StaffNoRef { get; set; }


        [ForeignKey("branch")]
        [Display(Name = "Branch Number")]
        public String BranchNoRef { get; set; }


        public virtual Owner owner { get; set; }
        public virtual Staff staff { get; set; }
        public virtual Branch branch { get; set; }

        [Display(Name = "Rent Cost")]
        public int rent1 { get; set; }
    }
}